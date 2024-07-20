namespace shopdecor_api.Models.DTO.ProductDTO
{
    public class AddProductRequest
    {
        public string? Ten { get; set; }
        public string? MoTa { get; set; }
        public string? MaGiamGia { get; set; }
        public List<string>? Img { get; set; }
    }
}
