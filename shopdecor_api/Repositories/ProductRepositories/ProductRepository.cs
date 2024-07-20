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
            var Sps = await _db.SanPham!.ToListAsync();

            return _mapper.Map<List<SanPham>>(Sps);
        }

        public async Task<SanPham> GetProductsAsync(int id)
        {
            var Sp = await _db.SanPham!.FindAsync(id);
            return _mapper.Map<SanPham>(Sp);
        }

        public async Task UpdateProductsAsync(int id, SanPham model)
        {
            if (id == model.Id)
            {
                var UpdateSp = _mapper.Map<SanPham>(model);
                _db.SanPham!.Update(UpdateSp);
                await _db.SaveChangesAsync();

            }
        }

        public async Task DeleteProductsAsync(int id)
        {
            var DeleteSp = _db.SanPham!.SingleOrDefault(sp => sp.Id == id);
            if (DeleteSp != null)
            {
                _db.SanPham!.Remove(DeleteSp);
                await _db.SaveChangesAsync();
            }
        }

        public async Task AddImageAsync(Hinh hinh)
        {
            _db.Hinh.Add(hinh);
            await _db.SaveChangesAsync();
        }
    }
}
