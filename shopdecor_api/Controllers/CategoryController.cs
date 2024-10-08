﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using shopdecor_api.Models.Domain;
using shopdecor_api.Models.DTO.CategoryDTO;
using shopdecor_api.Models.DTO.TypeDTO;
using shopdecor_api.Repositories.CategoryRepositories;


namespace shopdecor_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class CategoryController : Controller
    {
        private readonly ICategoryRepnsitetory _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryController(ICategoryRepnsitetory categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        [HttpGet]

        public async Task<IActionResult> GetAllProductType()
        {
            var category = await _categoryRepository.GetAllAsync();
            var categoriesDTO = _mapper.Map<List<GetCategoriesOnUser>>(category);
            return Ok(categoriesDTO);
        }

        [HttpPost]
        public async Task<IActionResult> AddPType([FromBody] TypeDTO request)
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
        public async Task<IActionResult> updatePT(int id, [FromBody] TypeDTO request)
        {
            if (ModelState.IsValid)
            {
                var test = await _categoryRepository.GetLoaiSPAsync(id);
                if (test == null)
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
    }
}
