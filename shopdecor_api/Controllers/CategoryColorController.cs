using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using shopdecor_api.Models.Domain;
using shopdecor_api.Models.DTO.ColorDTO;
using shopdecor_api.Repositories.CategoryColorRepositories;

namespace shopdecor_api.Controllers
{
    [ApiController]
	[Route("api/[controller]")]

	public class CategoryColorController : Controller
	{
		private readonly ICategoryColorRepositories _categoryColorRepositories;
		private readonly IMapper _mapper;

		public CategoryColorController(ICategoryColorRepositories CategoryColorRepositories, IMapper mapper)
		{
			_categoryColorRepositories = CategoryColorRepositories;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllColor()
		{

			var category = await _categoryColorRepositories.GetAllAsync();
			var map = _mapper.Map<List<ColorDTO>>(category);
			return Ok(map);
		}

		[HttpPost]
		public async Task<IActionResult> AddColor([FromBody] ColorDTO request)
		{
			if (ModelState.IsValid)
			{
				var color = new MauSac
				{

					TenMauSac = request.TenMauSac
				};

				await _categoryColorRepositories.CreateAsync(color);
				return Ok(request);
			}
			else
			{
				return BadRequest(ModelState);
			}
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> deleteColor(int id)
		{
			if (ModelState.IsValid)
			{
				var test = await _categoryColorRepositories.DeleteAync(id);
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
		public async Task<IActionResult> updateColor(int id, [FromBody] ColorDTO request)
		{
			if (ModelState.IsValid)
			{
				var test = await _categoryColorRepositories.GetColorAsync(id);
				if (test == null)
				{

					NotFound();
				};
				var color = new MauSac
				{
					Id = id,
					TenMauSac = request.TenMauSac
				};

				await _categoryColorRepositories.UpdateColor (color);
				return Ok(color);
			}
			else
			{
				return BadRequest(ModelState);
			}
		}
	}
}
