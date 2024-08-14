namespace shopdecor_api.Models.DTO.Product_DetailDTO
{
    public class DTODetails
    {
        public int Id { get; set; }
        public int Gia { get; set; }
        public int SoLuong { get; set; }
        public int SizeId { get; set; }
        public string? Size { get; set; }
        public int ColorId { get; set; }
        public string? Color { get; set; }
    }
}
