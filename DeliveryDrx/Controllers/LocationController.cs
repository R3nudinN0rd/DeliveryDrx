using AutoMapper;
using DeliveryDrxAPI.Entities;
using DeliveryDrxAPI.Mapper.Models;
using DeliveryDrxAPI.Repositories.LocationRepositories;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryDrxAPI.Controllers
{
    [ApiController]
    [Route("/api/location")]
    [EnableCors("AllowOrigins")]
    public class LocationController:ControllerBase
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IMapper _mapper;
        public LocationController(ILocationRepository locationRepository, IMapper mapper)
        {
            _locationRepository = locationRepository ?? throw new ArgumentNullException(nameof(locationRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public ActionResult<IEnumerable<LocationDTO>> GetAllLocations()
        {
            var locationsFromRepo = _locationRepository.GetAllLocationsAsync().GetAwaiter().GetResult();
            return Ok(_mapper.Map<IEnumerable<LocationDTO>>(locationsFromRepo));
        }

        [HttpGet("id/{locationId}",Name="GetLocationsById")]
        public ActionResult<LocationDTO> GetLocationById(int locationId)
        {
            var locationFromRepo = _locationRepository.GetLocationByIdAsync(locationId).GetAwaiter().GetResult();
            return Ok(_mapper.Map<LocationDTO>(locationFromRepo));
        }


        [HttpPost]
        public ActionResult AddLocation(LocationDTO locationDTO)
        {
            var locationForInsertion = _mapper.Map<Location>(locationDTO);
            _locationRepository.AddLocation(locationForInsertion);
            return CreatedAtRoute("GetLocationById",
                                  new { locationId = locationForInsertion.Id },
                                  locationDTO);
        }

        [HttpPut]
        public ActionResult UpdateLocation(LocationDTO locationDTO)
        {
            var locationForUpdating = _mapper.Map<Location>(locationDTO);
            _locationRepository.UpdateLocation(locationForUpdating);
            return NoContent();
        }
        [HttpDelete("id/{locationId}")]
        public ActionResult DeleteLocation(int locationId)
        {
            _locationRepository.DeleteLocation(locationId);
            return Ok();
        }
    }
}
