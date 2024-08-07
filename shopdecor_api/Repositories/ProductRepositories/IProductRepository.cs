using shopdecor_api.Helper;
using shopdecor_api.Models.Domain;
using shopdecor_api.Models.DTO;

namespace shopdecor_api.Repositories.ProductRepositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<SanPham>> GetAllAsync();
        Task<SanPham> GetProductsAsync(int id);
        Task<SanPham> AddProductsAsync(SanPham model);

        Task<SanPham>? UpdateProductsAsync(int id, SanPham model);
        Task<SanPham>? DeleteProductsAsync(int id);

        Task<List<ProductDetail>> GetProductDetail(int SpId);
        Task<IEnumerable<SanPham>> GetProductsByTypeId(int typeId);
        public Task<SanPham> AddProductDetailAsync(ProductWithDetailsDTO productWithDetails);

        Task<IEnumerable<SanPham>> GetAllProductUsers();

        Task<PagedResult<SanPham>> GetPagedProductsAsync(int? typeId, int page, int pageSize);

    }
}
