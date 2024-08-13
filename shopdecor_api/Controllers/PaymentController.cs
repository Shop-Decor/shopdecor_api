using Microsoft.AspNetCore.Mvc;
using shopdecor_api.Repositories.OrderRepositories;
using shopdecor_api.Repositories.VnpayDTO;
using shopdecor_api.Services;

namespace shopdecor_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : Controller
    {
        private readonly IVnPayService _vnPayService;
        private readonly IOrderRipository _orderRipository;

        public PaymentController(IVnPayService vnPayService, IOrderRipository orderRipository)
        {
            _vnPayService = vnPayService;
            _orderRipository = orderRipository;
        }

        [HttpPost("create-order")]
        public IActionResult CreateOrder(PaymentInformationModel model)
        {
            var url = _vnPayService.CreatePaymentUrl(model, HttpContext);
            return Ok(url);
        }

        [HttpGet("vnpay-return")]
        public async Task<IActionResult> PaymentCallback()
        {
            var response = _vnPayService.PaymentExecute(Request.Query);
            if (response.VnPayResponseCode == "00")
            {
                await _orderRipository.UpdateOrderStatusVnpAsync(int.Parse(response.OrderInfo));
                return Ok(new { success = true, message = "Thanh toán thành công" });
            }
            return Ok(new { success = false, message = "Lỗi thanh toán" });
        }

    }
}
