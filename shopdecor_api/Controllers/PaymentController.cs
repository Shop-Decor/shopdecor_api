﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shopdecor_api.Data;
using shopdecor_api.Helper;
using shopdecor_api.ViewModel;

namespace shopdecor_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : Controller
    {
        private readonly SeabugDbContext _db;
        private readonly IConfiguration _configuration;

        public PaymentController(SeabugDbContext db, IConfiguration configuration)
        {
            _db = db;
            _configuration = configuration;

        }

        [HttpPost("create-order")]
        public async Task<IActionResult> CreateOrder(VnpayRequest model)
        {

            // Tạo và lưu đơn hàng với trạng thái "chờ thanh toán"
            var vnp_Url = _configuration["Vnpay:BaseUrl"];

            var vnp_TmnCode = _configuration["Vnpay:TmnCode"];

            var vnp_HashSecret = _configuration["Vnpay:HashSecret"];

            var vnpay = new VnPayLibrary();

            vnpay.AddRequestData("vnp_Version", "2.1.0");

            vnpay.AddRequestData("vnp_Command", "pay");

            vnpay.AddRequestData("vnp_TmnCode", vnp_TmnCode);


            vnpay.AddRequestData("vnp_Amount", $"{(model.Amount * 100).ToString()}");

            vnpay.AddRequestData("vnp_CreateDate", DateTime.Now.ToString("yyyyMMddHHmmss"));

            vnpay.AddRequestData("vnp_CurrCode", _configuration["Vnpay:CurrCode"]);

            vnpay.AddRequestData("vnp_IpAddr", "127.0.0.1");

            vnpay.AddRequestData("vnp_Locale", _configuration["VnPay:Locale"]);

            vnpay.AddRequestData("vnp_OrderInfo", model.Id.ToString());

            vnpay.AddRequestData("vnp_OrderType", "other");

            vnpay.AddRequestData("vnp_ReturnUrl", "https://localhost:7078/api/Payment/payment-callback");

            vnpay.AddRequestData("vnp_TxnRef", model.Id.ToString());

            return Ok(new { url = vnpay.CreateRequestUrl(vnp_Url,vnp_HashSecret) });

        }

        [HttpGet("payment-callback")]
        public async Task<IActionResult> PaymentCallback()
        {

            var vnp_HashSecret = _configuration["Vnpay:HashSecret"];

            var vnpayData = HttpContext.Request.Query;

            VnPayLibrary vnpay = new VnPayLibrary();

            foreach (var (key, value) in vnpayData)
            {
                if (!string.IsNullOrEmpty(key) && key.StartsWith("vnp"))
                {
                    vnpay.AddResponseData(key, value);
                }
            }

            string inputHash = vnpayData["vnp_SecureHash"];

            if (vnpay.ValidateSignature(inputHash, vnp_HashSecret))
            {
                string id = vnpayData["vnp_TxnRef"];

                string? code = vnpayData["vnp_ResponseCode"];
                if(code == "00")
                {
                    var dh = await _db.DonHang.FirstOrDefaultAsync(x => x.Id.ToString() == id);
                    dh.TTDonHang = 1;
                    await _db.SaveChangesAsync();
                }
                else
                {
                    return BadRequest(new { message = "Invalid signature" });
                }
            }
            return BadRequest(new { message = "No data received" });
        }
    }
}
