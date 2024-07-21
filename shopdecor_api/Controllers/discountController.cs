using Microsoft.AspNetCore.Mvc;

namespace shopdecor_api.Controllers
{

    public class discountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
