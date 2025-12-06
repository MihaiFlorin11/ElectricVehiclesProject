using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.RentalRepositories
{
    public interface IRentalRepository
    {
        Task<IEnumerable<Rental>> GetRentalsAsync();

        Task<Rental> GetRentalByIdAsync(int id);

        Task<Rental> AddRental(Rental rental);

        Task<Rental> UpdateRental(Rental rental);

        Task<Rental> DeleteRental(int id);

        Task<bool> SaveChangesAsync();
    }
}
