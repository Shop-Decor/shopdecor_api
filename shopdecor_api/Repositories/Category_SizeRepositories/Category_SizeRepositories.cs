using Microsoft.EntityFrameworkCore;
using shopdecor_api.Data;
using shopdecor_api.Models.Domain;

namespace shopdecor_api.Repositories.Category_SizeRepositories
{
	public class Category_SizeRepositories : ICategory_SizeRepositories
	{
		private readonly SeabugDbContext _db;

		public Category_SizeRepositories(SeabugDbContext db)
		{
			_db = db;
		}
		public async Task<IEnumerable<KichThuoc>> GetAllAsync()
		{
			return await _db.KichThuoc.ToListAsync();
		}

		public async Task<KichThuoc?> CreateAsync(KichThuoc ktsp)
		{
			await _db.KichThuoc.AddAsync(ktsp);
			await _db.SaveChangesAsync();
			return ktsp;
		}

		public async Task<KichThuoc> DeleteAync(int id)
		{
			var exiintkt = await _db.KichThuoc.FindAsync(id);
			if (exiintkt != null)
			{
				_db.KichThuoc.Remove(exiintkt);
				await _db.SaveChangesAsync();
				return exiintkt;
			}
			return null;
		}
		public async Task<KichThuoc> GetSizeAsync(int id)
		{
			return await _db.KichThuoc.FirstOrDefaultAsync(s => s.Id == id);
		}
		public async Task<KichThuoc?> UpdateSize(KichThuoc ktsp)
		{
			var exiIntLoai = await _db.KichThuoc.FirstOrDefaultAsync(l => l.Id == ktsp.Id);
			if (exiIntLoai == null)
			{
				return null;
			}

			_db.Entry(exiIntLoai).CurrentValues.SetValues(ktsp);
			await _db.SaveChangesAsync();
			return ktsp;
		}


	}
}
