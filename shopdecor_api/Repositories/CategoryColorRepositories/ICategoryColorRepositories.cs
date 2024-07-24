using shopdecor_api.Models.Domain;

namespace shopdecor_api.Repositories.CategoryColorRepositories
{
	public interface ICategoryColorRepositories
	{
		Task<IEnumerable<MauSac>> GetAllAsync();
		Task<MauSac?> CreateAsync(MauSac mssp);
		Task<MauSac?> DeleteAync(int id);
		Task<MauSac?> UpdateColor(MauSac ktsp);
		Task<MauSac?> GetColorAsync(int id);
	}
}
