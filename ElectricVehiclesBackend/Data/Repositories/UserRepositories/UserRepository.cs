using Data.Context;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.UserRepositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _databaseContext;

        public UserRepository(DatabaseContext databaseContext) 
        {
            _databaseContext = databaseContext;
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _databaseContext.Users.ToListAsync();
        }

        public Task<User> GetUserByIdAsync(int id)
        {
            return _databaseContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<User> GetUserByEmailAsync(string email)
        {
            return _databaseContext.Users.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<User> AddUser(User user)
        {
            _databaseContext.Users.Add(user);
            await SaveChangesAsync();
            return user;
        }

        public async Task<User> RegisterUserAsync(User user)
        {
            _databaseContext.Users.Add(user);
            await SaveChangesAsync();
            return user;
        }

        public async Task<User> LoginUserAsync(User user)
        {
            var loginUser = await _databaseContext.Users.FirstOrDefaultAsync(x => x.Email == user.Email && x.Password == user.Password);
            await SaveChangesAsync();
            return loginUser;
        }

        public async Task<User> UpdateUser(User user)
        {
            _databaseContext.Users.Update(user);
            await SaveChangesAsync();
            return user;
        }

        public async Task<User> DeleteUser(int id)
        { 
            var user = await GetUserByIdAsync(id);
            _databaseContext.Users.Remove(user);
            await SaveChangesAsync();
            return user;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _databaseContext.SaveChangesAsync() > 0;
        }
    }
}
