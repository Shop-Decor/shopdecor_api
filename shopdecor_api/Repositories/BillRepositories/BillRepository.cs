using Microsoft.EntityFrameworkCore;
using shopdecor_api.Data;
using shopdecor_api.Models.Domain;

namespace shopdecor_api.Repositories.BillRepositories
{
    public class BillRepository : IBillRepository
    {
        private readonly SeabugDbContext _db;

        public BillRepository(SeabugDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<HoaDon>> GetAllAsync()
        {
            return await _db.HoaDon.ToListAsync();
        }

        public async Task<HoaDon?> GetByIdAsync(int id)
        {
            return await _db.HoaDon.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
