using shopdecor_api.Models.Domain;

namespace shopdecor_api.Repositories.ProductRepositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<SanPham>> GetAllAsync();
    }
}
