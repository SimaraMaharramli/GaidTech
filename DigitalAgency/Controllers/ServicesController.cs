using DigitalAgency.Data;
using DigitalAgency.Models;
using DigitalAgency.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.PortableExecutable;

namespace DigitalAgency.Controllers
{
    public class ServicesController : Controller
    {
        private readonly AppDbContext _context;
        public ServicesController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var lang = Request.Cookies["SelectedLanguage"];
            if (string.IsNullOrEmpty(lang))
            {

                lang = "az";
            }
            var about =await _context.Services.Select(x => new GetallService()
            {
                Name=x.Translates.FirstOrDefault(x=>x.LangCode==lang).Name,
                Desc=x.Translates.FirstOrDefault(x=>x.LangCode==lang).Desc,
                Icon=x.Icon,
                LangCode=lang,
            }).ToListAsync();

            return View(about);

        }
    }
}
