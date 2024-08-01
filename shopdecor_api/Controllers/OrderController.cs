using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using shopdecor_api.Repositories.OrderRepositories;

namespace shopdecor_api.Controllers
{
    [ApiController]
	[Route("api/[controller]")]
	public class OrderController : Controller
	{
		private readonly IOrderRipository _orderRipository;
		private readonly IMapper _mapper;

		public OrderController(IOrderRipository orderRipository, IMapper mapper)
		{
			_orderRipository = orderRipository;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<IActionResult> orderStatus(byte status)
		{
			/*	var orderstatus = await _orderRipository.GetAlloderbystatus(status);
				var maporderDTO = _mapper.Map<List<OrderDTO>>(orderstatus);*/
			var orderstatus = await _orderRipository.GetAlloderbystatus(status);
			return Ok(orderstatus);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> updatestatus(int id, byte status, string? un)
		{
			
			
			var test = await _orderRipository.Updateorder(id, status, un);
			if(test == null)
			{
				return BadRequest();
			}

			return Ok(test);
			
		}

		
	}
}
