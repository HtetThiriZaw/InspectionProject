using System.ComponentModel.DataAnnotations;

namespace InspectionProject.Models
{
    public class LoginViewModel
    {
        [Display(Name = "Username")]
        [Required(ErrorMessage = "Enter username.")]
        public string Username { get; set; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Enter password.")]
        public string Password { get; set; }
    }
}