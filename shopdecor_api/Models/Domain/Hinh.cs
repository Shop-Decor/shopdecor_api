using System.ComponentModel.DataAnnotations.Schema;

namespace shopdecor_api.Models.Domain
{
    public class Hinh
    {
        public int Id { get; set; }

        [Column(TypeName = "Varchar(max)")]
        public string? Link { get; set; }
        public virtual SanPham? SanPham { get; set; }
    }
}
