using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using shopdecor_api.Models.Domain;
using shopdecor_api.Models.DTO.ProductDTO;
using shopdecor_api.Repositories.DiscountRepositories;
using shopdecor_api.Repositories.ImageRepositories;
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

        public ProductController(IProductRepository productRepository, IMapper mapper, IDiscountRepository discountRepository, IImageRepository imageRepository)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _discountRepository = discountRepository;
            _imageRepository = imageRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var product = await _productRepository.GetAllAsync();
            var map = _mapper.Map<List<IndexProductRequest>>(product);
            return Ok(map);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductsbyId(int id)
        {
            var product = await _productRepository.GetProductsAsync(id);
            var maps = _mapper.Map<IndexProductRequest>(product);
            return Ok(maps);
        }
        [HttpPost]
        public async Task<IActionResult> AddNewProducts([FromBody] AddProductRequest model)
        {
            try
            {
                var productDTO = _mapper.Map<SanPham>(model);
                if (model.MaGiamGia != null)
                {
                    var discount = await _discountRepository.GetAsync(model.MaGiamGia);
                    productDTO.KhuyenMai = discount;
                }
                var product = await _productRepository.AddProductsAsync(productDTO);
                if (model.Img.Count() > 0)
                {
                    foreach (var item in model.Img)
                    {
                        await _imageRepository.AddImageByProductAsync(item, product);
                    }
                }
                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
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
            return NoContent();


        }

        [HttpGet("User")]
        public async Task<IActionResult> GetAllUserProducts()
        {
            var product = await _productRepository.GetAllAsync();
            var map = _mapper.Map<List<GetUserProduct>>(product);
            return Ok(map);
        }

        [HttpGet("getproductdetail")]
        public async Task<IActionResult> getproductdetailbyproduct(int spId)
        {
            var product = await _productRepository.GetProductDetail(spId);
            return Ok(product);
        }


    }
}


