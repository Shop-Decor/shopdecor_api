using AutoMapper;
using Microsoft.EntityFrameworkCore;
using shopdecor_api.Data;
using shopdecor_api.Models.Domain;

namespace shopdecor_api.Repositories.ProductRepositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly SeabugDbContext _db;
        private readonly IMapper _mapper;

        public ProductRepository(SeabugDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;

        }

        public async Task<SanPham> AddProductsAsync(SanPham model)
        {
            model.NgayTao = DateTime.Now;
            model.TrangThai = true;
            await _db.SanPham.AddAsync(model);
            await _db.SaveChangesAsync();
            return model;
        }

        public async Task<IEnumerable<SanPham>> GetAllAsync()
        {
            return await _db.SanPham.ToListAsync();
        }

        public async Task<SanPham> GetProductsAsync(int id)
        {
            return await _db.SanPham.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<SanPham>? UpdateProductsAsync(int id, SanPham model)
        {
            var product = await _db.SanPham.FirstOrDefaultAsync(x => x.Id == id);
            
            if(model != null)
            {
                product.Ten = model.Ten;
                product.MoTa = model.MoTa;
                product.KhuyenMai = model.KhuyenMai;
                product.TrangThai = model.TrangThai;
                
            }
            
            await _db.SaveChangesAsync();
            return product;
        }

        public async Task<SanPham>? DeleteProductsAsync(int id)
        {
            var product = await _db.SanPham.FirstOrDefaultAsync(x => x.Id == id);
            if(product != null)
                product.TrangThai = false;
            await _db.SaveChangesAsync();
            return product;
        }

        public async Task AddImageAsync(Hinh hinh)
        {
            _db.Hinh.Add(hinh);
            await _db.SaveChangesAsync();
        }
    }
}
