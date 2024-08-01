using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using shopdecor_api.Models.Domain;
using shopdecor_api.Models.DTO.OrderDetailDTO;
using shopdecor_api.Repositories.OrderDetailRepositories;


namespace shopdecor_api.Controllers
{
	[ApiController]
	[Route("api/[controller]")]

	public class OrderDetailController : Controller
	{
		private readonly IOrderDetailRepository _orderDetailRepository;
		private readonly IMapper _mapper;

		public OrderDetailController(IOrderDetailRepository orderDetailRepository, IMapper mapper)
		{
			_orderDetailRepository = orderDetailRepository;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<IActionResult> orderDetail(int id)
		{
			/*var orderstatus = await _orderDetailRepository.GetAll(id);
			var maporderDTO = _mapper.Map<List<OrderDetailDTO>>(orderstatus);*/
			var orderstatus = await _orderDetailRepository.GetAll(id);
			return Ok(orderstatus);
		}
	}
}
