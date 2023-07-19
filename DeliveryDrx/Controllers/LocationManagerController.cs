using AutoMapper;
using DeliveryDrxAPI.Entities;
using DeliveryDrxAPI.Mapper.Models;
using DeliveryDrxAPI.Repositories.LocationManagerRepositories;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryDrxAPI.Controllers
{
    [ApiController]
    [Route("/api/location-manager")]
    [EnableCors("AllowOrigins")]
    public class LocationManagerController:ControllerBase
    {
        private readonly ILocationManagerRepository _locationManagerRepository;
        private readonly IMapper _mapper;
        public LocationManagerController(ILocationManagerRepository locationManagerRepository, IMapper mapper)
        {
            _locationManagerRepository = locationManagerRepository ?? throw new ArgumentNullException(nameof(locationManagerRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet("all")]
        public ActionResult<IEnumerable<LocationManagerDTO>> GetAllLocationManagers()
        {
            var locationManagersFromRepo = _locationManagerRepository.GetAllLocationManagersAsync().GetAwaiter().GetResult();
            return Ok(_mapper.Map<IEnumerable<LocationManagerDTO>>(locationManagersFromRepo));
        }

        [HttpGet("id/{locationManagerId}", Name="GetLocationManagerById")]
        public ActionResult<LocationManagerDTO> GetLocationManagerById(int locationManagerId) 
        {
            var locationManagerFromRepo = _locationManagerRepository.GetLocationManagersByIdAsync(locationManagerId).GetAwaiter().GetResult();
            return Ok(_mapper.Map<LocationManagerDTO>(locationManagerFromRepo));
        }
        [HttpGet("phone-number/{phoneNumber}")]
        public ActionResult<LocationManagerDTO> GetLocationManagerByPhoneNumber(string phoneNumber)
        {
            var locationManagerFromRepo = _locationManagerRepository.GetLocationManagerByPhoneNumberAsync(phoneNumber).GetAwaiter().GetResult();
            return Ok(_mapper.Map<LocationManagerDTO>(locationManagerFromRepo));
        }

        [HttpPost]
        public ActionResult AddLocationManager(LocationManagerDTO locationManagerDTO)
        {
            var locationManagerForInserting = _mapper.Map<LocationManager>(locationManagerDTO);
            _locationManagerRepository.AddLocationManager(locationManagerForInserting);
            return CreatedAtRoute("GetLocationManagerById",
                                  new { locationManagerId = locationManagerForInserting.Id },
                                  locationManagerDTO);
        }

        [HttpPut]
        public ActionResult UpdateLocationManager(LocationManagerDTO locationManagerDTO)
        {
            var locationManagerForUpdating = _mapper.Map<LocationManager>(locationManagerDTO);
            _locationManagerRepository.UpdateLocationManager(locationManagerForUpdating);
            return NoContent();
        }

        [HttpDelete("id/{locationManagerId}")]
        public ActionResult DeleteLocationManager(int locationManagerId)
        {
            _locationManagerRepository.DeleteLocationManager(locationManagerId);
            return Ok();
        }
    }
}
