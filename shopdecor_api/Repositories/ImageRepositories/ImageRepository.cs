using shopdecor_api.Data;
using shopdecor_api.Models.Domain;

namespace shopdecor_api.Repositories.ImageRepositories
{
    public class ImageRepository : IImageRepository
    {
        private readonly SeabugDbContext _db;

        public ImageRepository(SeabugDbContext db)
        {
            _db = db;
        }
        public async Task<Hinh> AddImageByProductAsync(string img, SanPham product)
        {
            var image = new Hinh
            {
                Link = img,
                SanPham = product
            };
            await _db.Hinh.AddAsync(image);
            await _db.SaveChangesAsync();
            return image;
        }
    }
}
