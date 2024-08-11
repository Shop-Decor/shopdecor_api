using System.ComponentModel.DataAnnotations;

namespace shopdecor_api.Models.DTO.AccountDTO
{
    public class ChangePasswordModel
    {

        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
