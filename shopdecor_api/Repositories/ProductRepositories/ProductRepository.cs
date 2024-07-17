using Microsoft.EntityFrameworkCore;
using shopdecor_api.Data;
using shopdecor_api.Models.Domain;

namespace shopdecor_api.Repositories.ProductRepositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly SeabugDbContext _db;

        public ProductRepository(SeabugDbContext db)
        {
            _db = db;
        }
        public async Task<IEnumerable<SanPham>> GetAllAsync()
        {
            return await _db.SanPham.ToListAsync();
        }
    }
}
