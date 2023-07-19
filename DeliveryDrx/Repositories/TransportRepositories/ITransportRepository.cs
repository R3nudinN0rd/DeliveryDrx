using DeliveryDrxAPI.Entities;
using Microsoft.Data.SqlClient;

namespace DeliveryDrxAPI.Repositories.TransportRepositories
{
    public interface ITransportRepository
    {
        public Task<IEnumerable<Transport>> GetAllTransportsAsync();
        public Task<IEnumerable<Transport>> GetTransportsByDriverId(int driverId);
        public Task<IEnumerable<Transport>> GetTransportsByLocationIdAsync(int locationId);
        public Task<Transport> GetTransportByIdAsync(int transportId);
        public void AddTransport(Transport transport);
        public void UpdateTransport(Transport transport);
        public void DeleteTransport(int transportId);
    }
}
