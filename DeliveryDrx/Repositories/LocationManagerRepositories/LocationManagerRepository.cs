using DeliveryDrxAPI.Context;
using DeliveryDrxAPI.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DeliveryDrxAPI.Repositories.LocationManagerRepositories
{
    public class LocationManagerRepository:ILocationManagerRepository
    {
        private readonly DeliveryDrxContext _context;
        public LocationManagerRepository(DeliveryDrxContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void AddLocationManager(LocationManager locationManager)
        {
            try
            {
                _context.LocationManagers.Add(locationManager);
                _context.SaveChanges();
            }
            catch(SqlException ex)
            {
                throw ex;
            }

        }

        public async void DeleteLocationManager(int locationManagerId)
        {
            try
            {
                var locationManager = await _context.LocationManagers.FirstOrDefaultAsync(lm => lm.Id == locationManagerId);
                _context.LocationManagers.Remove(locationManager);
                _context.SaveChanges();
            }
            catch(SqlException ex)
            {
                throw ex;
            }

        }

        public async Task<IEnumerable<LocationManager>> GetAllLocationManagersAsync()
        {
            return await _context.LocationManagers.ToListAsync();
        }

        public async Task<LocationManager> GetLocationManagerByPhoneNumberAsync(string phoneNumber)
        {
            return await _context.LocationManagers.FirstOrDefaultAsync(lm => lm.PhoneNumber == phoneNumber);
        }

        public async Task<LocationManager> GetLocationManagersByIdAsync(int locationManagerId)
        {
            return await _context.LocationManagers.FirstOrDefaultAsync(lm => lm.Id == locationManagerId);
        }

        public void UpdateLocationManager(LocationManager locationManager)
        {
            try
            {
                _context.LocationManagers.Update(locationManager);
                _context.SaveChanges();
            }
            catch(SqlException ex)
            {
                throw ex;
            }
        }
    }
}
