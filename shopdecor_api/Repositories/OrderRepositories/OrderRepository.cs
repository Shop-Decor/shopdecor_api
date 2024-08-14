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

        public async Task<DonHang> CreateOrderAsync(CreateOrderDTO orderDto, ApplicationUser applicationUser)
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
                ApplicationUser = applicationUser,
            };
            await _db.DonHang.AddAsync(donHang);
            foreach (var x in orderDto.OrderDetails)
            {
                var sanPhamChiTiet = await _db.SanPham_ChiTiet
            .FirstOrDefaultAsync(spct => spct.SanPhamId == x.SanPhamId);

                if (sanPhamChiTiet != null)
                {
                    // Subtract the ordered quantity from the available quantity
                    sanPhamChiTiet.SoLuong -= x.SoLuong;
                }
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
            await _db.SaveChangesAsync();

            return donHang;
        }

        public async Task<IEnumerable<DonHang>> GetAlloderbystatus(byte? status)
        {
            //select id, HoTen, DiaChi, SDT, Email, NgayTao, TTDonHang, TTThanhToan, ThanhTien, LyDoHuy, NgayHuy, ApplicationUserId from DonHang where TTDonHang = status
            
            return await _db.DonHang.Where(x => status == null || x.TTDonHang == status).ToListAsync();

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

            if (exiInt != null && exiInt.TTThanhToan != true)
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
        public async Task<DonHang?> Updateorderss(int id, byte status, bool statuspay)
        {
            var exiInt = await _db.DonHang.FirstOrDefaultAsync(s => s.Id == id);
            if (exiInt != null)
            {
                exiInt.TTThanhToan = statuspay;
                exiInt.TTDonHang = status;
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

        public async Task<DonHang?> UpdateOrderStatusVnpAsync(int id)
        {
            var order = await _db.DonHang.FirstOrDefaultAsync(x => x.Id == id);
            if (order != null)
            {
                order.TTThanhToan = true;
                await _db.SaveChangesAsync();
                return order;
            }
            return null;
        }
    }
}
