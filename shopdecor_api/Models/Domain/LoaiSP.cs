using System.ComponentModel.DataAnnotations.Schema;

namespace shopdecor_api.Models.Domain
{
    public class LoaiSP
    {
        public int Id { get; set; }
        [Column(TypeName = "Nvarchar(100)")]
        public string? TenLoai { get; set; }
        public virtual IEnumerable<SanPham_Loai>? SanPham_Loais { get; set; }
    }
}
