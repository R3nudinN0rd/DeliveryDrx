using AutoMapper;
using DeliveryDrxAPI.Context;
using DeliveryDrxAPI.Entities;
using DeliveryDrxAPI.Mapper.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DeliveryDrxAPI.Repositories.GateRepository
{
    public class GateRepository:IGateRepository
    {
        private readonly DeliveryDrxContext _context;
        public GateRepository(DeliveryDrxContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void AddGate(Gate gate)
        {
            try
            {
                _context.Gates.Add(gate);
                _context.SaveChanges();
            }
            catch(SqlException ex)
            {
                throw ex;
            }

        }

        public async void DeleteGate(int gateId)
        {
            try
            {
                var gate = await _context.Gates.FirstOrDefaultAsync(gate => gate.Id == gateId);
                _context.Gates.Remove(gate);
                _context.SaveChanges();
            }
            catch(SqlException ex)
            {
                throw ex;
            }

        }

        public async Task<IEnumerable<Gate>> GetAllGatesAsync()
        {
            return await _context.Gates.ToListAsync();
        }

        public async Task<Gate> GetGateByIdAsync(int gateId)
        {
            return await _context.Gates.FirstOrDefaultAsync(gate => gate.Id == gateId);
        }

        public async Task<IEnumerable<Gate>> GetGatesByLocationIdAsync(int locationId)
        {
            return await _context.Gates.Where(gate => gate.LocationId == locationId).ToListAsync();
        }
    }
}
