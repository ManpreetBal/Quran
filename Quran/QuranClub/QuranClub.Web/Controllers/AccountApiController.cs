using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using QuranClub.Domain.Entities;
using QuranClub.Core.Services;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace QuranClub.Controllers
{
    [Route("api/v1")]
    public class AccountApiController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger _logger;


        public AccountApiController(SignInManager<ApplicationUser> signManager, UserManager<ApplicationUser> userManager, ILoggerFactory loggerfactory)
        {
            this._signManager = signManager;
            this._userManager = userManager;
            this._logger = loggerfactory.CreateLogger<AccountApiController>();
        }
        // Post: api/v1/register
        [HttpPost("register")]
        public async Task<IActionResult> Register(User user)
        {
            string ErrorMessages = "";

            ApplicationUser authuser = new ApplicationUser
            {
                UserName = user.Email,
                Email = user.Email,
                PhoneNumber = user.Phone,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Address = user.Address,
                City = user.City,
                Country = user.Country,
                Postcode = user.Postcode,
                FaceBookId = user.FaceBookId,
                LocationLatitude = user.LocationLatitude,
                LocationLongitude = user.LocationLongitude,
                LastSeenPage = user.LastSeenPage,
                Language = user.Language

            };

            IdentityResult result = await _userManager.CreateAsync(authuser, user.Password);

            if (result.Succeeded)
            {
                await _signManager.SignInAsync(authuser, isPersistent: true);
                return Ok("User registered successfully.");
            }
            else
            {
                foreach (var error in result.Errors)
                {

                    ErrorMessages += " " + error.Description;
                }
                throw new MyAppException(ErrorMessages.ToString());

            }
        }
        // Post: api/v1/login
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(User user)
        {

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, set lockoutOnFailure: true
            var result = await _signManager.PasswordSignInAsync(user.Email, user.Password, false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                _logger.LogInformation(1, "User logged in.");
                return Ok("User logged in successfully.");

            }
            else
            {
                throw new MyAppException("Invalid username or password");
            }

            // If we got this far, something failed, redisplay form
        }

    }
}
