using EasySmart.Data.Enums;

namespace EasySmart.Data.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string Login { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public UserRole Role { get; set; } = UserRole.Buyer;

        public virtual ICollection<Order> Orders { get; set; } = [];
    }
}
