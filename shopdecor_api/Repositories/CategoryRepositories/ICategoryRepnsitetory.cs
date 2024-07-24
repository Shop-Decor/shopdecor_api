using shopdecor_api.Models.Domain;

namespace shopdecor_api.Repositories.CategoryRepositories
{
	public interface ICategoryRepnsitetory
	{
		Task<IEnumerable<LoaiSP>> GetAllAsync();
		Task<LoaiSP?> CreateAsync(LoaiSP loaisp);
		Task<LoaiSP?> DeleteAync(int id);
		Task<LoaiSP?> UpdatePType(LoaiSP loaisp);
		Task<LoaiSP?> GetLoaiSPAsync(int id);
	}
}
