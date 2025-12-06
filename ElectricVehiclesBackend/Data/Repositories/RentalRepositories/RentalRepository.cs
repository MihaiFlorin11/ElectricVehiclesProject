using Data.Context;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.RentalRepositories
{
    public class RentalRepository : IRentalRepository
    {
        private readonly DatabaseContext _databaseContext;

        public RentalRepository(DatabaseContext databaseContext) 
        {
            _databaseContext = databaseContext;
        }

        public async Task<IEnumerable<Rental>> GetRentalsAsync()
        {
           return await _databaseContext.Rentals.OrderBy(x => x.VehicleId).ToListAsync();
        }

        public async Task<Rental> GetRentalByIdAsync(int id)
        {
            return await _databaseContext.Rentals.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Rental> AddRental(Rental rental)
        {
            _databaseContext.Rentals.Add(rental);
            await SaveChangesAsync();
            return rental;
        }

        public async Task<Rental> UpdateRental(Rental rental)
        {
            _databaseContext.Rentals.Update(rental);
            await SaveChangesAsync();
            return rental;
        }

        public async Task<Rental> DeleteRental(int id)
        {
            var rental = await GetRentalByIdAsync(id);
            _databaseContext.Rentals.Remove(rental);
            await SaveChangesAsync();
            return rental;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _databaseContext.SaveChangesAsync() > 0;
        }
    }
}
