namespace shopdecor_api.Models.DTO.ProductDTO
{
    public class GetUserProduct
    {
        public int Id { get; set; }
        public string? Ten { get; set; }
        //1:đang bán, 0:ngừng bán
        public bool TrangThai { get; set; }
        public string? Hinh { get; set; }
        public int gia { get; set; }
        public List<int>? Colors { get; set; }

    }
}
