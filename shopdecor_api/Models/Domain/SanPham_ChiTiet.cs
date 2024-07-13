namespace shopdecor_api.Models.Domain
{
    public class SanPham_ChiTiet
    {
        public int Id { get; set; }
        public int Gia { get; set; }
        public int SoLuong { get; set; }
        public virtual KichThuoc? KichThuoc { get; set; }
        public virtual MauSac? MauSac { get; set; }
        public virtual SanPham? SanPham { get; set; }
    }
}
