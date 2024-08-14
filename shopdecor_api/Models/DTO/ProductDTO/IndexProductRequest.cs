namespace shopdecor_api.Models.DTO.ProductDTO
{
    public class IndexProductRequest
    {
        public int Id { get; set; }
        public string? Ten { get; set; }
        public string? MoTa { get; set; }
        public DateTime NgayTao { get; set; }
        public string? TenKhongTiengViet { get; set; }
        //1:đang bán, 0:ngừng bán
        public bool TrangThai { get; set; }
        public List<string>? Hinhs { get; set; }
    }
}
