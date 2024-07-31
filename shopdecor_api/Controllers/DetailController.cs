using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using shopdecor_api.Models.Domain;
using shopdecor_api.Models.DTO;
using shopdecor_api.Repositories.ProductDetailsRepositories;

namespace shopdecor_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductDetailsController : ControllerBase
    {
        private readonly IProductDetailsRepositories _repository;
        private readonly IMapper _mapper;

        public ProductDetailsController(IProductDetailsRepositories repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET api/productdetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DTODetails>>> GetAll()
        {
            var productDetails = await _repository.GetAllAsync();
            var dtoList = productDetails.Select(pd => _mapper.Map<DTODetails>(pd)).ToList();
            return Ok(dtoList);
        }

        // GET api/productdetails/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<DTODetails>> GetById(int id)
        {
            var productDetail = await _repository.GetByIdAsync(id);
            if (productDetail == null)
            {
                return NotFound();
            }

            var dto = _mapper.Map<DTODetails>(productDetail);
            return Ok(dto);
        }

        // POST api/productdetails
        [HttpPost]
        public async Task<ActionResult> Add([FromBody] DTODetails dto)
        {
            if (dto == null)
            {
                return BadRequest();
            }

            var productDetail = _mapper.Map<SanPham_ChiTiet>(dto);
            await _repository.AddAsync(productDetail);
            return CreatedAtAction(nameof(GetById), new { id = productDetail.Id }, productDetail);
        }

        // PUT api/productdetails/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] DTODetails dto)
        {
            if (id != dto.Id)
            {
                return BadRequest();
            }

            var existingProductDetail = await _repository.GetByIdAsync(id);
            if (existingProductDetail == null)
            {
                return NotFound();
            }

            var updatedProductDetail = _mapper.Map<SanPham_ChiTiet>(dto);
            await _repository.UpdateAsync(updatedProductDetail);
            return Ok();
        }

        // DELETE api/productdetails/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existingProductDetail = await _repository.GetByIdAsync(id);
            if (existingProductDetail == null)
            {
                return NotFound();
            }

            await _repository.DeleteAsync(id);
            return Ok();
        }
        
    }
}

