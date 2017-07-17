using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuranClub.Domain.Entities;
using QuranClub.Core.Services.IServices;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace QuranClub.Web.Controllers
{
    [Route("api/V1")]
    public class CityController : Controller
    {
        private ICityService cityservice;
        public CityController(ICityService dbl)
        {
            this.cityservice = dbl;
        }
        // GET: api/v1/Cities
        [HttpGet("cities")]
        public IEnumerable<City> GetCity()
        {
            return cityservice.GetAll();
        }
        // Post: api/v1/Cities
        [HttpPost("citybycountry")]
        public IEnumerable<City> GetByCountryId( int id)
        {
            return cityservice.GetByCountryId(id);
        }
    }
}
