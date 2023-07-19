using DeliveryDrxAPI.Context;
using DeliveryDrxAPI.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DeliveryDrxAPI.Repositories.LocationRepositories
{
    public class LocationRepository:ILocationRepository
    {
        private readonly DeliveryDrxContext _context;
        public LocationRepository(DeliveryDrxContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));   
        }

        public void AddLocation(Location location)
        {
            try
            {
                _context.Locations.Add(location);
                _context.SaveChanges();
            }
            catch(SqlException ex)
            {
                throw ex;
            }

        }

        public async void DeleteLocation(int locationId)
        {
            try
            {
                var location = await _context.Locations.FirstOrDefaultAsync(location => location.Id == locationId);
                _context.Locations.Remove(location);
                _context.SaveChanges();
            }
            catch(SqlException ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Location>> GetAllLocationsAsync()
        {
            return await _context.Locations.ToListAsync();
        }

        public async Task<Location> GetLocationByIdAsync(int locationId)
        {
            return await _context.Locations.FirstOrDefaultAsync(location => location.Id == locationId);
        }

        public void UpdateLocation(Location location)
        {
            try
            {
                _context.Locations.Update(location);
                _context.SaveChanges();
            }
            catch(SqlException ex)
            {
                throw ex;
            }
        }
    }
}
