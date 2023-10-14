using System.ComponentModel.DataAnnotations;

namespace ToDoSite2.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name ="Email")]
        public string Email {  get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name ="Пароль")]
        public string Password { get; set; }

        [Display(Name ="Запомнить?")]
        public bool RememberMe { get; set; }

        public string? ReturnUrl {  get; set; }

    }
}
