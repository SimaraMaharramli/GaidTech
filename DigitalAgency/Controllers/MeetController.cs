using DigitalAgency.Data;
using DigitalAgency.Models;
using DigitalAgency.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DigitalAgency.Controllers
{
    public class MeetController : Controller
    {
        private readonly AppDbContext _context;
        public MeetController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<Team> teams = _context.Teams.ToList();

            TeamVM team = new TeamVM
            {
                Teams = teams
            };


            return View(team);

        }
    }
}
