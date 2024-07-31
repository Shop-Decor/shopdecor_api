using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using shopdecor_api.Models.Domain;
using shopdecor_api.Models.DTO;
using shopdecor_api.Models.DTO.Category_TypeDTO;
using shopdecor_api.Repositories.CategoryRepositories;
using shopdecor_api.Repositories.Product_CategoryRepositories;


namespace shopdecor_api.Controllers
{
    [ApiController]
	[Route("api/[controller]")]

	public class CategoryController : Controller
	{
		private readonly ICategoryRepnsitetory _categoryRepository;
		private readonly IProduct_CategoryRepositories _product_CategoryRepository;
		private readonly IMapper _mapper;

		public CategoryController(ICategoryRepnsitetory categoryRepository,IMapper mapper, IProduct_CategoryRepositories product_CategoryRepositories)
		{
			_categoryRepository = categoryRepository;
            _product_CategoryRepository = product_CategoryRepositories;
			_mapper = mapper;
		}
		[HttpGet]	
		
		public async Task<IActionResult> GetAllProductType()
		{
			var category = await _categoryRepository.GetAllAsync();
			return Ok(category);
		}

		[HttpPost]
		public async Task<IActionResult> AddPType([FromBody] ProductTypeDTO request)
		{
			if (ModelState.IsValid)
			{
				var loai = new LoaiSP
				{
					
					TenLoai = request.TenLoai
				};

				await _categoryRepository.CreateAsync(loai);
				return Ok(request);
			}
			else
			{
				return BadRequest(ModelState);
			}
		}
		[HttpDelete("{id}")]
		public async Task<IActionResult> deletePType(int id)
		{
			if (ModelState.IsValid)
			{
				var test = await _categoryRepository.DeleteAync(id);
				if (test == null)
				{
					return NotFound();
				}
				return Ok(test);
			}
			else
			{
				return BadRequest(ModelState);
			}
		}
		[HttpPut("{id}")]
		public async Task<IActionResult> updatePT(int id, [FromBody] ProductTypeDTO request)
		{
			if (ModelState.IsValid)
			{
				var test = await _categoryRepository.GetLoaiSPAsync(id);
				if(test == null)
				{

					NotFound();
				};
				var loai = new LoaiSP
				{
					Id = id,
					TenLoai = request.TenLoai
				};

				await _categoryRepository.UpdatePType(loai);
				return Ok(loai);
			}
			else
			{
				return BadRequest(ModelState);
			}
		}
        [HttpGet("GetCategoryList")]
        public async Task<IActionResult> GetProductTypeByProduct(int SpId)
        {
            var CategoryType = await _product_CategoryRepository.GetProductByProductType(SpId);
			var map = _mapper.Map<ProductCategory>(CategoryType);
			return Ok(map);

        }
    }
}
