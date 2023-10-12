
using DigitalAgency.Areas.Adminarea.ViewModels.Account;
using DigitalAgency.Data;
using DigitalAgency.Helpers;
using DigitalAgency.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Drawing.Printing;

namespace DigitalAgency.Areas.Adminarea.Controllers
{
	[Area("Adminarea")]
	public class AccountController : Controller
    {


        private readonly Microsoft.AspNetCore.Identity.UserManager<AppUser> _userManager;
        private readonly Microsoft.AspNetCore.Identity.RoleManager<IdentityRole> _roleManager;
        private readonly AppDbContext _context;
        private readonly SignInManager<AppUser> _signInManager;
        public AccountController(Microsoft.AspNetCore.Identity.UserManager<AppUser> userManager, Microsoft.AspNetCore.Identity.RoleManager<IdentityRole> roleManager, AppDbContext context, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
            _signInManager = signInManager;
        }
       
        [HttpGet]
        public IActionResult RegisterAdmin()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> RegisterAdmin(AdminRegisterVM model)
        {
            // Input validation
            if (model == null)
            {
                return View("RegisterAdmin", "Account");
            }

            if (string.IsNullOrEmpty(model.Email))
            {
                return View("RegisterAdmin", "Account");
            }
            if (string.IsNullOrEmpty(model.Password))
            {
                return View("RegisterAdmin", "Account");
            }
            var user = new AppUser { Email = model.Email, UserName = model.Email,PasswordHash = model.Password };
            Microsoft.AspNetCore.Identity.IdentityResult result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                return View("RegisterAdmin", "Account");
            }

            var dbUser = await _userManager.FindByIdAsync(user.Id);

            await _userManager.AddToRoleAsync(dbUser, "Admin");
            return RedirectToAction("Index", "Dashboard");

        }

        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginVM user)
        {
            if (user.Email == null || user.Email == "")
            {
                return View("Login", "Account");
            }
            if (user.Password == null || user.Password == "")
            {
                return View("Login", "Account");
            }
            var dbUser = await _userManager.FindByEmailAsync(user.Email);

            Microsoft.AspNetCore.Identity.SignInResult signInResult = await _signInManager.PasswordSignInAsync(dbUser, user.Password, false, false);

            if (!signInResult.Succeeded)
            {
                if (signInResult.IsNotAllowed)
                {
                    ModelState.AddModelError("", "Please Confirm Your Accaunt");
                    return View(user);
                }
                ModelState.AddModelError("", "Email or Password is Wrong");
                return View(user);
            }
            if (await _userManager.IsInRoleAsync(dbUser, "Admin") || true)
            {
                return RedirectToAction("Index", "Dashboard");
            }
            return View("Login", "Account");

        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Login", "Account");
        }


        public async Task CreateRoles()
        {
            foreach (var role in Enum.GetValues(typeof(rolesenum)))
            {
                if (!await _roleManager.RoleExistsAsync(role.ToString()))
                {
                    await _roleManager.CreateAsync(new IdentityRole { Name = role.ToString() });
                }
            }

        }

    }
}
