using System.ComponentModel.DataAnnotations;

namespace shopdecor_api.Models.DTO.AccountDTO
{
    public class EditAccount
    {
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Address { get; set; } = null!;
    }
}
