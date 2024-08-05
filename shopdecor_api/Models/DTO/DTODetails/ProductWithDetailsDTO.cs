namespace shopdecor_api.Models.DTO
{
    public class ProductWithDetailsDTO
    {
        public int Id { get; set; }
        public string? Ten { get; set; }
        public string? MoTa { get; set; }
        public DateTime NgayTao { get; set; }
        // 1: đang bán, 0: ngừng bán
        public bool TrangThai { get; set; }
        public List<string>? Hinhs { get; set; }
        public List<IndexDTODetails>? ChiTietSanPham { get; set; }
    }
}
