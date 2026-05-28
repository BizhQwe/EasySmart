using EasySmart.Data.Entities;
using EasySmart.Services.Contracts;

namespace EasySmart.Services
{
    public class UserSession : IUserSession
    {
        public User? CurrentUser { get; private set; }

        public bool IsLoggedIn => CurrentUser != null;

        public event Action? OnSessionChanged;

        public void StartSession(User user)
        {
            CurrentUser = user;
            NotifyStateChanged();
        }

        public void EndSession()
        {
            CurrentUser = null;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnSessionChanged?.Invoke();
    }
}