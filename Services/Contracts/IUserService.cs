using EasySmart.Data.Entities;

namespace EasySmart.Services.Contracts
{
    public interface IUserService
    {
        Task<User?> LoginAsync(string login, string password);

        Task<bool> RegisterAsync(User newUser);

        Task<bool> IsLoginExistsAsync(string login);
    }
}
