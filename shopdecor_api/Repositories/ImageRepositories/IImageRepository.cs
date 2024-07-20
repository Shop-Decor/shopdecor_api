using shopdecor_api.Models.Domain;

namespace shopdecor_api.Repositories.ImageRepositories
{
    public interface IImageRepository
    {
        Task<Hinh> AddImageByProductAsync(string img, SanPham product);
    }
}
