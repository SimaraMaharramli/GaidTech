using DigitalAgency.Areas.Adminarea.ViewModels.Category;
using DigitalAgency.Data;
using DigitalAgency.Helpers;
using DigitalAgency.Models.Categories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DigitalAgency.Areas.Adminarea.Controllers
{
    [Area("Adminarea")]
    public class ProjectController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public ProjectController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;

        }
        public async Task<IActionResult> Index()
        {
            ViewBag.CurrentController = "AdminPanel";
            ViewBag.CurrentAction = "Index";
            var pr=await _context.Projects.Include(x=>x.Translates).ToListAsync();
            return View(pr);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.CurrentController = "AdminPanel";
            ViewBag.CurrentAction = "Index";
           
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CategoryVM ctg)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }

                List<CategoryTaranslate> catgTranslates = new();
                foreach (var translate in ctg.Translates)
                {

                    CategoryTaranslate entertainmentTranslate = new()
                    {

                        Name = translate.Title,
                        LangCode = translate.LangCode,
                        Desc = translate.Desc

                    };
                    catgTranslates.Add(entertainmentTranslate);
                }
                string logoFileName = Guid.NewGuid().ToString() + "_" + ctg.IconFile.FileName;
                string logoPath = FileHelper.GetFilePath(_env.WebRootPath, "ctgicon/", logoFileName);
                await FileHelper.SaveFileAsync(logoPath, ctg.IconFile);
                Category newctg = new()
                {

                    Icon = logoFileName,
                    Translates = catgTranslates,
                };

                await _context.Categories.AddAsync(newctg);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");

            }
            catch (Exception)
            {

                throw;
            }
            return View();
        }

    }
}
