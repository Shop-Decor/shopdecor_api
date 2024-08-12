using shopdecor_api.Models.Domain;

namespace shopdecor_api.Repositories.DiscountRepositories
{
    public interface IDiscountRepository
    {
        Task<IEnumerable<KhuyenMai>> GetAllAsync();
        Task<KhuyenMai>  GetAsync(string maGiamGia);

        Task<KhuyenMai> AddAsync(KhuyenMai khuyenMai);
        Task<KhuyenMai?> UpdateAsync(KhuyenMai khuyenMai, string maGiamGia);
        Task<KhuyenMai> DeleteAsync (string maGiamGia);
        Task<bool> DiscountExist(string maGiamGia);
        IQueryable<KhuyenMai> GetQueryable();
    }
}
