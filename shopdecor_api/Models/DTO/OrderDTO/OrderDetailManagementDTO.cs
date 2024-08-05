using shopdecor_api.Models.DTO.DiscountDTO;
using shopdecor_api.Models.DTO.OrderDetailDTO;

namespace shopdecor_api.Models.DTO.OrderDTO
{
    public class OrderDetailManagementDTO
    {
        public int Id { get; set; }
        public DateTime? NgayHuy { get; set; }
        public string? LyDoHuy { get; set; }
        public int ThanhTien { get; set; }
        // 0. Chờ xách nhận / 1. Đang giao / 2. Đã giao / 3.Đã Hủy
        public byte TTDonHang { get; set; }
        public bool TTThanhToan { get; set; }
        public string? HoTen { get; set; }
        public string? DiaChi { get; set; }
        public string? SDT { get; set; }
        public string? Email { get; set; }
        public DiscountSubForDetailedOrder? Discount { get; set; }
        public List<SubDetailedOrderManagementDTO> Detail { get; set; }
    }
}
