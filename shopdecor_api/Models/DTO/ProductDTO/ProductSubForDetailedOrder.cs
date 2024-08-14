using shopdecor_api.Models.DTO.DiscountDTO;
using shopdecor_api.Models.DTO.Product_DetailDTO;

namespace shopdecor_api.Models.DTO.ProductDTO
{
    public class ProductSubForDetailedOrder
    {
        public int Id { get; set; }
        public string? Ten { get; set; }
        public string? hinh { get; set; }
        public SubDiscountAutoSearch Discount { get; set; }
        public List<SubProductDetail> PrDetail { get; set; }
    }
}
