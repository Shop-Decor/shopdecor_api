namespace shopdecor_api.Models.Domain
{
    public class DonHang_ChiTiet
    {
        public int Id { get; set; }
        public int SoLuong { get; set; }
        public int GiaSP { get; set; }
        public virtual SanPham? SanPham { get; set; }
        public virtual DonHang? DonHang { get; set; }
    }
}
