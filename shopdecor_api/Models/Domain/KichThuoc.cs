using System.ComponentModel.DataAnnotations.Schema;

namespace shopdecor_api.Models.Domain
{
    public class KichThuoc
    {
        public int Id { get; set; }
        [Column(TypeName = "Varchar(20)")]
        public string? TenKichThuoc { get; set; }
        public virtual IEnumerable<SanPham_ChiTiet>? SanPham_ChiTiets { get; set; }
    }
}
