using System.ComponentModel.DataAnnotations;

namespace zabawa_z_gitem.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Wprowadz email")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Wprowadz hasło")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(100,ErrorMessage = "Minimalna dlugosc to 6 znaków", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Hasla nie sa identyczne")]
        public string ConfirmPassword { get; set; }
    }
}