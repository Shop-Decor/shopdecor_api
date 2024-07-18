using System.ComponentModel.DataAnnotations.Schema;

namespace shopdecor_api.Models.Domain
{
    public class Hinh
    {
        public int Id { get; set; }

        [Column(TypeName = "Varchar(max)")]
        public string? TenHinh { get; set; }

        public int SanPhamId { get; set; } // This property is important to link to SanPham

        [ForeignKey("SanPhamId")]
        public virtual SanPham? SanPham { get; set; }
    }
}
