using DeliveryDrxAPI.Entities;
using Microsoft.Data.SqlClient;

namespace DeliveryDrxAPI.Repositories.TransportScheduleRepositories
{
    public interface ITransportScheduleRepository
    {
        public Task<IEnumerable<TransportSchedule>> GetAllTransportScheduleAsync();
        public Task<IEnumerable<TransportSchedule>> GetTransportsScheduleByGateIdAsync(int gateId);
        public Task<IEnumerable<TransportSchedule>> GetTransportsScheduleByTransportId(int transportId);
        public Task<TransportSchedule> GetTransportScheduleById(int transportScheduleId);
        public void AddTransportSchedule(TransportSchedule transportSchedule);
        public void UpdateTransportSchdule(TransportSchedule transportSchedule);
        public void DeleteTransportSchdule(int transportSchduleId);
    }
}
