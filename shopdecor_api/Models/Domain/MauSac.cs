using System.ComponentModel.DataAnnotations.Schema;

namespace shopdecor_api.Models.Domain
{
    public class MauSac
    {
        public int Id { get; set; }
        [Column(TypeName = "Nvarchar(20)")]
        public string? TenMauSac { get; set; }
        public virtual IEnumerable<SanPham_ChiTiet>? SanPham_ChiTiets { get; set; }
    }
}
