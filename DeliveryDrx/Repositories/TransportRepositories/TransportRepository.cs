using DeliveryDrxAPI.Context;
using DeliveryDrxAPI.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DeliveryDrxAPI.Repositories.TransportRepositories
{
    public class TransportRepository:ITransportRepository
    {
        private readonly DeliveryDrxContext _context;
        public TransportRepository(DeliveryDrxContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void AddTransport(Transport transport)
        {
            try
            {
                _context.Transports.Add(transport);
                _context.SaveChanges();
            }
            catch(SqlException ex)
            {
                throw ex;
            }

        }

        public async void DeleteTransport(int transportId)
        {
            try
            {
                var transport = await _context.Transports.FirstOrDefaultAsync(transport => transport.Id == transportId);
                _context.Transports.Remove(transport);
            }
            catch(SqlException ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Transport>> GetAllTransportsAsync()
        {
            return await _context.Transports.ToListAsync();
        }

        public async Task<Transport> GetTransportByIdAsync(int transportId)
        {
            return await _context.Transports.FirstOrDefaultAsync(transport => transport.Id == transportId);
        }

        public async Task<IEnumerable<Transport>> GetTransportsByDriverId(int driverId)
        {
            return await _context.Transports.Where(transport => transport.DriverId == driverId).ToListAsync();
        }

        public async Task<IEnumerable<Transport>> GetTransportsByLocationIdAsync(int locationId)
        {
            return await _context.Transports.Where(transport => transport.LocationId == locationId).ToListAsync();
        }

        public void UpdateTransport(Transport transport)
        {
            try
            {
                _context.Transports.Update(transport);
                _context.SaveChanges();
            }
            catch(SqlException ex)
            {
                throw ex;
            }
        }
    }
}
