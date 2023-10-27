using DigitalAgency.Data;
using DigitalAgency.Models;
using DigitalAgency.Models.Project;
using DigitalAgency.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Reflection.Metadata;
using System.Security.Cryptography.Pkcs;

namespace DigitalAgency.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int id)
        {
            var lang = Request.Cookies["SelectedLanguage"];
            if (string.IsNullOrEmpty(lang))
            {

                lang = "az";
            }
            List<About> abouts = _context.Abouts.ToList();
            List<GetAllCategory> category = _context.Categories.Select(x=> new GetAllCategory()
            {
                Id=x.Id,
                Name=x.Translates.FirstOrDefault(x=>x.LangCode == lang).Name,
                Icon=x.Icon,
                 Projects = x.Projects.Select(x => new GetAllProject()
                 {
                     Name = x.Translates.FirstOrDefault(x => x.LangCode == lang).Name,
                     ProjectId = x.Id,
                     Image = x.Images.FirstOrDefault().Image,
                     CategoryId = x.Category.Id,
                     CategoryName = x.Category.Translates.FirstOrDefault(x => x.LangCode == lang).Name
                 }).ToList(),

            }).ToList();
            //List<Client> clients = _context.Clients.ToList();
            List<GetallHeader> headers = _context.Headers.Select(x=> new GetallHeader()
            {
               Head=x.Translates.FirstOrDefault(x=>x.LangCode==lang).Head,
               Desc=x.Translates.FirstOrDefault(x => x.LangCode == lang).Desc,
               Image=x.Image
            }).ToList();
            //List<Pricing> pricings = _context.Pricings.ToList();
          
            
            //List<Pricing> pricings = _context.Pricings.ToList();
            //List<GetAllProject> projectsdetail = _context.Projects.Select(x=> new GetAllProject()
            //{
            //    ProjectId=x.Id,
            //    CategoryId=x.Category.Id,
            //    CategoryName=x.Category.Translates.FirstOrDefault(x=>x.LangCode==lang).Name,
            //    Name=x.Translates.FirstOrDefault(x=>x.LangCode==lang).Name,
            //    Image = x.Images.FirstOrDefault().Image,

            //}).ToList();
            List<GetallService> services = _context.Services.Select(x=>new GetallService
            {
                Name=x.Translates.FirstOrDefault(x => x.LangCode == lang).Name,
                Desc=x.Translates.FirstOrDefault(x => x.LangCode == lang).Desc,
                Icon=x.Icon,
            }).ToList();
            List<Team> teams = _context.Teams.ToList();


            HomeVM home = new HomeVM
            {
                Abouts = abouts,
                //Clients = clients,
                Headers = headers,
                //Pricings = pricings,
                Categories=category,
                Services = services,
                Teams = teams,
                LangCode= lang,
            };
            if (id!=0)
            {
                category = category.Where(x => x.Id == id).ToList();
                home.Categories = category;
            }
            else
            {
                home.Categories = category;
            }
            return View(home);
        }

        public async Task<IActionResult> ProjectImage(int id)
        { 
            if (id == 0) NotFound();
              var proj=await _context.ProjectImages.Where(x=>x.ProjectId==id).ToListAsync();
            return View("_ProjectImage" , proj);
        }

    }
}