using Entities;

namespace Data.Repositories.UserRepositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsersAsync();

        Task<User> GetUserByIdAsync(int id);

        Task<User> GetUserByEmailAsync(string email);

        Task<User> AddUser(User user);

        Task<User> RegisterUserAsync(User user);

        Task<User> LoginUserAsync(User user);

        Task<User> UpdateUser(User user);

        Task<User> DeleteUser(int id);

        Task<bool> SaveChangesAsync();
    }
}
