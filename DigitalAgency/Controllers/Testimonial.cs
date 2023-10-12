using DigitalAgency.Data;
using DigitalAgency.Models;
using DigitalAgency.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DigitalAgency.Controllers
{
    public class Testimonial : Controller
    {
        private readonly AppDbContext _context;
        public Testimonial(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            //List<Client> clients = _context.Clients.ToList();

            return View();

        }
    }
}
