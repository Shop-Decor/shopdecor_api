using Microsoft.EntityFrameworkCore;
using shopdecor_api.Data;
using shopdecor_api.Models.Domain;

namespace shopdecor_api.Repositories.OrderDetailRepositories
{
	public class OrderDetailRepository : IOrderDetailRepository
	{
		private readonly SeabugDbContext _db;

		public OrderDetailRepository(SeabugDbContext db)
		{
			_db = db;
		}
		public async Task<IEnumerable<DonHang_ChiTiet>> GetAll(int id)
		{
			return await _db.DonHang_ChiTiet.Where(s=>s.DonHang.Id==id).ToListAsync();
		}
		
	}
}
