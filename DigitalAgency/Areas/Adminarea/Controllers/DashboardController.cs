using Microsoft.AspNetCore.Mvc;

namespace DigitalAgency.Areas.Adminarea.Controllers
{
    [Area("Adminarea")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.CurrentController = "Dashboard";
            ViewBag.CurrentAction = "Index";
            return View();
        }
    }
}
