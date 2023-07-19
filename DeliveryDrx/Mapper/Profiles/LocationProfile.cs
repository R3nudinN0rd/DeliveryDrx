using AutoMapper;

namespace DeliveryDrxAPI.Mapper.Profiles
{
    public class LocationProfile:Profile
    {
        public LocationProfile()
        {
            CreateMap<Entities.Location, Models.LocationDTO>().ReverseMap();
        }
    }
}
