using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shopdecor_api.Models.Domain;
using shopdecor_api.Models.DTO.DiscountDTO;
using shopdecor_api.Models.DTO.FilterDTO;
using shopdecor_api.Models.DTO.PagingDTO;
using shopdecor_api.Repositories.DiscountRepositories;

namespace shopdecor_api.Controllers
{

    [Route("api/[Controller]")]
    [ApiController]
    public class discountController : Controller
    {
        private readonly IDiscountRepository _discountRepository;
        private readonly IMapper _mapper;
        public discountController(IDiscountRepository discountRepository, IMapper mapper)
        {
            _discountRepository = discountRepository;
            _mapper = mapper;

        }
        [HttpGet]
        public async Task<IActionResult> GetAllDiscountAsync([FromQuery] PagingDTO paging, [FromQuery] SearchDTO search)
        {
            var queryable = _discountRepository.GetQueryable();
            var totalRecord = queryable.Count();
            paging = paging ?? new PagingDTO();
            paging.index = paging.index < 1 ? 1 : paging.index;
            paging.size = paging.size < 1 ? 16 : paging.size;

            if (!string.IsNullOrEmpty(search?.keyword))
            {
                queryable = queryable.Where(prod => prod.MoTa.Contains(search.keyword));
            }

            queryable = queryable.Skip((paging.index - 1) * paging.size).Take(paging.size);

            // order by newest product
            queryable = queryable.OrderByDescending(prod => prod.NgayTao);

            var Discount = await queryable.ToListAsync();
            var Map = _mapper.Map<List<IndexDiscountDTO>>(Discount);


            return Ok(new PagingResponseDTO<IndexDiscountDTO>()
            {
                list = Map,
                paging = new()
                {
                    index = paging.index,
                    size = paging.size,
                    totalPage = (int)Math.Ceiling((decimal)totalRecord / paging.size),
                }
            });
        }

        [HttpGet("{maGiamGia}")]
        public async Task<IActionResult> GetAsync(string maGiamGia)
        {
            if (await _discountRepository.DiscountExist(maGiamGia))
                return NotFound();
            var Discount = _mapper.Map<IndexDiscountDTO>(_discountRepository.GetAsync(maGiamGia));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(Discount);

        }
        [HttpPost]
        public async Task<IActionResult> AddAsycn([FromBody] AddDiscountDTO addDiscountDTO)
        {

            var Discount = _mapper.Map<KhuyenMai>(addDiscountDTO);
            var DiscountCreate = await _discountRepository.AddAsync(Discount);
            return Ok(DiscountCreate);

        }
        [HttpPut]
        public async Task<IActionResult> UpdateAsycn([FromBody] UpdateDiscountDTO update, string maGiamGia)
        {
            var map = _mapper.Map<KhuyenMai>(update);
            var DiscountUpdate = await _discountRepository.UpdateAsync(map, maGiamGia);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (DiscountUpdate == null)
            {
                return NotFound();
            }
            return NoContent();
        }
        [HttpDelete("{maGiamGia}")]
        public async Task<IActionResult> DeleteAsync(string maGiamGia)
        {
            var discountDelete = await _discountRepository.DeleteAsync(maGiamGia);
            if (discountDelete == null)
                return NotFound();
            if (!ModelState.IsValid)
                return BadRequest();
            return Ok(discountDelete);
        }
        [HttpGet("discountExist")]
        public async Task<IActionResult> DiscountExist(string maGiamGia)
        {
            var discountExist = await _discountRepository.DiscountExist(maGiamGia);
            return Ok(discountExist);
        }
        

    }
}
