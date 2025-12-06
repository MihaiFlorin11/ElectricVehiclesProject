using Data.Context;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.VehicleRepositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly DatabaseContext _databaseContext;

        public VehicleRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<IEnumerable<Vehicle>> GetVehiclesAsync()
        {
            return await _databaseContext.Vehicles.ToListAsync();
        }

        public async Task<Vehicle> GetVehicleByIdAsync(int id)
        {
            return await _databaseContext.Vehicles.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Vehicle> AddVehicle(Vehicle vehicle)
        {
            _databaseContext.Vehicles.Add(vehicle);
            await SaveChangesAsync();
            return vehicle;
        }

        public async Task<Vehicle> UpdateVehicle(Vehicle vehicle)
        {
            _databaseContext.Vehicles.Update(vehicle);
            await SaveChangesAsync();
            return vehicle;

        }

        public async Task<Vehicle> DeleteVehicle(int id)
        {
            var vehicle = await GetVehicleByIdAsync(id);
            _databaseContext.Vehicles.Remove(vehicle);
            await SaveChangesAsync();
            return vehicle;
        }
        
        public async Task<bool> SaveChangesAsync()
        {
            return await _databaseContext.SaveChangesAsync() > 0;
        }
    }
}
