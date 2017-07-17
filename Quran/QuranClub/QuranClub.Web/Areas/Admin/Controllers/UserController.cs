using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using QuranClub.Core.Services.IServices;
using QuranClub.Core.Services;
using QuranClub.Domain.Entities;

namespace QuranClub.Web.Area.Admin.Controllers
{

    [Area("Admin")]
    [Route("Admin/Users")]
    public class UserController : Controller
    {
        private readonly IApplicationUserService _userservice;
        public UserController(IApplicationUserService service)
        {
            this._userservice = service;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Index(string sortOrder, string searchString, int? page, string currentFilter, int? pageSize)
        {
            pageSize = pageSize.HasValue ? pageSize.Value : 10;
            page = page.HasValue ? page.Value : 1;
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = string.IsNullOrEmpty(sortOrder) ? "firstname_desc" : "";
            ViewData["AddressSortParm"] = string.IsNullOrEmpty(sortOrder) ? "address_desc" : "address_asc";
            ViewData["CountrySortParm"] = string.IsNullOrEmpty(sortOrder) ? "country_desc" : "country_asc";
            ViewData["CitySortParm"] = string.IsNullOrEmpty(sortOrder) ? "city_desc" : "city_asc";
            ViewData["UsernameSortParm"] = string.IsNullOrEmpty(sortOrder) ? "username_desc" : "username_asc";

            var users = _userservice.GetAll(page, pageSize, sortOrder, searchString, currentFilter);

            ViewData["CurrentFilter"] = searchString;
            return View(users);
        }
        [HttpGet("Delete")]
        [AllowAnonymous]
        public IActionResult Delete(string Id)
        {
            _userservice.Delete(Id);
            return RedirectToAction("Index");
        }
    }
}