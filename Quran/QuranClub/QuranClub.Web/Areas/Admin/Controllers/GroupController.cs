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
    [Route("Admin/Groups")]
    public class GroupController : Controller
    {
        private readonly IGroupService _groupservice;
        public GroupController(IGroupService service)
        {
            this._groupservice = service;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Index(string sortOrder, string searchString, int? page, string currentFilter, int? pageSize)
        {
            pageSize = pageSize.HasValue ? pageSize.Value : 10;
            page = page.HasValue ? page.Value : 1;
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "name_asc";
            ViewData["DescriptionSortParm"] = string.IsNullOrEmpty(sortOrder) ? "description_desc" : "description_asc";
            ViewData["GroupCreatedSortParm"] = string.IsNullOrEmpty(sortOrder) ? "createdbyusername_desc" : "createdbyusername_asc";
            ViewData["DateSortParm"] = string.IsNullOrEmpty(sortOrder) ? "date_desc" : "date_asc";

            var groups = _groupservice.GetAll(page, pageSize, sortOrder, searchString, currentFilter);                   
            ViewData["CurrentFilter"] = searchString;

            return View(groups);
        }
        [HttpGet("Delete")]
        [AllowAnonymous]
        public IActionResult Delete(int? Id)
        {
            _groupservice.Delete(Id);
            return RedirectToAction("Index");
        }
    }
}