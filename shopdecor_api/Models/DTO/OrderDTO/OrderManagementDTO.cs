using shopdecor_api.Models.DTO.OrderDetailDTO;

namespace shopdecor_api.Models.DTO.OrderDTO
{
    public class OrderManagementDTO
    {
        public int Id { get; set; }
        public int ThanhTien { get; set; }
        // 0. Chờ xách nhận / 1. Đang giao / 2. Đã giao / 3.Đã Hủy
        public byte TTDonHang { get; set; }
        public List<SubDetailedOrderManagementDTO> Detail { get; set; }
    }
}
