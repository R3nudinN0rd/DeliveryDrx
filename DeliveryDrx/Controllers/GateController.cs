using AutoMapper;
using DeliveryDrxAPI.Entities;
using DeliveryDrxAPI.Mapper.Models;
using DeliveryDrxAPI.Repositories.GateRepository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryDrxAPI.Controllers
{
    [ApiController]
    [Route("/api/gate")]
    [EnableCors("AllowOrigins")]
    public class GateController:ControllerBase
    {
        private readonly IGateRepository _gateRepository;
        private readonly IMapper _mapper;
        public GateController(IGateRepository gateRepository, IMapper mapper)
        {
            _gateRepository = gateRepository ?? throw new ArgumentNullException(nameof(gateRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet("all")]
        public ActionResult<IEnumerable<GateDTO>> GetAllGate()
        {
            var gatesFromRepo = _gateRepository.GetAllGatesAsync().GetAwaiter().GetResult();
            return Ok(_mapper.Map<IEnumerable<GateDTO>>(gatesFromRepo));
        }

        [HttpGet("id/{gateId}", Name="GetGateById")]
        public ActionResult<GateDTO> GetGateById(int gateId)
        {
            var gateFromRepo = _gateRepository.GetGateByIdAsync(gateId).GetAwaiter().GetResult();
            return Ok(_mapper.Map<GateDTO>(gateFromRepo));
        }

        [HttpGet("gate-on-location/{locationId}")]
        public ActionResult<IEnumerable<GateDTO>> GetGatesByLocationId(int locationId)
        {
            var gatesFromRepo = _gateRepository.GetGatesByLocationIdAsync(locationId).GetAwaiter().GetResult();
            return Ok(_mapper.Map<GateDTO>(gatesFromRepo));
        }

        [HttpPost]
        public ActionResult AddGate(GateDTO gateDTO)
        {
            var gateForInsertion = _mapper.Map<Gate>(gateDTO);
            _gateRepository.AddGate(gateForInsertion);

            return CreatedAtRoute("GetGateById",
                                  new { gateId = gateForInsertion.Id },
                                  gateDTO);
        }

        [HttpDelete("id/{gateId}")]
        public ActionResult DeleteGate(int gateId)
        {
            _gateRepository.DeleteGate(gateId);
            return Ok();
        }

    }
}
