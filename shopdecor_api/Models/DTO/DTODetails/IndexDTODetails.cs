using shopdecor_api.Models.Domain;

namespace shopdecor_api.Models.DTO
{
    public class IndexDTODetails
    {
        public int Id { get; set; }
        public int Gia { get; set; }
        public int SoLuong { get; set; }
        public string? TenMauSac { get; set; }
        public string? TenKichThuoc { get; set; }
    }
}
