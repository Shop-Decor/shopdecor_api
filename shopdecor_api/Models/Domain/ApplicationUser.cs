using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;

namespace shopdecor_api.Models.Domain
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; } = null!;
        //trạng thái
        public bool Status { get; set; } = true; // true = đang hoạt dộng | false = ngừng hoạt động 
        //Ngày tạo
        public DateOnly DateCreated { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        //Địa chỉ
        public string? Address { get; set; }

    }
}
