using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ToDoSite2.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]    
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage ="Пароли не совпадают")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтвердите пароль")]
        public string ConfirmPassword { get; set;}


    }
}
