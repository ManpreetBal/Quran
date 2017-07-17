using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using QuranClub.Core.Services.IServices;
using QuranClub.Domain.Entities;
using System.Net;
using QuranClub.Core.Services;

namespace QuranClub.Web.Area.Admin.Controllers
{

    [Area("Admin")]
    [Route("Admin/Advert")]
    public class AdvertController : Controller
    {
        private readonly IAdvertService _advertservice;
        private readonly IMediaTypeService _mediaservice;
        private readonly ILanguagesService _languageservice;
        private readonly ICountryService _CountryService;
        public AdvertController(IAdvertService service, IMediaTypeService mediaservice, ILanguagesService languageservice, ICountryService countryservice)//, ICityService city) 
        {
            this._advertservice = service;
            this._mediaservice = mediaservice;
            this._languageservice = languageservice;
            this._CountryService = countryservice;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Index(string sortOrder, string searchString, int? page, string currentFilter,int? pageSize)
        {
            pageSize = pageSize.HasValue ? pageSize.Value : 10;
            page = page.HasValue ? page.Value : 1;
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = string.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            ViewData["MediaTypeSortParm"] = string.IsNullOrEmpty(sortOrder) ? "mediatype_desc" : "mediatype_asc";
            ViewData["MediaUrlSortParm"] = string.IsNullOrEmpty(sortOrder) ? "mediaurl_desc" : "mediaurl_asc";
            ViewData["DailyQuotaSortParm"] = string.IsNullOrEmpty(sortOrder) ? "dailyquota_desc" : "dailyquota_asc";
            ViewData["TotalAmountSortParm"] = string.IsNullOrEmpty(sortOrder) ? "totalamount_desc" : "totalamount_asc";
            ViewData["PaymentStausSortParm"] = string.IsNullOrEmpty(sortOrder) ? "paymentstaus_desc" : "paymentstaus_asc";

            var advets = _advertservice.GetAll(page, pageSize, sortOrder, searchString, currentFilter);
            ViewData["CurrentFilter"] = searchString;
            return View(advets);
        }
        [HttpGet("Create")]
        public IActionResult Create()
        {
            var advert = new Advert();
            advert.Media = _mediaservice.GetAll();
            advert.Language = _languageservice.GetAll();
            advert.Country = _CountryService.GetAll();
            return View(advert);
        }
        [HttpPost("Create")]
        [AllowAnonymous]
        public IActionResult Create([Bind(include: "Title,MediaTypeId,MediaUrl,DailyQuota,Countries,Cities,Languages,TotalAmount,PaymentStaus")]Advert advert)
        {
            if (ModelState.IsValid)
            {
                _advertservice.Create(advert);
                TempData["Message"] = "IsMessage";
                return RedirectToAction("Index");
            }
            else
            {
                advert.Media = _mediaservice.GetAll();
                advert.Language = _languageservice.GetAll();
                advert.Country = _CountryService.GetAll();
                return View(advert);
            }
        }

        [HttpGet("Edit")]
        [AllowAnonymous]
        public IActionResult Edit(int? Id, int? page)
        {
            var advert = _advertservice.GetByID(Id);
            ViewBag.IsEdit = "IsUpdate";
            TempData["Message"] = "IsMessage";
            advert.page = page;
            advert.Media = _mediaservice.GetAll();
            advert.Language = _languageservice.GetAll();
            advert.Country = _CountryService.GetAll();
            return View("Create", advert);
        }
        [HttpPost("Edit")]
        [AllowAnonymous]
        public IActionResult Edit([Bind(include: "Id,Title,MediaTypeId,MediaUrl,DailyQuota,Countries,Cities,Languages,TotalAmount,PaymentStaus")]Advert advert)
        {
            _advertservice.Edit(advert);
            return RedirectToAction("Index", new { page = advert.page });
        }
        [HttpGet("Delete")]
        [AllowAnonymous]
        public IActionResult Delete(int? Id)
        {
            _advertservice.Delete(Id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Produces("text/html")]
        public IActionResult GetCities(int[] Id)
        {
            var Cities = _CountryService.GetByCountryId(Id);
            return Content(Cities.ToString());
        }
    }
}