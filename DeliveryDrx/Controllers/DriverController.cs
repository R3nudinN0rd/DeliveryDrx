using AutoMapper;
using DeliveryDrxAPI.Entities;
using DeliveryDrxAPI.Mapper.Models;
using DeliveryDrxAPI.Repositories.DriverRepositories;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryDrxAPI.Controllers
{
    [ApiController]
    [Route("/api/driver")]
    [EnableCors("AllowOrigins")]
    public class DriverController:ControllerBase
    {
        private readonly IDriverRepository _driverRepository;
        private readonly IMapper _mapper;

        public DriverController(IDriverRepository driverRepository, IMapper mapper)
        {
            _driverRepository = driverRepository ?? throw new ArgumentNullException(nameof(driverRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public ActionResult<IEnumerable<DriverDTO>> GetAllDrivers()
        {
            var driversFromRepo = _driverRepository.GetAllDriversAsync().GetAwaiter().GetResult();
            return Ok(_mapper.Map<IEnumerable<DriverDTO>>(driversFromRepo));
        }

        [HttpGet("id/{driverId}", Name="GetDriverById")]
        public ActionResult<DriverDTO> GetDriverById(int driverId)
        {
            var driverFromRepo = _driverRepository.GetDriverById(driverId).GetAwaiter().GetResult();
            return Ok(_mapper.Map<DriverDTO>(driverFromRepo));
        }

        [HttpGet("email")]
        public ActionResult<DriverDTO> GetDriverByEmai1(string email)
        {
            var driverFromRepo = _driverRepository.GetDriverByEmailAsync(email).GetAwaiter().GetResult(); 
            return Ok(_mapper.Map<DriverDTO>(driverFromRepo));
        }

        [HttpGet("phone-number")]
        public ActionResult<DriverDTO> GetDriverByPhoneNumber(string phoneNumber)
        {
            var driverFromRepo = _driverRepository.GetDriverByPhoneNumberAsync(phoneNumber).GetAwaiter().GetResult();
            return Ok(_mapper.Map<DriverDTO>(driverFromRepo));
        }

        [HttpPost]
        public ActionResult AddDriver(DriverDTO driverDTO)
        {
            var driverForInsertion = _mapper.Map<Driver>(driverDTO);
            _driverRepository.AddDriver(driverForInsertion);
            return CreatedAtRoute("GetDriverById",
                                  new { driverId = driverForInsertion.Id },
                                  driverDTO);
        }

        [HttpPut]
        public ActionResult UpdateDriver(DriverDTO driverDTO)
        { 
            var driverForUpdating = _mapper.Map<Driver>(driverDTO);
            _driverRepository.UpdateDriver(driverForUpdating);
            return NoContent();
        }

        [HttpDelete("id/{driverId}")]
        public ActionResult DeleteDriver(int driverId)
        {
            _driverRepository.DeleteDriver(driverId);
            return Ok();
        }
    }
}
