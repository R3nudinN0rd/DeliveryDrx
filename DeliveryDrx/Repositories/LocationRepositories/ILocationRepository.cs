using DeliveryDrxAPI.Entities;
using Microsoft.Data.SqlClient;

namespace DeliveryDrxAPI.Repositories.LocationRepositories
{
    public interface ILocationRepository
    {
        public Task<IEnumerable<Location>> GetAllLocationsAsync();
        public Task<Location> GetLocationByIdAsync(int locationId);
        public void AddLocation(Location location);
        public void UpdateLocation(Location location);
        public void DeleteLocation(int locationId);
    }
}
