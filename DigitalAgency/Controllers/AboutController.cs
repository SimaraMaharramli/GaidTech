using DigitalAgency.Data;
using DigitalAgency.Models;
using DigitalAgency.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DigitalAgency.Controllers
{
    public class AboutController : Controller
    {
        private readonly AppDbContext _context;
        public AboutController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
			//var about=await _context.Abouts.Where(m => !m.IsDeleted).Include(x => x.Translates).FirstOrDefaultAsync();
            var lang= Request.Cookies["SelectedLanguage"];
            if (string.IsNullOrEmpty(lang))
			{

				lang = "az";
			}
			var about = _context.Abouts.Where(m => !m.IsDeleted).Select(x=> new GetAllAbout()
          {
              Email = x.Email,
              Image=x.Image,
              Location = x.Location,
              Phone = x.Phone,
              Head=x.Translates.FirstOrDefault(x=>x.LangCode==lang).Head,
              Desc=x.Translates.FirstOrDefault(x => x.LangCode == lang).Desc,
              SecondHead=x.Translates.FirstOrDefault(x => x.LangCode == lang).SecondHead,
              LangCode=lang
          }).FirstOrDefault();
          
			return View(about);
            
        }
    }
}
