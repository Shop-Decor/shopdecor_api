using System.ComponentModel.DataAnnotations;

namespace shopdecor_api.Models.DTO.AccountDTO
{
    public class SignUpModel
    {
        [Required]
        public string UserName { get; set; } = null!;
        [Required]
        public string FullName { get; set; } = null!;
        
        [Required, EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
        [Required]
        public string ConfirmPassword { get; set; } = null!;
    }
}
