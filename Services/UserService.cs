using EasySmart.Data;
using EasySmart.Data.Entities;
using EasySmart.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace EasySmart.Services
{
    public class UserService(AppDbContext context) : IUserService
    {
        private readonly AppDbContext _context = context;

        public async Task<User?> LoginAsync(string login, string password)
        {
            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
                return null;

            return await _context.Users
                .FirstOrDefaultAsync(u => u.Login == login && u.Password == password);
        }

        public async Task<bool> RegisterAsync(User newUser)
        {
            if (await IsLoginExistsAsync(newUser.Login))
            {
                return false;
            }

            try
            {
                newUser.Role = Data.Enums.UserRole.Buyer;

                await _context.Users.AddAsync(newUser);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при регистрации пользователя: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> IsLoginExistsAsync(string login)
        {
            return await _context.Users.AnyAsync(u => u.Login == login);
        }
    }
}
