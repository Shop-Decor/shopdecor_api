using shopdecor_api.Models.Domain;

namespace shopdecor_api.Repositories.BillRepositories
{
    public interface IBillRepository
    {
        Task<IEnumerable<HoaDon>> GetAllAsync();
        Task<HoaDon?> GetByIdAsync(int id);
    }
}
