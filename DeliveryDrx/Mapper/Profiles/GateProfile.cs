using AutoMapper;

namespace DeliveryDrxAPI.Mapper.Profiles
{
    public class GateProfile:Profile
    {
        public GateProfile()
        {
            CreateMap<Entities.Gate, Models.GateDTO>().ReverseMap();
        }
    }
}
