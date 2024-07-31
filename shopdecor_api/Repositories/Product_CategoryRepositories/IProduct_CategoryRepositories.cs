using shopdecor_api.Models.Domain;

namespace shopdecor_api.Repositories.Product_CategoryRepositories
{
    public interface IProduct_CategoryRepositories
    {
        public Task<List<SanPham_Loai>> GetProductByProductType(int SpId);
    }
}
