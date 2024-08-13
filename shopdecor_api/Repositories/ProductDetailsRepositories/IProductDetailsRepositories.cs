using shopdecor_api.Models.Domain;
using shopdecor_api.Models.DTO;

namespace shopdecor_api.Repositories.ProductDetailsRepositories
{
    public interface IProductDetailsRepositories
    {
        Task<IEnumerable<SanPham_ChiTiet>> GetAllAsync();
        Task<SanPham_ChiTiet> GetByIdAsync(int id);
        Task AddAsync(SanPham_ChiTiet productDetail);
        Task UpdateAsync(SanPham_ChiTiet productDetail);
        Task DeleteAsync(int id);
        Task<List<SanPham_ChiTiet>> GetProductsDetailbyproduct(int SpId);
        Task<IEnumerable<ProductDetailDTO>> GetAllProductDetailsAsync();
    }

}
