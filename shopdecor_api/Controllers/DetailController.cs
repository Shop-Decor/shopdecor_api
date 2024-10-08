﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shopdecor_api.Data;
using shopdecor_api.Models.Domain;
using shopdecor_api.Models.DTO.Product_DetailDTO;
using shopdecor_api.Repositories.ProductDetailsRepositories;

namespace shopdecor_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductDetailsController : ControllerBase
    {
        private readonly IProductDetailsRepositories _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductDetailsController> _logger;
        private readonly SeabugDbContext _context;

        public ProductDetailsController(IProductDetailsRepositories repository, IMapper mapper, ILogger<ProductDetailsController> logger, SeabugDbContext context)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
            _context = context;
        }

        // GET api/productdetails
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var productDetails = await _repository.GetAllAsync();
                var dtoList = _mapper.Map<List<IndexDTODetails>>(productDetails);
                return Ok(dtoList);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching all product details.");
                return StatusCode(500, "Internal server error");
            }
        }

        // GET api/productdetails/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<IndexDTODetails>> GetById(int id)
        {
            try
            {
                var productDetail = await _repository.GetByIdAsync(id);
                if (productDetail == null)
                {
                    return NotFound();
                }

                var dto = _mapper.Map<IndexDTODetails>(productDetail);
                return Ok(dto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while fetching product detail with id {id}.");
                return StatusCode(500, "Internal server error");
            }
        }

        // POST api/productdetails
        [HttpPost]
        public async Task<ActionResult> Add([FromBody] DTOCreateProductDetails dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var productDetail = _mapper.Map<SanPham_ChiTiet>(dto);
                await _repository.AddAsync(productDetail);

                productDetail = await _repository.GetByIdAsync(productDetail.Id);
                var result = _mapper.Map<DTODetails>(productDetail);

                return CreatedAtAction(nameof(GetById), new { id = productDetail.Id }, result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while adding a new product detail.");
                return StatusCode(500, "Internal server error");
            }
        }


        // PUT api/productdetails/{id}
        [HttpPut]
        public async Task<ActionResult> Update([FromBody] DTOUpdateProductDetails dto)
        {
            try
            {
                if (dto == null)
                {
                    return BadRequest("DTO is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var existingProductDetail = await _repository.GetByIdAsync(dto.Id);
                if (existingProductDetail == null)
                {
                    return NotFound();
                }

                _mapper.Map(dto, existingProductDetail);
                await _repository.UpdateAsync(existingProductDetail);

                var result = _mapper.Map<DTODetails>(existingProductDetail);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while updating product detail with id {dto.Id}.");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // DELETE api/productdetails/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _repository.DeleteAsync(id);
                return Ok(); // Trả về mã 200 OK
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while deleting product detail with id {id}.");
                return StatusCode(500, "Internal server error");
            }
        }


        // GET api/productdetails/GetProductDetailsbyproduct?SpId={SpId}
        [HttpGet("GetProductDetailsbyproduct")]
        public async Task<ActionResult<IEnumerable<DTODetails>>> GetProductDetailsbyproduct(int SpId)
        {
            try
            {
                var productDetails = await _repository.GetProductsDetailbyproduct(SpId);
                if (productDetails == null || !productDetails.Any())
                {
                    return NotFound();
                }
                var dtoList = productDetails.Select(pd => _mapper.Map<DTODetails>(pd)).ToList();
                return Ok(dtoList);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while fetching product details by product id {SpId}.");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("details")]
        public async Task<IActionResult> GetAllProductDetails()
        {
            var productDetails = await _context.SanPham_ChiTiet
                .GroupBy(p => p.SanPhamId)
                .Select(g => new ProductDetailDTO
                {
                    ProductId = g.Key,
                    ChiTietSanPham = g.Select(p => new ProductDTODetail
                    {
                        Color = p.MauSac.TenMauSac, // Assuming MauSac entity has a Ten property for color
                        Size = p.KichThuoc.TenKichThuoc, // Assuming KichThuoc entity has a Ten property for size
                        Quantity = p.SoLuong
                    }).ToList()
                })
                .ToListAsync();

            if (productDetails == null || !productDetails.Any())
            {
                return NotFound();
            }

            return Ok(productDetails);
        }
    }

}
