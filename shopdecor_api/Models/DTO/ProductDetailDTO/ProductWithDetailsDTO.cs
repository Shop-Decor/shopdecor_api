namespace shopdecor_api.Models.DTO.ProductDetailDTO
{
    public class ProductWithDetailsDTO
    {
        public int Id { get; set; }
        public string? Ten { get; set; }
        public string? MoTa { get; set; }
        public DateTime NgayTao { get; set; }
        // 1: đang bán, 0: ngừng bán
        public bool TrangThai { get; set; }
        public List<string>? hinhs { get; set; }
        public List<IndexDTODetails>? ChiTietSanPham { get; set; }
    }
}
