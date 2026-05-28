using EasySmart.Data.Entities;

namespace EasySmart.Services.Contracts
{
    public interface IUserSession
    {
        User? CurrentUser { get; }

        bool IsLoggedIn { get; }

        event Action? OnSessionChanged;

        void StartSession(User user);

        void EndSession();
    }
}
