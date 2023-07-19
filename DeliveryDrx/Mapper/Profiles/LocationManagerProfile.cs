using AutoMapper;

namespace DeliveryDrxAPI.Mapper.Profiles
{
    public class LocationManagerProfile:Profile
    {
        public LocationManagerProfile()
        {
            CreateMap<Entities.LocationManager, Models.LocationManagerDTO>().ReverseMap();
        }
    }
}
