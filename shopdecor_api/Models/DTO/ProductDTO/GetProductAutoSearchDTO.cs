using shopdecor_api.Models.DTO.DiscountDTO;

namespace shopdecor_api.Models.DTO.ProductDTO
{
    public class GetProductAutoSearchDTO
    {
        public int Id { get; set; }
        public string? Ten { get; set; }
        public SubDiscountAutoSearch? KhuyenMai { get; set; }
        public string? Hinh { get; set; }
        public int Gia { get; set; }
    }
}
