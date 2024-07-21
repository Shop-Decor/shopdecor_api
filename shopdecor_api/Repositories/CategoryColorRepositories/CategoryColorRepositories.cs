using Microsoft.EntityFrameworkCore;
using shopdecor_api.Data;
using shopdecor_api.Models.Domain;

namespace shopdecor_api.Repositories.CategoryColorRepositories
{
	public class CategoryColorRepositories : ICategoryColorRepositories
	{
		private readonly SeabugDbContext _db;

		public CategoryColorRepositories(SeabugDbContext db)
		{
			_db = db;
		}
		public async Task<IEnumerable<MauSac>> GetAllAsync()
		{
			return await _db.MauSac.ToListAsync();
		}

		public async Task<MauSac?> CreateAsync(MauSac mssp)
		{
			await _db.MauSac.AddAsync(mssp);
			await _db.SaveChangesAsync();
			return mssp;
		}

		public async Task<MauSac> DeleteAync(int id)
		{
			var exiintms = await _db.MauSac.FindAsync(id);
			if (exiintms != null)
			{
				_db.MauSac.Remove(exiintms);
				await _db.SaveChangesAsync();
				return exiintms;
			}
			return null;
		}
		public async Task<MauSac> GetColorAsync(int id)
		{
			return await _db.MauSac.FirstOrDefaultAsync(s => s.Id == id);
		}
		public async Task<MauSac?> UpdateColor(MauSac ktsp)
		{
			var exiIntLoai = await _db.MauSac.FirstOrDefaultAsync(l => l.Id == ktsp.Id);
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
