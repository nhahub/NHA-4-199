using System.ComponentModel.DataAnnotations;

namespace HRManagementSystem.Web.ViewModels
{
    public class LogInViewModel
    {
        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        [Required]
        public required string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
