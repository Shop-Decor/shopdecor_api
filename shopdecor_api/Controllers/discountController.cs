using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using shopdecor_api.Models.Domain;
using shopdecor_api.Models.DTO.DiscountDTO;
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
        public async Task<IActionResult> GetAllDiscountAsync()
        {

            var Discount = await _discountRepository.GetAllAsync();
            var Map = _mapper.Map<List<IndexDiscountDTO>>(Discount);
            return Ok(Map);
        }
        [HttpGet("{maGiamGia}")]
        public async Task<IActionResult> GetAsync(string maGiamGia)
        {
            if (await _discountRepository.DiscountExist(maGiamGia))
                return NotFound();
            var Discount = _mapper.Map<IndexDiscountDTO>(_discountRepository.GetAsync(maGiamGia));
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(Discount);

        }
        [HttpPost]
        public async Task<IActionResult> AddAsycn([FromBody] IndexDiscountDTO indexDiscountDTO)
        {
            var Discount = _mapper.Map<KhuyenMai>(indexDiscountDTO);
            var DiscountCreate = await _discountRepository.AddAsync(Discount);
            
            return Ok(DiscountCreate);

        }
        [HttpPut]
        public async Task<IActionResult> UpdateAsycn([FromBody]UpdateDiscountDTO update,string maGiamGia)
        {
            var map = _mapper.Map<KhuyenMai>(update);
            var DiscountUpdate = await _discountRepository.UpdateAsync(map, maGiamGia);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if(DiscountUpdate == null)
            {
                return NotFound();
            }  
            return NoContent();
        }
    }
}
