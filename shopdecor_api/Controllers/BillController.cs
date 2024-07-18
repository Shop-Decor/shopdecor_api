using Microsoft.AspNetCore.Mvc;
using shopdecor_api.Repositories.BillRepositories;

namespace shopdecor_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BillController : Controller
    {
        private readonly IBillRepository _billRepository;

        public BillController(IBillRepository billRepository)
        {
            _billRepository = billRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllBills()
        {
            var bills = await _billRepository.GetAllAsync();
            return Ok(bills);
        }
        [HttpGet("bill/{id}")]
        public async Task<IActionResult> GetBillById(int id)
        {
            var bill = await _billRepository.GetByIdAsync(id);
            return Ok(bill);
        }
    }
}
