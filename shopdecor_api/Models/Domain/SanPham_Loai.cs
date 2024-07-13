namespace shopdecor_api.Models.Domain
{
    public class SanPham_Loai
    {
        public int Id { get; set; }
        public virtual LoaiSP? LoaiSP { get; set; }
        public virtual SanPham? SanPham { get; set; }
    }
}
