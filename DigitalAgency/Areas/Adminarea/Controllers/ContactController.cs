using DigitalAgency.Areas.Adminarea.ViewModels;
using DigitalAgency.Data;
using DigitalAgency.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Printing;

namespace DigitalAgency.Areas.Adminarea.Controllers
{
    [Area("Adminarea")]
    public class ContactController : Controller
    {
        
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public ContactController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;

        }
        public async Task<IActionResult> Index(int page = 1, int pageSize = 10)
        {
            ViewBag.CurrentController = "Contact";
            ViewBag.CurrentAction = "Index";

            var checkbox = _context
                .Contacts
                // .Where(bct => bct.BeachClubOrder.PayriffOrder.status == "APPROVED")
                .Select(bct => new Contact()
                {
                    Id = bct.Id,
                    Fullname = bct.Fullname,
                    Email = bct.Email,
                    Text = bct.Text,
                    Subject = bct.Subject,
                    CreateDate = bct.CreateDate,
                })
            .AsNoTracking()
            .OrderByDescending(bct => bct.CreateDate)
                .AsQueryable();
            var paginateTickets = await PaginatedList<Contact>.CreateAsync(checkbox, page, pageSize);
            return View(paginateTickets);
        }
    }
}
