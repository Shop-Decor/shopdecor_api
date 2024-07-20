using shopdecor_api.Models.Domain;

namespace shopdecor_api.Repositories.ProductRepositories
{
    public interface IProductRepository
    {
        public Task<IEnumerable<SanPham>> GetAllAsync();
        public Task<SanPham> GetProductsAsync(int id);
        public Task<SanPham> AddProductsAsync(SanPham model);

        public Task UpdateProductsAsync(int id, SanPham model);
        public Task DeleteProductsAsync(int id);
        Task AddImageAsync(Hinh hinh);

    }
}
