using DeliveryDrxAPI.Context;
using DeliveryDrxAPI.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DeliveryDrxAPI.Repositories.TransportScheduleRepositories
{
    public class TransportScheduleRepository:ITransportScheduleRepository
    {
        private readonly DeliveryDrxContext _context;
        public TransportScheduleRepository(DeliveryDrxContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void AddTransportSchedule(TransportSchedule transportSchedule)
        {
            try
            {
                _context.TransportSchedules.Add(transportSchedule);
                _context.SaveChanges();
            }
            catch(SqlException ex)
            {
                throw ex;
            }

        }

        public async void DeleteTransportSchdule(int transportSchduleId)
        {
            try
            {
                var transportSchdule = await _context.TransportSchedules.FirstOrDefaultAsync(ts => ts.Id == transportSchduleId);
                _context.TransportSchedules.Remove(transportSchdule);
                _context.SaveChanges();
            }
            catch(SqlException ex)
            {
                throw ex;
            }

        }

        public async Task<IEnumerable<TransportSchedule>> GetAllTransportScheduleAsync()
        {
            return await _context.TransportSchedules.ToListAsync();
        }

        public async Task<TransportSchedule> GetTransportScheduleById(int transportScheduleId)
        {
            return await _context.TransportSchedules.FirstOrDefaultAsync(ts => ts.Id == transportScheduleId);
        }

        public async Task<IEnumerable<TransportSchedule>> GetTransportsScheduleByGateIdAsync(int gateId)
        {
            return await _context.TransportSchedules.Where(ts => ts.GateId == gateId).ToListAsync();
        }

        public async Task<IEnumerable<TransportSchedule>> GetTransportsScheduleByTransportId(int transportId)
        {
            return await _context.TransportSchedules.Where(ts => ts.TransportId == transportId).ToListAsync();
        }

        public void UpdateTransportSchdule(TransportSchedule transportSchedule)
        {
            try
            {
                _context.TransportSchedules.Update(transportSchedule);
                _context.SaveChanges();
            }
            catch(SqlException ex)
            {
                throw ex;
            }

        }
    }
}
