using AutoMapper;
using DeliveryDrxAPI.Entities;
using DeliveryDrxAPI.Mapper.Models;
using DeliveryDrxAPI.Repositories.TransportRepositories;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryDrxAPI.Controllers
{
    [ApiController]
    [Route("/api/transport")]
    [EnableCors("AllowOrigins")]
    public class TransportController:ControllerBase
    {
        private readonly ITransportRepository _transportRepository;
        private readonly IMapper _mapper;
        public TransportController(ITransportRepository transportRepository, IMapper mapper)
        {
            _transportRepository = transportRepository ?? throw new ArgumentNullException(nameof(transportRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public ActionResult<IEnumerable<TransportDTO>> GetAllTransports()
        {
            var transportsFromRepo = _transportRepository.GetAllTransportsAsync().GetAwaiter().GetResult();
            return Ok(_mapper.Map<IEnumerable<TransportDTO>>(transportsFromRepo));
        }

        [HttpGet("driver/{driverId}")]
        public ActionResult<IEnumerable<TransportDTO>> GetTransportsByDriverId(int driverId)
        {
            var transportsFromRepo = _transportRepository.GetTransportsByDriverId(driverId).GetAwaiter().GetResult();
            return Ok(_mapper.Map<IEnumerable<TransportDTO>>(transportsFromRepo));
        }

        [HttpGet("location/{locationId}")]
        public ActionResult<IEnumerable<TransportDTO>> GetTransportsByLocationId(int locationId)
        {
            var transportsFromRepo = _transportRepository.GetTransportsByLocationIdAsync(locationId).GetAwaiter().GetResult();
            return Ok(_mapper.Map<IEnumerable<TransportDTO>>(transportsFromRepo));
        }

        [HttpGet("id/{transportId}", Name="GetTransportById")]
        public ActionResult<TransportDTO> GetTransportById(int transportId)
        {
            var transportFromRepo = _transportRepository.GetTransportByIdAsync(transportId).GetAwaiter().GetResult();
            return Ok(_mapper.Map<TransportDTO>(transportFromRepo));
        }

        [HttpPost]
        public ActionResult AddTransport(TransportDTO transportDTO)
        {
            var transportForInserting = _mapper.Map<Transport>(transportDTO);
            _transportRepository.AddTransport(transportForInserting);
            return CreatedAtRoute("GetTransportById",
                                  new { transportId = transportForInserting.Id },
                                  transportDTO);
        }

        [HttpPut]
        public ActionResult UpdateTransport(TransportDTO transportDTO)
        {
            var transportForUpdating = _mapper.Map<Transport>(transportDTO);
            _transportRepository.UpdateTransport(transportForUpdating);
            return NoContent();
        }

        [HttpDelete("id/transportId")]
        public ActionResult DeleteTransport(int transportId)
        {
            _transportRepository.DeleteTransport(transportId);
            return Ok();
        }
    }
}
