using Microsoft.AspNetCore.Mvc;

namespace DigitalAgency.Areas.Adminarea.Controllers
{
    [Area("Adminarea")] 
    public class AdminPanelController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.CurrentController = "AdminPanel";
            ViewBag.CurrentAction = "Index";
            return View();
        }
    }
}
