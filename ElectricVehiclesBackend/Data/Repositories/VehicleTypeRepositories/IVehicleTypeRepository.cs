using Entities;

namespace Data.Repositories.VehicleTypeRepositories
{
    public interface IVehicleTypeRepository
    {
        Task<IEnumerable<VehicleType>> GetVehicleTypesAsync();

        Task<VehicleType> GetVehicleTypeByIdAsync(int id);

        Task<VehicleType> GetVehicleTypeByTypeAsync(string type);

        Task<VehicleType> AddVehicleType(VehicleType vehicleType);

        Task<VehicleType> UpdateVehicleType(VehicleType vehicleType);

        Task<VehicleType> DeleteVehicleType(int id);

        Task<bool> SaveChangesAsync();
    }
}
