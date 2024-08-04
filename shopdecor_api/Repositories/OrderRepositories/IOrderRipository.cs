using shopdecor_api.Models.Domain;
using shopdecor_api.Models.DTO.OrderDTO;

namespace shopdecor_api.Repositories.OrderRepositories
{
    public interface IOrderRipository
	{
		Task<IEnumerable<DonHang>> GetAlloderbystatus(byte status);
		Task<DonHang?> Updateorder(int id, byte status, string? un);
		Task<DonHang?> GetorderAsync(int id);

        Task<bool> CreateOrderAsync(CreateOrderDTO orderDto);

    }
}
