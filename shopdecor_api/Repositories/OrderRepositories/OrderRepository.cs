using Microsoft.EntityFrameworkCore;
using shopdecor_api.Data;
using shopdecor_api.Models.Domain;
using shopdecor_api.Models.DTO.OrderDTO;

namespace shopdecor_api.Repositories.OrderRepositories
{
    public class OrderRepository : IOrderRipository
	{
		private readonly SeabugDbContext _db;

		public OrderRepository(SeabugDbContext db)
		{
			_db = db;
		}

        public async Task<DonHang> CreateOrderAsync(OrderCreateDto orderDto)
        {
            if (orderDto == null)
            {
                throw new ArgumentNullException(nameof(orderDto));
            }

            var order = new DonHang
            {
                NgayTao = DateTime.Now,
                ThanhTien = orderDto.DonHang_ChiTiets.Sum(item => item.GiaSP * item.SoLuong),
                TTDonHang = 0, // Trạng thái ban đầu: Chờ xách nhận
                TTThanhToan = false, // Trạng thái thanh toán
                HoTen = orderDto.HoTen,
                DiaChi = orderDto.DiaChi,
                SDT = orderDto.SDT,
                Email = orderDto.Email
            };

            await _db.DonHang.AddAsync(order);
            await _db.SaveChangesAsync();

            foreach (var item in orderDto.DonHang_ChiTiets)
            {
                var orderDetail = new DonHang_ChiTiet
                {
                    SoLuong = item.SoLuong,
                    GiaSP = item.GiaSP,
                    MauSac = item.MauSac,
                    KichThuoc = item.KichThuoc
                };

                await _db.AddAsync(orderDetail);
            }

            await _db.SaveChangesAsync();

            return order;
        }
    

        public async Task<IEnumerable<DonHang>> GetAlloderbystatus(byte status)
		{
			return await _db.DonHang.Where(s => s.TTDonHang == status).ToListAsync();
		}
		public async Task<DonHang> GetorderAsync(int id)
		{
			return await _db.DonHang.FirstOrDefaultAsync(s => s.Id == id);
		}

        public async Task<DonHang> GetOrderByIdAsync(int id)
        {
            return await _db.DonHang
           .Include(o => o.DonHang_ChiTiets)
           .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<DonHang?> Updateorder(int id, byte status, string? un)
		{

			var exiInt = await _db.DonHang.FirstOrDefaultAsync(s=>s.Id==id);

			

			if (exiInt!=null)
			{
				
				exiInt.TTDonHang=status;
				exiInt.LyDoHuy = un;
				exiInt.NgayHuy = DateTime.Now;
			}
			else
			{
				return null;
			}
		
			await _db.SaveChangesAsync();
			return exiInt;


		}

	}
}
