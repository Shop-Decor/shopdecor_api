using shopdecor_api.Models.Domain;

namespace shopdecor_api.Repositories.OrderDetailRepositories
{
	public interface IOrderDetailRepository
	{
		Task<IEnumerable<DonHang_ChiTiet>> GetAll(int id);
	}
}
