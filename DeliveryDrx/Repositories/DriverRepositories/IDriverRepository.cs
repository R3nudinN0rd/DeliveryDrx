using DeliveryDrxAPI.Entities;
using Microsoft.Data.SqlClient;

namespace DeliveryDrxAPI.Repositories.DriverRepositories
{
    public interface IDriverRepository
    {
        public Task<IEnumerable<Driver>> GetAllDriversAsync();
        public Task<Driver> GetDriverById(int driverId);
        public Task<Driver> GetDriverByEmailAsync(string email);
        public Task<Driver> GetDriverByPhoneNumberAsync(string phoneNumber);
        public void AddDriver(Driver driver);
        public void UpdateDriver(Driver driver);
        public void DeleteDriver(int id);

    }
}
