namespace shopdecor_api.Models.DTO.Product_DetailDTO
{
    public class ProductDetailDTO
    {
        public int ProductId { get; set; }
        public List<ProductDTODetail>? ChiTietSanPham { get; set; }
    }

    public class ProductDTODetail
    {
        public string? Color { get; set; }
        public string? Size { get; set; }
        public int Quantity { get; set; }
    }
}
