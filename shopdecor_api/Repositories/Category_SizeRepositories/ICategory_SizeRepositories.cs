using shopdecor_api.Models.Domain;

namespace shopdecor_api.Repositories.Category_SizeRepositories
{
	public interface ICategory_SizeRepositories
	{
		Task<IEnumerable<KichThuoc>> GetAllAsync();
		Task<KichThuoc?> CreateAsync(KichThuoc ktsp);
		Task<KichThuoc?> DeleteAync(int id);
		Task<KichThuoc?> UpdateSize(KichThuoc ktsp);
		Task<KichThuoc?> GetSizeAsync(int id);
	}
}
