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

        public async Task<bool> CreateOrderAsync(CreateOrderDTO orderDto)
        {
            var donHang = new DonHang
            {
                HoTen = orderDto.HoTen,
                DiaChi = orderDto.DiaChi,
                SDT = orderDto.SDT,
                Email = orderDto.Email,
                NgayTao = DateTime.UtcNow,
                TTDonHang = 0,
                TTThanhToan = orderDto.TTThanhToan,
                ThanhTien = orderDto.ThanhTien,
            };
            await _db.DonHang.AddAsync(donHang);
            foreach (var x in orderDto.OrderDetails)
            {
                var sp = await _db.SanPham.FirstOrDefaultAsync(z => z.Id == x.SanPhamId);
                var spct = new DonHang_ChiTiet()
                {
                    SanPham = sp,
                    SoLuong = x.SoLuong,
                    KichThuoc = x.KichThuoc,
                    MauSac = x.MauSac,
                    GiaSP = x.GiaSP,
                    DonHang = donHang
                };
                await _db.DonHang_ChiTiet.AddAsync(spct);
            }

            return await _db.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<DonHang>> GetAlloderbystatus(byte status)
        {
            return await _db.DonHang.Where(s => s.TTDonHang == status).ToListAsync();
        }

        public async Task<DonHang?> GetorderAsync(int id)
        {
            return await _db.DonHang.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<DonHang>?> GetOtherByIdAccountAndStatusAsync(ApplicationUser account, byte? status)
        {
            return await _db.DonHang.Where(x => x.ApplicationUser == account && (status == null || x.TTDonHang == status)).ToListAsync();
        }

        public async Task<DonHang?> Updateorder(int id, byte status, string? un)
        {

            var exiInt = await _db.DonHang.FirstOrDefaultAsync(s => s.Id == id);

            if (exiInt != null)
            {

                exiInt.TTDonHang = status;
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
        public async Task<DonHang?> GetOtherByIdAccountAndIdOrderAsync(ApplicationUser account, DonHang donHang)
        {
            return await _db.DonHang.FirstOrDefaultAsync(x => x.ApplicationUser == account && x.Id == donHang.Id);

        }
    }
}
