using DigitalAgency.Areas.Adminarea.ViewModels.About;
using DigitalAgency.Areas.Adminarea.ViewModels.Category;
using DigitalAgency.Data;
using DigitalAgency.Helpers;
using DigitalAgency.Models;
using DigitalAgency.Models.Categories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DigitalAgency.Areas.Adminarea.Controllers
{
    [Area("Adminarea")]
    public class AboutController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public AboutController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }



        public async Task<IActionResult> Index()
        {
            ViewBag.CurrentController = "AdminPanel";
            ViewBag.CurrentAction = "Index";
            var about = await _context.Abouts.Where(m => !m.IsDeleted).Include(x => x.Translates).ToListAsync();
            return View(about);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.CurrentController = "AdminPanel";
            ViewBag.CurrentAction = "Index";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AboutVM about)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }

                List<AboutTranslate> aboutTranslates = new();
                foreach (var translate in about.Translates)
                {

                    AboutTranslate entertainmentTranslate = new()
                    {

                        Head = translate.Head,
                        SecondHead = translate.SecondHead,
                        LangCode = translate.LangCode,
                        Desc = translate.Desc

                    };
                    aboutTranslates.Add(entertainmentTranslate);
                }
                string logoFileName = Guid.NewGuid().ToString() + "_" + about.Image.FileName;
                string logoPath = FileHelper.GetFilePath(_env.WebRootPath, "aboutimage/", logoFileName);
                await FileHelper.SaveFileAsync(logoPath, about.Image);
                About newAbout = new()
                {
                    Location = about.Location,
                    Email = about.Email,
                    Phone = about.Phone,
                    Image = logoFileName,
                    Translates = aboutTranslates,
                };

                await _context.Abouts.AddAsync(newAbout);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");

            }
            catch (Exception)
            {

                throw;
            }
            return View();
        }



        public async Task<IActionResult> Edit(int Id)
        {
            ViewBag.CurrentController = "AdminPanel";
            ViewBag.CurrentAction = "Index";
            var dbabout = await _context.Abouts.Include(x => x.Translates).FirstOrDefaultAsync(x => x.Id == Id);
            return View(dbabout);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(int Id, About about)
        {
            var essn = await _context.Abouts.Include(x => x.Translates).FirstOrDefaultAsync();
            if (essn == null)
            {
                return View();
            }
            if (about.ImageFile != null)
            {
                string logoFileName = Guid.NewGuid().ToString() + "_" + about.ImageFile.FileName;
                string logoPath = FileHelper.GetFilePath(_env.WebRootPath, "aboutImage/", logoFileName);
                await FileHelper.SaveFileAsync(logoPath, about.ImageFile);
                var filebanner = FileHelper.GetFilePath(_env.WebRootPath, "aboutImage",
                  essn.Image);
                FileHelper.DeleteFile(filebanner);
                essn.Image = logoFileName;

            }
            essn.Translates.Clear();
            foreach (var translate in about.Translates)
            {
                AboutTranslate aboutTranslate = new()
                {
                    LangCode = translate.LangCode,
                    Head = translate.Head,
                    SecondHead = translate.SecondHead,
                    Desc = translate.Desc,
                };
                essn.Translates.Add(aboutTranslate);
            }

                essn.Location = about.Location;   
                essn.Email = about.Email;   
                essn.Phone = about.Phone;   
            
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "About");

        }



        public async Task<IActionResult> Delete(int id)
        {
            var dbabout = await _context.Abouts
                .Include(e => e.Translates)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (dbabout == null)
            {
                return NotFound();
            }
            if (dbabout.Image != null && dbabout.Image != "")
            {
                var filebanner = FileHelper.GetFilePath(_env.WebRootPath, "aboutImage",
                 dbabout.Image);
                FileHelper.DeleteFile(filebanner);
            }
            _context.AboutTranslates.RemoveRange(dbabout.Translates);
            _context.Abouts.Remove(dbabout);

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

    }
}
