using Microsoft.EntityFrameworkCore;
using shopdecor_api.Data;
using shopdecor_api.Models.Domain;

namespace shopdecor_api.Repositories.OrderRepositories
{
	public class OrderRepository : IOrderRipository
	{
		private readonly SeabugDbContext _db;

		public OrderRepository(SeabugDbContext db)
		{
			_db = db;
		}
		public async Task<IEnumerable<DonHang>> GetAlloderbystatus(byte status)
		{
			return await _db.DonHang.Where(s => s.TTDonHang == status).ToListAsync();
		}
		public async Task<DonHang> GetorderAsync(int id)
		{
			return await _db.DonHang.FirstOrDefaultAsync(s => s.Id == id);
		}
		public async Task<DonHang?> Updateorder(int id, byte status, string? un)
		{

			var exiInt = await _db.DonHang.FirstOrDefaultAsync(s=>s.Id==id);

			

			if (exiInt!=null)
			{
				
				exiInt.TTDonHang=status;
				exiInt.LyDoHuy = un;
				exiInt.NgayHuy = DateTime.Now;
			}
			else
			{
				return null;
			}
		
			await _db.SaveChangesAsync();
			return exiInt;


		}

	}
}
