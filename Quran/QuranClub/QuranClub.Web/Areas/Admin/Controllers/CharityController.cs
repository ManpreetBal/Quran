using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using QuranClub.Core.Services.IServices;
using QuranClub.Domain.Entities;
using Microsoft.AspNetCore.Routing;

namespace QuranClub.Web.Area.Admin.Controllers
{

    [Area("Admin")]
    [Route("Admin/Charity")]
    public class CharityController : Controller
    {
        private readonly ICharityService _charityservice;
        public CharityController(ICharityService service)
        {
            this._charityservice = service;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Index(string sortOrder, string searchString, int? page, string currentFilter,int?pageSize)
        {
            page = page.HasValue ? page.Value : 1;
            pageSize = pageSize.HasValue ? pageSize.Value : 10;
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            var charity = _charityservice.GetAll(page, pageSize, sortOrder, searchString, currentFilter);
            ViewData["CurrentFilter"] = searchString;
            return View(charity);
        }
        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost("Create")]
        [AllowAnonymous]
        public IActionResult Create([Bind(include: "Name")]Charity charity)
        {
            if (ModelState.IsValid)
            {
                _charityservice.Create(charity);
                TempData["Message"] = "IsMessage";

                return RedirectToAction("Index");
            }
            else
            {
                return View(charity);
            }
        }

        [HttpGet("Edit")]
        [AllowAnonymous]
        public IActionResult Edit(int? Id, int? page)
        {
            var charity = _charityservice.GetByID(Id);
            ViewBag.IsEdit = "IsUpdate";
            charity.page = page;
            TempData["Message"] = "IsMessage";
            return View("Create", charity);
        }
        [HttpPost("Edit")]
        [AllowAnonymous]
        public IActionResult Edit([Bind(include: "Id,Name")]Charity charity)
        {
            if (ModelState.IsValid)
            {
                _charityservice.Edit(charity);
                return RedirectToAction("Index", new { page = charity.page });
            }
            else
            {
                ViewBag.IsEdit = "IsUpdate";
                return View("Create", charity);
            }
        }
        [HttpGet("Delete")]
        [AllowAnonymous]
        public IActionResult Delete(int? Id)
        {
            _charityservice.Delete(Id);
            return RedirectToAction("Index");
        }
    }
}