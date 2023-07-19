using AutoMapper;

namespace DeliveryDrxAPI.Mapper.Profiles
{
    public class TransportScheduleProfile:Profile
    {
        public TransportScheduleProfile()
        {

            CreateMap<Entities.TransportSchedule, Models.TransportScheduleDTO>().ReverseMap();
        }
    }
}
