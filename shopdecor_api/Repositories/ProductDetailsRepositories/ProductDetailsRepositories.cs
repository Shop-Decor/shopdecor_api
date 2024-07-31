using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using shopdecor_api.Data;
using shopdecor_api.Models.Domain;
using shopdecor_api.Repositories.ProductDetailsRepositories;

public class ProductDetailsRepositories : IProductDetailsRepositories
{
    private readonly SeabugDbContext _context;
    private readonly DbSet<SanPham_ChiTiet> _productDetails;

    public ProductDetailsRepositories(SeabugDbContext context)
    {
        _context = context;
        _productDetails = _context.Set<SanPham_ChiTiet>();
    }

    public async Task<IEnumerable<SanPham_ChiTiet>> GetAllAsync()
    {
        return await _productDetails.ToListAsync();
    }

    public async Task<SanPham_ChiTiet> GetByIdAsync(int id)
    {
        return await _productDetails.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task AddAsync(SanPham_ChiTiet productDetail)
    {
        try
        {
            await _productDetails.AddAsync(productDetail);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException ex)
        {
            if (ex.InnerException is SqlException sqlEx && sqlEx.Number == 2601)
            {
                throw new Exception("Sản phẩm chi tiết đã tồn tại.", ex);
            }
            throw new Exception("Đã xảy ra lỗi khi thêm sản phẩm chi tiết.", ex);
        }
    }

    public async Task UpdateAsync(SanPham_ChiTiet productDetail)
    {
        try
        {
            _productDetails.Update(productDetail);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException ex)
        {
            if (await _productDetails.AnyAsync(p => p.Id == productDetail.Id))
            {
                throw new Exception("Sản phẩm chi tiết đã bị thay đổi bởi người dùng khác.", ex);
            }
            throw new KeyNotFoundException("Sản phẩm chi tiết không tồn tại.");
        }
    }

    public async Task DeleteAsync(int id)
    {
        try
        {
            var productDetail = await _productDetails.FirstOrDefaultAsync(p => p.Id == id);
            if (productDetail != null)
            {
                _productDetails.Remove(productDetail);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException("Sản phẩm chi tiết không tồn tại.");
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Đã xảy ra lỗi khi xóa sản phẩm chi tiết.", ex);
        }

    }
    public async Task<List<SanPham_ChiTiet>> GetProductsDetailbyproduct(int SpId)
    {
        return await _context.SanPham_ChiTiet.Where(x => x.SanPham.Id == SpId).ToListAsync();
    }
}
