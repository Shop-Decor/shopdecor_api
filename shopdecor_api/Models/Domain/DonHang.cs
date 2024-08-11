using System.ComponentModel.DataAnnotations.Schema;

namespace shopdecor_api.Models.Domain
{
    public class DonHang
    {
        public int Id { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime? NgayHuy { get; set; }
        [Column(TypeName = "Nvarchar(max)")]
        public string? LyDoHuy { get; set; }
        public int ThanhTien { get; set; }
        // 0. Chờ xách nhận / 1. Đang giao / 2. Đã giao / 3.Đã Hủy
        public byte TTDonHang { get; set; }
        public bool PTThanhToan { get; set; }
        public bool TTThanhToan { get; set; }
        public string? HoTen { get; set; }
        public string? DiaChi { get; set; }
        public string? SDT { get; set; }
        public string? Email { get; set; }
        public virtual ApplicationUser? ApplicationUser { get; set; }
        public virtual KhuyenMai? KhuyenMai { get; set; }
        public virtual IEnumerable<HoaDon>? HoaDons { get; set; }
        public virtual IEnumerable<DonHang_ChiTiet>? DonHang_ChiTiets { get; set; }
    }
}
