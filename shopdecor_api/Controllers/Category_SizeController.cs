using Microsoft.AspNetCore.Mvc;
using shopdecor_api.Models.Domain;

using shopdecor_api.Models.DTO.SizeDTO;
using shopdecor_api.Repositories.Category_SizeRepositories;


namespace shopdecor_api.Controllers
{
	[ApiController]
	[Route("api/[controller]")]

	public class Category_SizeController : Controller
	{
		private readonly ICategory_SizeRepositories _categorySizeRepository;

		public Category_SizeController(ICategory_SizeRepositories categorySizeRepository)
		{
			_categorySizeRepository = categorySizeRepository;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllSize()
		{
			var category = await _categorySizeRepository.GetAllAsync();
			return Ok(category);
		}

		[HttpPost]
		public async Task<IActionResult> AddSize([FromBody] SizeDTO request)
		{
			if (ModelState.IsValid)
			{
				var size = new KichThuoc
				{

					TenKichThuoc = request.TenKichThuoc
				};

				await _categorySizeRepository.CreateAsync(size);
				return Ok(request);
			}
			else
			{
				return BadRequest(ModelState);
			}
		}
		[HttpDelete("{id}")]
		public async Task<IActionResult> deletesize(int id)
		{
			if (ModelState.IsValid)
			{
				var test = await _categorySizeRepository.DeleteAync(id);
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
		public async Task<IActionResult> updatesize(int id, [FromBody] SizeDTO request)
		{
			if (ModelState.IsValid)
			{
				var test = await _categorySizeRepository.GetSizeAsync(id);
				if (test == null)
				{

					NotFound();
				};
				var size = new KichThuoc
				{
					Id = id,
					TenKichThuoc = request.TenKichThuoc
				};

				await _categorySizeRepository.UpdateSize(size);
				return Ok(size);
			}
			else
			{
				return BadRequest(ModelState);
			}
		}
	}
}
