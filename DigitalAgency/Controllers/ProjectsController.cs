using DigitalAgency.Data;
using DigitalAgency.Models.Project;
using DigitalAgency.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DigitalAgency.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly AppDbContext _context;
        public ProjectsController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index( int id)
        {
            var lang = Request.Cookies["SelectedLanguage"];
            if (string.IsNullOrEmpty(lang))
            {

                lang = "az";
            }
            //List<Project> projects = _context.Projects.ToList();
            List<GetAllCategory> category = _context.Categories.Select(x => new GetAllCategory()
            {
                Id = x.Id,
                Name = x.Translates.FirstOrDefault(x => x.LangCode == lang).Name,
                Icon = x.Icon,
                LangCode=lang,
                Projects = x.Projects.Select(x => new GetAllProject()
                {
                    Name = x.Translates.FirstOrDefault(x => x.LangCode == lang).Name,
                    ProjectId = x.Id,
                    Image = x.Images.FirstOrDefault().Image,
                    CategoryId = x.Category.Id,
                    CategoryName = x.Category.Translates.FirstOrDefault(x => x.LangCode == lang).Name
                }).ToList(),

            }).ToList();
            if (id!=0)
            {
                category = category.Where(x => x.Id == id).ToList();
            }
            ProjectVM project = new ProjectVM
            {
                Projects = category
            };

            return View(project);

        }
    }
}
