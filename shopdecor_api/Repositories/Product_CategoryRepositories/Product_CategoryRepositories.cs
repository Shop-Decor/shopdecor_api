using Microsoft.EntityFrameworkCore;
using shopdecor_api.Data;
using shopdecor_api.Models.Domain;

namespace shopdecor_api.Repositories.Product_CategoryRepositories
{
    public class Product_CategoryRepositories : IProduct_CategoryRepositories
    {
        private readonly SeabugDbContext _db;

        public Product_CategoryRepositories(SeabugDbContext db)
        {
            _db = db;

        }
        public async Task<List<SanPham_Loai>> GetProductByProductType(int SpId)
        {
            return await _db.SanPham_Loai.Where(x => x.SanPham.Id == SpId).ToListAsync();
        }
    }
}
