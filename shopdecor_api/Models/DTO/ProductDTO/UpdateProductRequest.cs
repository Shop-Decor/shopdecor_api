namespace shopdecor_api.Models.DTO.ProductDTO
{
    public class UpdateProductRequest
    {
        public string? Ten { get; set; }
        public string? MoTa { get; set; }
        //1:đang bán, 0:ngừng bán
        public bool TrangThai { get; set; }
        public string? MaGiamGia { get; set; }
        public List<string>? Imgs { get; set; }
    }
}
