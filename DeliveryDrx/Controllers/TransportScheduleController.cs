using AutoMapper;
using DeliveryDrxAPI.Entities;
using DeliveryDrxAPI.Mapper.Models;
using DeliveryDrxAPI.Repositories.TransportScheduleRepositories;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryDrxAPI.Controllers
{
    [ApiController]
    [Route("/api/transport_schedule")]
    [EnableCors("AllowOrigins")]
    public class TransportScheduleController : ControllerBase
    {
        private readonly ITransportScheduleRepository _transportScheduleRepository;
        private readonly IMapper _mapper;
        public TransportScheduleController(ITransportScheduleRepository transportScheduleRepository, IMapper mapper)
        {
            _transportScheduleRepository = transportScheduleRepository ?? throw new ArgumentNullException(nameof(transportScheduleRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet("all")]
        public ActionResult<IEnumerable<TransportScheduleDTO>> GetAllTransportChedules()
        {
            var transportSchedulesFromRepo = _transportScheduleRepository.GetAllTransportScheduleAsync().GetAwaiter().GetResult();
            return Ok(_mapper.Map<IEnumerable<TransportScheduleDTO>>(transportSchedulesFromRepo));
        }

        [HttpGet("gate/{gateId}")]
        public ActionResult<IEnumerable<TransportScheduleDTO>> GetTransportSchedulesByGateId(int gateId)
        {
            var transportSchedulesFromRepo = _transportScheduleRepository.GetTransportsScheduleByGateIdAsync(gateId).GetAwaiter().GetResult();
            return Ok(_mapper.Map<TransportScheduleDTO>(transportSchedulesFromRepo));
        }

        [HttpGet("transport/{transportId}")]
        public ActionResult<IEnumerable<TransportScheduleDTO>> GetTransportSchedulesByTransportId(int transportId)
        {
            var transportSchedulesFromRepo = _transportScheduleRepository.GetTransportsScheduleByTransportId(transportId).GetAwaiter().GetResult();
            return Ok(_mapper.Map<TransportScheduleDTO>(transportSchedulesFromRepo));
        }

        [HttpGet("id/{transportScheduleId}",Name="GetTransportScheduleById")]
        public ActionResult<TransportScheduleDTO> GetTransportScheduleById(int transportScheduleId)
        {
            var transportScheduleFromRepo = _transportScheduleRepository.GetTransportScheduleById(transportScheduleId).GetAwaiter().GetResult();
            return Ok(_mapper.Map<TransportScheduleDTO>(transportScheduleFromRepo));
        }

        [HttpPost]
        public ActionResult AddTransportSchedule(TransportScheduleDTO transportScheduleDTO)
        {
            var transporScheduleForInsertion = _mapper.Map<TransportSchedule>(transportScheduleDTO);
            _transportScheduleRepository.AddTransportSchedule(transporScheduleForInsertion);
            return CreatedAtRoute("GetTransportScheduleById",
                                  new { transportScheduleId = transporScheduleForInsertion.Id },
                                  transportScheduleDTO);
                                    
        }

        [HttpPut]
        public ActionResult UpdateTransportSchedule(TransportScheduleDTO transportScheduleDTO)
        {
            var transportScheduleForUpdating = _mapper.Map<TransportSchedule>(transportScheduleDTO);
            _transportScheduleRepository.UpdateTransportSchdule(transportScheduleForUpdating);
            return NoContent();
        }

        [HttpDelete("id/{transportScheduleId}")]
        public ActionResult DeleteTransportSchedule(int transportScheduleId)
        {
            _transportScheduleRepository.DeleteTransportSchdule(transportScheduleId);
            return Ok();
        }
    }
}
