namespace shopdecor_api.Models.DTO.DiscountDTO
{
    public class UpdateDiscountDTO
    {
        public string? MoTa { get; set; }
        public bool LoaiGiam { get; set; }
        public int MenhGia { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime HSD { get; set; }
    }
}
