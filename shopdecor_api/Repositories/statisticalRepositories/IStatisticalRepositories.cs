using shopdecor_api.Models.DTO.StatisticalDTO;

namespace shopdecor_api.Repositories.StatisticalRepositories
{
    public interface IStatisticalRepository
    {
        Task<StatisticalDTO> GetThongKeAsync();
    }
}
