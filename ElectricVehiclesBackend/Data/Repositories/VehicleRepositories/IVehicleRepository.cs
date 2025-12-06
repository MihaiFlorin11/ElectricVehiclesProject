using Entities;

namespace Data.Repositories.VehicleRepositories
{
    public interface IVehicleRepository
    {
        Task<IEnumerable<Vehicle>> GetVehiclesAsync();

        Task<Vehicle> GetVehicleByIdAsync(int id);

        Task<Vehicle> AddVehicle(Vehicle vehicle);

        Task<Vehicle> UpdateVehicle(Vehicle vehicle);

        Task<Vehicle> DeleteVehicle(int id);

        Task<bool> SaveChangesAsync();
    }
}
