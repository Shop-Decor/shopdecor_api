using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using shopdecor_api.Models.DTO.OrderDTO;
using shopdecor_api.Repositories.AccountRepositories;
using shopdecor_api.Repositories.OrderRepositories;

namespace shopdecor_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private readonly IOrderRipository _orderRipository;
        private readonly IMapper _mapper;
        private readonly IAccountRepository _accountRepository;

        public OrderController(IOrderRipository orderRipository, IMapper mapper, IAccountRepository accountRepository)
        {
            _orderRipository = orderRipository;
            _mapper = mapper;
            _accountRepository = accountRepository;
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
            if (test == null)
            {
                return BadRequest();
            }
            return Ok(test);
        }

        [HttpPost("CreateOrders")]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderDTO orderDto)
        {
            var userId = await _accountRepository.GetAccountById(orderDto.userId);
            if(userId != null)
            {
                var result = await _orderRipository.CreateOrderAsync(orderDto, userId);

                if (result == null)
                {
                    return BadRequest();
                }
                else
                {
                    return Ok(result.Id);
                }
            }
            return BadRequest(userId);
            

        }



        [HttpGet("user")]
        public async Task<IActionResult> GetOrderByUser([FromQuery] string accountId, [FromQuery] byte? status)
        {
            var account = await _accountRepository.GetAccountById(accountId);
            if (account == null)
            {
                return BadRequest(new { Message = "Tài khoản không tồn tại" });
            }
            var orders = await _orderRipository.GetOtherByIdAccountAndStatusAsync(account, status);
            var DTO = _mapper.Map<List<OrderManagementDTO>>(orders);
            return Ok(DTO);
        }
        [HttpGet("user/detail")]
        public async Task<IActionResult> GetOrderDetailedByUser([FromQuery] string accountId, [FromQuery] int orderId)
        {
            var account = await _accountRepository.GetAccountById(accountId);
            if (account == null)
            {
                return BadRequest(new { Message = "Tài khoản không tồn tại" });
            }
            var order = await _orderRipository.GetorderAsync(orderId);
            if (order == null)
            {
                return BadRequest(new { Message = "Đơn Hàng không tồn tại" });
            }
            var orders = await _orderRipository.GetOtherByIdAccountAndIdOrderAsync(account, order);
            var DTO = _mapper.Map<OrderDetailManagementDTO>(orders);
            return Ok(DTO);
        }
    }
}
