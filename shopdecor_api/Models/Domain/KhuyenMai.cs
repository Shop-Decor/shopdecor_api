using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace shopdecor_api.Models.Domain
{
    public class KhuyenMai
    {
        [Key]
        [Column(TypeName = "Varchar(20)")]
        public string MaGiamGia { get; set; }
        [Column(TypeName = "Nvarchar(max)")]
        public string? MoTa { get; set; }
        public bool? LoaiGiam { get; set; }
        public int MenhGia { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime HSD { get; set; }
        public virtual IEnumerable<SanPham>? SanPhams { get; set; }
        public virtual IEnumerable<DonHang>? DonHangs { get; set; }
    }
}
