using shopdecor_api.Models.Domain;

namespace shopdecor_api.Repositories.ProductDetailsRepositories
{
    public interface IProductDetailsRepositories
    {
        Task<IEnumerable<SanPham_ChiTiet>> GetAllAsync();
        Task<SanPham_ChiTiet> GetByIdAsync(int id);
        Task AddAsync(SanPham_ChiTiet productDetail);
        Task UpdateAsync(SanPham_ChiTiet productDetail);
        Task DeleteAsync(int id);
        //Task<SanPham_ChiTiet> GetProductsDetailbyproduct(int SpId);

    }

}
