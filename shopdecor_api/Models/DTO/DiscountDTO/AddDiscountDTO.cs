namespace shopdecor_api.Models.DTO.DiscountDTO
{
    public class AddDiscountDTO
    {
        public string MaGiamGia { get; set; }
        public string? MoTa { get; set; }
        public bool LoaiGiam { get; set; }
        public int MenhGia { get; set; }
        public DateTime HSD { get; set; }
        public bool LoaiKM { get; set; }
    }
}
