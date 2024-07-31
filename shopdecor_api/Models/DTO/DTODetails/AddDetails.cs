using shopdecor_api.Models.Domain;
namespace shopdecor_api.Models.DTO
{
    public class AddDetails
    {
        public int Gia { get; set; }
        public int SoLuong { get; set; }
        public int KichThuocId { get; set; }
        public int MauSacId { get; set; }
        public int SanPhamId { get; set; }
    }
}
