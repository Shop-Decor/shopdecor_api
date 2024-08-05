using shopdecor_api.Models.DTO.ProductDTO;

namespace shopdecor_api.Models.DTO.OrderDetailDTO
{
    public class SubDetailedOrderManagementDTO
    {
        public int Id { get; set; }
        public int SoLuong { get; set; }
        public int GiaSP { get; set; }
        public string? MauSac { get; set; }
        public string? KichThuoc { get; set; }
        public ProductSubForDetailedOrder Product { get; set; }
    }
}
