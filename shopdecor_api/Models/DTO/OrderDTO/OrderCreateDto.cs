namespace shopdecor_api.Models.DTO.OrderDTO
{
    public class OrderCreateDto
    {
        public string? HoTen { get; set; }
        public string? DiaChi { get; set; }
        public string? SDT { get; set; }
        public string? Email { get; set; }
        public List<OrderItemDto>? DonHang_ChiTiets { get; set; }
    }
}
