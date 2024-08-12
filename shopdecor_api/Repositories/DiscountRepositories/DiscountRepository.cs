using Microsoft.EntityFrameworkCore;
using shopdecor_api.Data;
using shopdecor_api.Models.Domain;

namespace shopdecor_api.Repositories.DiscountRepositories
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly SeabugDbContext _context;
        public DiscountRepository(SeabugDbContext context)
        {
            _context = context;
        }

        public async Task<KhuyenMai> AddAsync(KhuyenMai khuyenMai)
        {
            await _context.AddAsync(khuyenMai);
            await _context.SaveChangesAsync();
            return khuyenMai;
        }

        public async Task<KhuyenMai> DeleteAsync(string maGiamGia)
        {
            var discountDelete = await _context.KhuyenMai.FirstOrDefaultAsync(x => x.MaGiamGia == maGiamGia);
            if (discountDelete == null)
                return null;
            _context.KhuyenMai.Remove(discountDelete);
            await _context.SaveChangesAsync();
            return discountDelete;
        }

        public async Task<bool> DiscountExist(string maGiamGia)
        {
            return await _context.KhuyenMai.AnyAsync(x => x.MaGiamGia == maGiamGia);
        }

        public Task<bool> DiscountExist(string maGiamGia, string? currentMaGiamGia)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<KhuyenMai>> GetAllAsync()
        {
            return await _context.KhuyenMai.ToListAsync();
        }

        public async Task<KhuyenMai> GetAsync(string maGiamGia)
        {
            return await _context.KhuyenMai.Where(x => x.MaGiamGia == maGiamGia).FirstOrDefaultAsync();
        }

        public IQueryable<KhuyenMai> GetQueryable()
        {
            return _context.KhuyenMai.AsQueryable();
        }

        public async Task<KhuyenMai?> UpdateAsync(KhuyenMai khuyenMai, string maGiamGia)
        {
            var discountExist =  await _context.KhuyenMai.FirstOrDefaultAsync(x => x.MaGiamGia == maGiamGia);
            if (khuyenMai == null)
                return null;
            if(discountExist.LoaiKM == true)
            {
                discountExist.MenhGia = khuyenMai.MenhGia;
                discountExist.LoaiGiam = khuyenMai.LoaiGiam;
                discountExist.MoTa = khuyenMai.MoTa;
                discountExist.HSD = khuyenMai.HSD;
                discountExist.LoaiKM = khuyenMai.LoaiKM;
                await _context.SaveChangesAsync();
                return khuyenMai;
            }
            return null;
            
        }
    }
}
