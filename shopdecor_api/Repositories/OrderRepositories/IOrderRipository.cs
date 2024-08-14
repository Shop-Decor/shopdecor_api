using shopdecor_api.Models.Domain;
using shopdecor_api.Models.DTO.OrderDTO;

namespace shopdecor_api.Repositories.OrderRepositories
{
    public interface IOrderRipository
    {
        Task<IEnumerable<DonHang>> GetAlloderbystatus(byte? status);
        Task<DonHang?> Updateorder(int id, byte status, string? un);
        Task<DonHang?> GetorderAsync(int id);
        Task<DonHang> CreateOrderAsync(CreateOrderDTO orderDto, ApplicationUser applicationUser);
        Task<DonHang?> Updateorderss(int id, byte status, bool statuspay);
        Task<IEnumerable<DonHang>?> GetOtherByIdAccountAndStatusAsync(ApplicationUser account, byte? status);
        Task<DonHang?> GetOtherByIdAccountAndIdOrderAsync(ApplicationUser account, DonHang donHang);

        Task<DonHang?> UpdateOrderStatusVnpAsync(int id);
    }
}
