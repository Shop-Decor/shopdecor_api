using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using shopdecor_api.Models.DTO.OrderDTO;
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
        [HttpPost("{CreateOrder}")]
        public async Task<IActionResult> CreateOrder([FromBody] OrderCreateDto orderDto)
        {
            if (orderDto == null)
            {
                return BadRequest("Dữ liệu đơn hàng không hợp lệ.");
            }

            try
            {
                var order = await _orderRipository.CreateOrderAsync(orderDto);
                return Ok(order);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Lỗi hệ thống: {ex.Message}");
            }
        }

        [HttpGet("Getorder/{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var order = await _orderRipository.GetOrderByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        //[HttpGet("user/{id}")]
        //public Task<IActionResult> GetOrderByUser()
    }
}
