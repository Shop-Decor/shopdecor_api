using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shopdecor_api.Helper;
using shopdecor_api.Models.Domain;
using shopdecor_api.Models.DTO;
using shopdecor_api.Models.DTO.Category_TypeDTO;
using shopdecor_api.Models.DTO.FilterDTO;
using shopdecor_api.Models.DTO.PagingDTO;
using shopdecor_api.Models.DTO.ProductDTO;
using shopdecor_api.Repositories.DiscountRepositories;
using shopdecor_api.Repositories.ImageRepositories;
using shopdecor_api.Repositories.Product_CategoryRepositories;
using shopdecor_api.Repositories.ProductRepositories;

namespace shopdecor_api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IDiscountRepository _discountRepository;
        private readonly IImageRepository _imageRepository;
        private readonly IProduct_CategoryRepository _product_CategoryRepository;

        public ProductController(IProductRepository productRepository, IMapper mapper, IDiscountRepository discountRepository, IImageRepository imageRepository, IProduct_CategoryRepository product_CategoryRepository)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _discountRepository = discountRepository;
            _imageRepository = imageRepository;
            _product_CategoryRepository = product_CategoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetListProducts([FromQuery] PagingDTO paging, [FromQuery] SearchDTO search)
        {
            var queryable = _productRepository.GetQueryable();
            var totalRecord = queryable.Count();

            // default paging
            paging = paging ?? new PagingDTO();
            paging.index = paging.index < 1 ? 1 : paging.index;
            paging.size = paging.size < 1 ? 16 : paging.size;

            // take products by search keyword
            if (!string.IsNullOrEmpty(search?.keyword))
            {
                queryable = queryable.Where(prod => prod.Ten.Contains(search.keyword));
            }

            // take products by paging
            queryable = queryable.Skip((paging.index - 1) * paging.size).Take(paging.size);

            // order by newest product
            queryable = queryable.OrderByDescending(prod => prod.NgayTao);

            // get results & mapping
            var products = await queryable.ToListAsync();
            var productsRes = _mapper.Map<List<IndexProductRequest>>(products);



            return Ok(new PagingResponseDTO<IndexProductRequest>()
            {
                list = productsRes,
                paging = new()
                {
                    index = paging.index,
                    size = paging.size,
                    totalPage = (int)Math.Ceiling((decimal)totalRecord / paging.size),
                }
            });
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductsbyId(int id)
        {
            var product = await _productRepository.GetProductsAsync(id);
            var maps = _mapper.Map<IndexProductRequest>(product);
            return Ok(maps);
        }
        [HttpPost]
        public async Task<IActionResult> AddNewProduct([FromBody] ProductWithDetailsDTO model)
        {
            try
            {
                var addedProduct = await _productRepository.AddProductDetailAsync(model);

                if (model.hinhs.Count() > 0)
                {
                    foreach (var item in model.hinhs)
                    {
                        await _imageRepository.AddImageByProductAsync(item, addedProduct);
                    }
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Có lỗi xảy ra khi xử lý yêu cầu.", details = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] UpdateProductRequest updateProductRequest)
        {
            try
            {
                if (updateProductRequest == null)
                {
                    return BadRequest("Dữ liệu yêu cầu không hợp lệ.");
                }

                var map = _mapper.Map<SanPham>(updateProductRequest);
                var productupdate = await _productRepository.UpdateProductsAsync(id, map);

                if (productupdate == null)
                {
                    return NotFound("Sản phẩm không tồn tại.");
                }

                if (updateProductRequest.MaGiamGia != null)
                {
                    var discount = await _discountRepository.GetAsync(updateProductRequest.MaGiamGia);
                    productupdate.KhuyenMai = discount;
                }

                if (updateProductRequest.Imgs != null && updateProductRequest.Imgs.Any())
                {
                    await _imageRepository.RemoveImageByProductAsync(productupdate);
                    foreach (var item in updateProductRequest.Imgs)
                    {
                        await _imageRepository.AddImageByProductAsync(item, productupdate);
                    }
                }

                return Ok(productupdate);
            }
            catch (Exception ex)
            {
                // Ghi log lỗi hoặc xử lý chi tiết lỗi
                return BadRequest(new { message = "Có lỗi xảy ra khi xử lý yêu cầu.", details = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var delProduct = await _productRepository.DeleteProductsAsync(id);
            if (delProduct != null)
                delProduct.TrangThai = false;
            return Ok();
        }

        [HttpGet("getproductdetail")]
        public async Task<IActionResult> getproductdetailbyproduct(int spId)
        {
            var product = await _productRepository.GetProductDetail(spId);
            return Ok(product);
        }

        [HttpGet("GetProductsByTypeId/{SpId}")]
        public async Task<IActionResult> GetProductsByTypeId(int SpId)
        {
            var CategoryType = await _product_CategoryRepository.GetProductByProductType(SpId);
            var listCategoryId = _mapper.Map<ProductCategory>(CategoryType);

            var allProducts = new List<SanPham>();
            foreach (var item in listCategoryId.LoaiSPs)
            {
                var products = await _productRepository.GetProductsByTypeId(item);
                allProducts.AddRange(products);
            }

            if (allProducts == null || !allProducts.Any())
            {
                return NotFound(new { Message = "Không có sản phẩm nào" });
            }
            var distinctProducts = allProducts.Where(x => x.Id != SpId).Distinct().ToList();
            var productDTO = _mapper.Map<List<GetUserProduct>>(distinctProducts);
            return Ok(productDTO);
        }

        [HttpGet("user/category")]
        public async Task<IActionResult> GetProductByCategory([FromQuery] int? LoaiId, [FromQuery] PaginationParams paginationParams)
        {
            paginationParams.PageNumber = paginationParams.PageNumber < 1 ? 1 : paginationParams.PageNumber;
            paginationParams.PageSize = 12;
            var products = await _productRepository.GetPagedProductsAsync(LoaiId, paginationParams.PageNumber, paginationParams.PageSize);
            var map = _mapper.Map<GetUserProductPaginationDTO>(products);
            return Ok(map);
        }
        [HttpGet("User")]
        public async Task<IActionResult> GetAllUserProducts()
        {
            var product = await _productRepository.GetAllProductUsers();
            var map = _mapper.Map<List<GetUserProduct>>(product);
            return Ok(map);
        }

        [HttpGet("autosearch")]
        public async Task<IActionResult> GetProductByName([FromQuery] string? key)
        {
            if (string.IsNullOrEmpty(key))
            {
                return Ok(new List<object>());
            }
            var products = await _productRepository.GetProductByNameAsync(key);
            var map = _mapper.Map<List<GetProductAutoSearchDTO>>(products);
            return Ok(map);
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchByName([FromQuery] string? key, [FromQuery] PaginationParams paginationParams)
        {
            paginationParams.PageNumber = paginationParams.PageNumber < 1 ? 1 : paginationParams.PageNumber;
            paginationParams.PageSize = 15;
            var products = await _productRepository.GetPagedSearchAsync(key, paginationParams.PageNumber, paginationParams.PageSize);
            var map = _mapper.Map<GetUserProductPaginationDTO>(products);
            return Ok(map);
        }

    }
}


