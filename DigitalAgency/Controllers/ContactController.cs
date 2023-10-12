using DigitalAgency.Data;
using DigitalAgency.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DigitalAgency.Controllers
{
    public class ContactController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public ContactController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            var lang = Request.Cookies["SelectedLanguage"];
            if (string.IsNullOrEmpty(lang))
            {

                lang = "az";
            }
            ViewBag.Lang = lang;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(string fullname,string email,string subject,string message)
        {
           
          
          
           
            Contact contact = new Contact();
            contact.Subject = subject;
            contact.Email = email;
            contact.Fullname = fullname;
            contact.Text = message;
            contact.IsDeleted = true;
            contact.CreateDate = DateTime.UtcNow;
            await _context.Contacts.AddAsync(contact);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        
    }
}
