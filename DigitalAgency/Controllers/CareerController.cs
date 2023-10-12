using Microsoft.AspNetCore.Mvc;

namespace DigitalAgency.Controllers
{
    public class CareerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
