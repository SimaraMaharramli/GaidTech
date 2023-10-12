using DigitalAgency.Areas.Adminarea.ViewModels.Category;
using DigitalAgency.Data;
using DigitalAgency.Helpers;
using DigitalAgency.Models.Categories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DigitalAgency.Areas.Adminarea.Controllers
{
    [Area("Adminarea")]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public CategoryController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;

        }
        public async Task<IActionResult> Index()
        {
            ViewBag.CurrentController = "AdminPanel";
            ViewBag.CurrentAction = "Index";
            var ctg=await _context.Categories.Include(x=>x.Translates).ToListAsync();
            return View(ctg);
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
                   
                    Icon =  logoFileName,
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

        public async Task<IActionResult> Delete(int id)
        {
            var dbctg = await _context.Categories
                .Include(e => e.Translates)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (dbctg == null)
            {
                return NotFound();
            }
            if (dbctg.Icon!=null && dbctg.Icon!="")
            {
                var filebanner = FileHelper.GetFilePath(_env.WebRootPath, "ctgicon",
                 dbctg.Icon);
                FileHelper.DeleteFile(filebanner);
            }
            _context.CategoryTaranslates.RemoveRange(dbctg.Translates);
            _context.Categories.Remove(dbctg);

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Edit(int Id)
        {
            ViewBag.CurrentController = "AdminPanel";
            ViewBag.CurrentAction = "Index";
            var dbctg = await _context.Categories.Include(x => x.Translates).FirstOrDefaultAsync(x => x.Id == Id);
            return View(dbctg);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int Id, Category hotel)
        {
            var essn = await _context.Categories.Include(x => x.Translates).FirstOrDefaultAsync();
            if (essn == null)
            {
                return View();
            }
            if (hotel.IconFile != null)
            {
                string logoFileName = Guid.NewGuid().ToString() + "_" + hotel.IconFile.FileName;
                string logoPath = FileHelper.GetFilePath(_env.WebRootPath, "ctgicon/", logoFileName);
                await FileHelper.SaveFileAsync(logoPath, hotel.IconFile);
                var filebanner = FileHelper.GetFilePath(_env.WebRootPath, "ctgicon",
                  essn.Icon);
                FileHelper.DeleteFile(filebanner);
                essn.Icon =  logoFileName;

            }
            essn.Translates.Clear();
            foreach (var translate in hotel.Translates)
            {
                CategoryTaranslate hotelTranslate = new()
                {
                    LangCode = translate.LangCode,
                    Name = translate.Name,
                    Desc= translate.Desc,
                };
                essn.Translates.Add(hotelTranslate);
            }
              await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Category");

        }
    }
}
