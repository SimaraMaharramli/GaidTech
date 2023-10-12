using DigitalAgency.Data;
using DigitalAgency.Models;
using DigitalAgency.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DigitalAgency.Controllers
{
    public class PricesController : Controller
    {

        private readonly AppDbContext _context;
        public PricesController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            //List<Pricing> prices = _context.Pricings.ToList();

            //PriceVM price = new PriceVM
            //{

            //    Prices = prices,
            //};

            return View();

        }
    }
}
