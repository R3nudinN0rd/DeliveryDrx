using AutoMapper;

namespace DeliveryDrxAPI.Mapper.Profiles
{
    public class DriverProfile:Profile
    {
        public DriverProfile()
        {
            CreateMap<Entities.Driver, Models.DriverDTO>().ReverseMap();
        }
    }
}
