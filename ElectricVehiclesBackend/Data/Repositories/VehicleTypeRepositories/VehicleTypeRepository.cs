using Data.Context;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.VehicleTypeRepositories
{
    public class VehicleTypeRepository : IVehicleTypeRepository
    {
        private readonly DatabaseContext _databaseContext;

        public VehicleTypeRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext ?? throw new ArgumentNullException(nameof(databaseContext));
        }

        public async Task<IEnumerable<VehicleType>> GetVehicleTypesAsync()
        {
            return await _databaseContext.VehicleTypes.ToListAsync();
        }

        public async Task<VehicleType> GetVehicleTypeByIdAsync(int id)
        {
            return await _databaseContext.VehicleTypes.FirstOrDefaultAsync(x => x.Id == id); 
        }

        public async Task<VehicleType> GetVehicleTypeByTypeAsync(string type)
        {
            return await _databaseContext.VehicleTypes.FirstOrDefaultAsync(x => x.Type == type);
        }

        public async Task<VehicleType> AddVehicleType(VehicleType vehicleType)
        {
            _databaseContext.Add(vehicleType);
            await SaveChangesAsync();
            return vehicleType;
        }

        public async Task<VehicleType> UpdateVehicleType(VehicleType vehicleType)
        {
            _databaseContext.Update(vehicleType);
            await SaveChangesAsync();
            return vehicleType;
        }

        public async Task<VehicleType> DeleteVehicleType(int id)
        {
            var vehicleType = await GetVehicleTypeByIdAsync(id);
            _databaseContext.VehicleTypes.Remove(vehicleType);
            await SaveChangesAsync();
            return vehicleType;
        }      

        public async Task<bool> SaveChangesAsync()
        {
            return await _databaseContext.SaveChangesAsync() > 0;
        }  
    }
}
