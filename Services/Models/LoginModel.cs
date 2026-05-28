using System.ComponentModel.DataAnnotations;

namespace EasySmart.Services.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Введите логин")]
        public string Login { get; set; } = string.Empty;

        [Required(ErrorMessage = "Введите пароль")]
        public string Password { get; set; } = string.Empty;
    }
}
