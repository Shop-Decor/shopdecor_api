using shopdecor_api.Models.DTO.ColorDTO;
using shopdecor_api.Models.DTO.SizeDTO;

namespace shopdecor_api.Models.DTO.ProductDetailDTO
{
    public class SubProductDetail
    {
        public int Gia { get; set; }
        public SubColor? Color { get; set; }
        public SubSize? Size { get; set; }
    }
}
