using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuranClub.Core.Services.IServices;
using QuranClub.Domain.Entities;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace QuranClub.Web.Controllers
{
    [Route("api/v1")]

    public class CountryController : Controller
    {
        private ICountryService countryservice;
        public CountryController(ICountryService dbc)
        {
            this.countryservice = dbc;
        }
        // GET: api/v1/countries
        [HttpGet("countries")]
        public IEnumerable<Country> Get()
        {
            return countryservice.GetAll();
        }
        // Post: api/v1/country by id
        [HttpPost("country")]
        public Country GetByCountryId(int Id)
        {
            return countryservice.GetByID(Id);
        }
    }
}
