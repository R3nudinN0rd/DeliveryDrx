using AutoMapper;
namespace DeliveryDrxAPI.Mapper.Profiles
{
    public class TransportProfile:Profile
    {
        public TransportProfile()
        {

            CreateMap<Entities.Transport, Models.TransportDTO>().ReverseMap();
        }
    }
}
