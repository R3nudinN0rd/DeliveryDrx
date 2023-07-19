using DeliveryDrxAPI.Context;
using DeliveryDrxAPI.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace DeliveryDrxAPI.Repositories.DriverRepositories
{
    public class DriverRepository : IDriverRepository
    {
        private readonly DeliveryDrxContext _context;

        public DriverRepository(DeliveryDrxContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void AddDriver(Driver driver)
        {
            try
            {
               _context.Drivers.Add(driver);
               _context.SaveChanges();
            }
            catch(SqlException ex)
            {
                throw ex;
            }
        }

        public void DeleteDriver(int id)
        {
            
            Console.WriteLine(id);
            try
            {
                var driver = _context.Drivers.FirstOrDefault(driver => driver.Id == id);
                _context.Drivers.Remove(driver);
                _context.SaveChanges();
            }
            catch(SqlException ex)
            {
                throw ex;
            }

        }

        public async Task<IEnumerable<Driver>> GetAllDriversAsync()
        {
            return await _context.Drivers.ToListAsync();
        }

        public async Task<Driver> GetDriverByEmailAsync(string email)
        {
            var x = await _context.Drivers.FirstOrDefaultAsync(driver => driver.Email == email);
            return x;
        }

        public async Task<Driver> GetDriverById(int driverId)
        {
            return await _context.Drivers.FirstOrDefaultAsync(driver => driver.Id == driverId);
        }

        public async Task<Driver> GetDriverByPhoneNumberAsync(string phoneNumber)
        {
            return await _context.Drivers.FirstOrDefaultAsync(driver => driver.PhoneNumber == phoneNumber);
        }

        public void UpdateDriver(Driver driver)
        {
            try
            {
               _context.Drivers.Update(driver);
               _context.SaveChanges();
                
            }
            catch(SqlException ex)
            {
                throw ex;
            }

        }

    }
}
