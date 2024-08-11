using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using shopdecor_api.Data;
using shopdecor_api.Helper;
using shopdecor_api.Models.Domain;
using shopdecor_api.Models.DTO;

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

            if (model != null)
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
            if (product != null)
                product.TrangThai = false;
            await _db.SaveChangesAsync();
            return product;
        }

        public async Task AddImageAsync(Hinh hinh)
        {
            _db.Hinh.Add(hinh);
            await _db.SaveChangesAsync();
        }

        public async Task<List<ProductDetail>> GetProductDetail(int spId)
        {
            var query = @"
                            SELECT
                                sp.Id AS ProductId,
                                sp.Ten AS ProductName,
                                sp.MoTa AS ProductDescription,
                                sp.TrangThai AS Status,
                                spc.Id AS DetailId,
                                spc.SoLuong AS Quantity,
                                spc.Gia AS Price,
                                kt.TenKichThuoc AS Size,
                                ms.TenMauSac AS Color,
                                km.LoaiGiam AS DiscountType,
                                km.MenhGia AS DiscountAmount,
                                km.HSD AS DiscountExpiryDate
                            FROM
                                SanPham_ChiTiet spc
                            JOIN
                                SanPham sp ON spc.SanPhamId = sp.Id
                            LEFT JOIN
                                KichThuoc kt ON spc.KichThuocId = kt.Id
                            LEFT JOIN
                                MauSac ms ON spc.MauSacId = ms.Id
                            LEFT JOIN
                                KhuyenMai km ON sp.KhuyenMaiMaGiamGia = km.MaGiamGia
                            WHERE
                                sp.Id = @SpId;
                                ";

            // Use SqlParameter to bind the parameter value
            var spIdParam = new SqlParameter("@SpId", spId);

            // Execute the query and map results to ProductDetail
            var productDetails = await _db.Set<ProductDetail>()
                                              .FromSqlRaw(query, spIdParam)
                                              .ToListAsync();

            return productDetails;
        }
        public async Task<IEnumerable<SanPham>> GetProductsByTypeId(int typeId)
        {
            return await _db.SanPham_Loai.Where(x => x.LoaiSP.Id == typeId).Select(x => x.SanPham).ToListAsync();
        }

        public async Task<SanPham> AddProductDetailAsync(ProductWithDetailsDTO productWithDetails)
        {
            var product = new SanPham
            {
                Ten = productWithDetails.Ten,
                MoTa = productWithDetails.MoTa,
                NgayTao = DateTime.Now,
                TrangThai = true


            };
            await _db.SanPham.AddAsync(product);
            await _db.SaveChangesAsync();
            foreach (var item in productWithDetails.ChiTietSanPham)
            {
                var cl = await _db.MauSac.FirstOrDefaultAsync(x => x.Id == item.MauSacId);
                var sz = await _db.KichThuoc.FirstOrDefaultAsync(x => x.Id == item.KichThuocId);

                var spct = new SanPham_ChiTiet()
                {
                    Gia = item.Gia,
                    SoLuong = item.SoLuong,
                    KichThuoc = sz,
                    MauSac = cl,
                    SanPham = product
                };
                await _db.SanPham_ChiTiet.AddAsync(spct);
            }
            await _db.SaveChangesAsync();
            return product;
        }

        public async Task<IEnumerable<SanPham>> GetAllProductUsers()
        {
            return await _db.SanPham.Where(x => x.TrangThai == true).ToListAsync();
        }

        public async Task<PagedResult<SanPham>> GetPagedProductsAsync(int? typeId, int page, int pageSize)
        {
            if (typeId == null)
            {
                return await _db.SanPham.Where(x => x.TrangThai == true).GetPagedAsync(page, pageSize);
            }
            return await _db.SanPham_Loai.Where(x => x.LoaiSP.Id == typeId && x.SanPham.TrangThai == true).Select(x => x.SanPham).GetPagedAsync(page, pageSize);

        }

        public IQueryable<SanPham> GetQueryable()
        {
            return _db.SanPham.AsQueryable();
        }
    }
}
