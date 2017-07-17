using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using Microsoft.Extensions.DependencyInjection;
using QuranClub.Domain.Entities;
using QuranClub.Core.Services.IServices;

namespace QuranClub.Web.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    [Route("Admin/Login")]
    public class LoginController : Controller
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IAdminService _AdminService;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly ILogger _logger;
        public LoginController(IAdminService service, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ILoggerFactory loggerFactory, RoleManager<ApplicationRole> roleManager)
        {
            this._AdminService = service;
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._roleManager = roleManager;
            this._logger = loggerFactory.CreateLogger<LoginController>();
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(User user)
        {
            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, set lockoutOnFailure: true
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(user.Email, user.Password, true, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    _logger.LogInformation(1, "User logged in.");
                    return RedirectToAction("Index", "dashboard");

                }
                else
                {
                    TempData["Message"] = "Username or Password is invalid!";
                    return View("Index");
                }
            }     
            return View("Index");
        }
        [HttpGet("Logout")]
        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation(4, "User logged out.");
            return RedirectToAction("Index");
        }
        [HttpGet("AccessDenied")]
        public IActionResult Denied()
        {
            return View();
        }
    }
}