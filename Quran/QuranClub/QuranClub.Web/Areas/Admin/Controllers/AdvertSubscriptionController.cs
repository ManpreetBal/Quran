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
    [Route("Admin/AdvertSubscription")]
    public class AdvertSubscriptionController : Controller
    {
        private readonly IAdvertSubscriptionService _advertsubscriptionservice;
        public AdvertSubscriptionController(IAdvertSubscriptionService service)
        {
            this._advertsubscriptionservice = service;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Index(string sortOrder, string searchString, int? page, string currentFilter,int? pageSize)
        {
            pageSize = pageSize.HasValue ? pageSize.Value : 10;
            page = page.HasValue ? page.Value : 1;
            ViewData["CurrentSort"] = sortOrder;
            ViewData["TierSortParm"] = string.IsNullOrEmpty(sortOrder) ? "tier_desc" : "";
            ViewData["VideoRateSortParm"] = string.IsNullOrEmpty(sortOrder) ? "videorate_desc" : "videorate_asc";
            ViewData["VideoTotalSortParm"] = string.IsNullOrEmpty(sortOrder) ? "videototal_desc" : "videototal_asc";
            ViewData["ImageRateSortParm"] = string.IsNullOrEmpty(sortOrder) ? "imagerate_desc" : "imagerate_asc";
            ViewData["ImageTotalSortParm"] = string.IsNullOrEmpty(sortOrder) ? "imagetotal_desc" : "imagetotal_asc";
            ViewData["PerClickSortParm"] = string.IsNullOrEmpty(sortOrder) ? "perclick_desc" : "perclick_asc";
            ViewData["PercentageToCharitySortParm"] = string.IsNullOrEmpty(sortOrder) ? "percentagetocharity_desc" : "percentagetocharity_asc";

            var advertsubscription = _advertsubscriptionservice.GetAll(page, pageSize, sortOrder, searchString, currentFilter);

            ViewData["CurrentFilter"] = searchString;
            return View(advertsubscription);
        }
        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost("Create")]
        [AllowAnonymous]
        public IActionResult Create([Bind(include: "Tier,VideoRate,VideoTotal,ImageRate,ImageTotal,PerClick,PercentageToCharity")]AdvertSubscription advertsubscription)
        {
            if (ModelState.IsValid)
            {
                _advertsubscriptionservice.Create(advertsubscription);
                TempData["Message"] = "IsMessage";
                return RedirectToAction("Index");
            }
            else
                return View(advertsubscription);
        }

        [HttpGet("Edit")]
        [AllowAnonymous]
        public IActionResult Edit(int? Id, int? page)
        {
            var advertsubscription = _advertsubscriptionservice.GetByID(Id);
            ViewBag.IsEdit = "IsUpdate";
            advertsubscription.page = page;
            TempData["Message"] = "IsMessage";
            return View("Create", advertsubscription);
        }
        [HttpPost("Edit")]
        [AllowAnonymous]
        public IActionResult Edit([Bind(include: "Id,Tier,VideoRate,VideoTotal,ImageRate,ImageTotal,PerClick,PercentageToCharity")]AdvertSubscription advertsubscription)
        {
            _advertsubscriptionservice.Edit(advertsubscription);
            return RedirectToAction("Index", new { page = advertsubscription.page });
        }
        [HttpGet("Delete")]
        [AllowAnonymous]
        public IActionResult Delete(int? Id)
        {
            _advertsubscriptionservice.Delete(Id);
            return RedirectToAction("Index");
        }
    }
}