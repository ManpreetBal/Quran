using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using QuranClub.Core.Services.IServices;
using QuranClub.Domain.Entities;
using System.IO;
using Microsoft.AspNet.Http;
using Microsoft.Net.Http.Headers;
using Microsoft.AspNetCore.Hosting;
using QuranClub.Core.Services;

namespace QuranClub.Web.Area.Admin.Controllers
{

    [Area("Admin")]
    [Route("Admin/Cause")]
    public class CauseController : Controller
    {
        private IHostingEnvironment _env;
        private readonly ICauseService _causeservice;
        private readonly ICountryService _countryservice;
        private readonly IImageUploadService _imgservice;
        public CauseController(ICauseService service, ICountryService countruservice, IHostingEnvironment env, IImageUploadService imgservice)
        {
            this._causeservice = service;
            this._countryservice = countruservice;
            this._env = env;
            this._imgservice = imgservice;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Index(string sortOrder, string searchString, int? page, string currentFilter, int? pageSize)
        {
            pageSize = pageSize.HasValue ? pageSize.Value : 10;
            page = page.HasValue ? page.Value : 1;
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = string.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            ViewData["DateSortParm"] = string.IsNullOrEmpty(sortOrder) ? "date_desc" : "date_asc";
            ViewData["CountrySortParm"] = string.IsNullOrEmpty(sortOrder) ? "country_desc" : "country_asc";

            var cause = _causeservice.GetAll(page, pageSize, sortOrder, searchString, currentFilter);
            ViewData["CurrentFilter"] = searchString;

            return View(cause);
        }
        [HttpGet("Create")]
        public IActionResult Create()
        {
            var cause = new Cause();
            cause.Countries = _countryservice.GetAll();
            return View(cause);
        }
        [HttpPost("Create")]
        [AllowAnonymous]
        public async Task<IActionResult> Create(Cause cause)
        {
            if (ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;
                var file = HttpContext.Request.Form.Files.FirstOrDefault();
                if (file.Length > 0)
                {
                    cause.ImageUrl = await _imgservice.imageupload(files);
                    cause.CreatedAt = System.DateTime.Now;
                    _causeservice.Create(cause);
                    TempData["Message"] = "IsMessage";
                    return RedirectToAction("Index");
                }
                else
                {
                    cause.Countries = _countryservice.GetAll();
                    TempData["Error"] = "file is required!";
                    return View(cause);
                }
            }
            else
            {
                cause.Countries = _countryservice.GetAll();
                return View(cause);
            }
        }

        [HttpGet("Edit")]
        [AllowAnonymous]
        public IActionResult Edit(int? Id, int? page)
        {
            var cause = _causeservice.GetByID(Id);
            ViewBag.IsEdit = "IsUpdate";
            TempData["Message"] = "IsMessage";
            cause.page = page;
            cause.Countries = _countryservice.GetAll();
            return View("Create", cause);
        }
        [HttpPost("Edit")]
        [AllowAnonymous]
        public async Task<IActionResult> Edit(Cause cause)
        {
            var files = HttpContext.Request.Form.Files;
            if (files[0] != null && files[0].Length > 0)
            {
                var webRoot = _env.WebRootPath;
                var path = System.IO.Path.Combine(webRoot, "uploads/" + cause.ImageUrl);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
                cause.ImageUrl = await _imgservice.imageupload(files);
            }
            cause.LastUpdatedAt = System.DateTime.Now;
            _causeservice.Edit(cause);
            return RedirectToAction("Index", new { page = cause.page });
        }
        [HttpGet("Delete")]
        [AllowAnonymous]
        public IActionResult Delete(int? Id)
        {
            _causeservice.Delete(Id);
            return RedirectToAction("Index");
        }
    }
}