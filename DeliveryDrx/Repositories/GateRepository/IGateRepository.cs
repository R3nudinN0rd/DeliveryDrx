using DeliveryDrxAPI.Entities;
using DeliveryDrxAPI.Mapper.Models;
using Microsoft.Data.SqlClient;

namespace DeliveryDrxAPI.Repositories.GateRepository
{
    public interface IGateRepository
    {
        public Task<IEnumerable<Gate>> GetAllGatesAsync();
        public Task<Gate> GetGateByIdAsync(int gateId);
        public Task<IEnumerable<Gate>> GetGatesByLocationIdAsync(int locationId);
        public void AddGate(Gate gate);
        public void DeleteGate(int gateId);
    }
}
