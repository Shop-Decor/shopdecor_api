using Microsoft.AspNetCore.Mvc;
using shopdecor_api.Models.Domain;
using shopdecor_api.Repositories.ProductRepositories;

namespace shopdecor_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                return Ok(await _productRepository.GetAllAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            //var products = await _productRepository.GetAllAsync();
            //return Ok(products);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductsbyId(int id)
        {
            var Sp = await _productRepository.GetProductsAsync(id);
            return Sp == null ? NotFound() : Ok(Sp);
        }
        [HttpPost]
        public async Task<IActionResult> AddNewProducts(SanPham model)
        {
            try
            {
                var NewSpId = await _productRepository.AddProductsAsync(model);
                var Sp = await _productRepository.GetProductsAsync(NewSpId);
                return Sp == null ? NotFound() : Ok(Sp);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] SanPham model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }
            await _productRepository.UpdateProductsAsync(id, model);
            return Ok("Thành Công");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] int id)
        {

            await _productRepository.DeleteProductsAsync(id);
            return Ok("Thành Công");
        }



        [HttpPost("{id}/upload-images")]
        public async Task<IActionResult> UploadImages(int id, List<IFormFile> files)
        {
            if (files == null || files.Count == 0)
            {
                return BadRequest("No files uploaded.");
            }
            var product = await _productRepository.GetProductsAsync(id);
            if (product == null)
            {
                return NotFound("product not found.");
            }
            try
            {
                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        var filePath = Path.Combine("Images", file.FileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }

                        var hinh = new Hinh
                        {
                            TenHinh = file.FileName,
                            SanPham = product
                        };

                        await _productRepository.AddImageAsync(hinh);
                    }
                }

                return Ok("Thành công");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}


