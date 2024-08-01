using System.ComponentModel.DataAnnotations.Schema;

namespace shopdecor_api.Models.Domain
{
    public class SanPham
    {
        public int Id { get; set; }
        [Column(TypeName = "Nvarchar(200)")]
        public string? Ten { get; set; }
        [Column(TypeName = "Nvarchar(max)")]
        public string? MoTa { get; set; }
        public DateTime NgayTao { get; set; }
        //1:đang bán, 0:ngừng bán
        public bool TrangThai { get; set; }
        public virtual KhuyenMai? KhuyenMai { get; set; }
        public virtual IEnumerable<SanPham_Loai>? SanPham_Loais { get; set; }
        public virtual IEnumerable<Hinh>? Hinhs { get; set; }
        public virtual IEnumerable<DonHang_ChiTiet>? DonHang_ChiTiets { get; set; }
        public virtual IEnumerable<SanPham_ChiTiet>? SanPham_ChiTiets { get; set; }
    }
}
