namespace shopdecor_api.Models.DTO.OrderDTO
{
    public class OrderItemDto
    {
        public int SanPhamId { get; set; }
        public int SoLuong { get; set; }
        public int GiaSP { get; set; }
        public string? MauSac { get; set; }
        public string? KichThuoc { get; set; }
    }
}
