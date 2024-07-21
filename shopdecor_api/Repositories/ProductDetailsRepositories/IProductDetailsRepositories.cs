using shopdecor_api.Models.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace shopdecor_api.Repositories.ProductDetailsRepositories
{
    public interface IProductDetailsRepositories
    {
        Task<IEnumerable<SanPham_ChiTiet>> GetAllAsync();
        Task<SanPham_ChiTiet> GetByIdAsync(int id);
        Task AddAsync(SanPham_ChiTiet productDetail);
        Task UpdateAsync(SanPham_ChiTiet productDetail);
        Task DeleteAsync(int id);
    }

}
