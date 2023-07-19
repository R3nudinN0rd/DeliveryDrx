using DeliveryDrxAPI.Entities;
using Microsoft.Data.SqlClient;

namespace DeliveryDrxAPI.Repositories.LocationManagerRepositories
{
    public interface ILocationManagerRepository
    {
        public Task<IEnumerable<LocationManager>> GetAllLocationManagersAsync();
        public Task<LocationManager> GetLocationManagersByIdAsync(int locationManagerId);
        public Task<LocationManager> GetLocationManagerByPhoneNumberAsync(string phoneNumber);
        public void AddLocationManager(LocationManager locationManager);
        public void UpdateLocationManager(LocationManager locationManager);
        public void DeleteLocationManager(int locationManagerId);
    }
}
