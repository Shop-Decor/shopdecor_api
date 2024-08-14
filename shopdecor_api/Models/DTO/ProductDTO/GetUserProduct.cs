namespace shopdecor_api.Models.DTO.ProductDTO
{
    public class GetUserProduct
    {
        public int Id { get; set; }
        public string? Ten { get; set; }
        //1:đang bán, 0:ngừng bán
        public DateTime NgayTao { get; set; }
        public string? Hinh { get; set; }
        public int gia { get; set; }
        public List<string>? ColorName { get; set; }
        public string? Color { get; set; }
        public string? MaGiamGia { get; set; }
        public bool LoaiGiam { get; set; }
        public int MenhGia { get; set; }
        public string? Size { get; set; }
        public int TotalCount { get; set; }
    }
}
