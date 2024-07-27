using shopdecor_api.Models.Domain;
using shopdecor_api.Models.DTO.ProductDTO;

namespace shopdecor_api.Repositories.ProductRepositories
{
    public interface IProductRepository
    {
        public Task<IEnumerable<SanPham>> GetAllAsync();
        public Task<SanPham> GetProductsAsync(int id);
        public Task<SanPham> AddProductsAsync(SanPham model);

        public Task<SanPham>? UpdateProductsAsync(int id, SanPham model);
        public Task<SanPham>? DeleteProductsAsync(int id);
        Task AddImageAsync(Hinh hinh);
        public Task<List<ProductDetail>> GetProductDetail(int SpId);

    }
}
