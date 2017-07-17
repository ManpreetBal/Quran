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
    [Route("api/V1")]
    public class LanguageController : Controller
    {
        private ILanguagesService languageservice;
        public LanguageController(ILanguagesService dbl)
        {
            this.languageservice = dbl;
        }
        // GET: api/v1/languages
        [HttpGet("languages")]
        public IEnumerable<Languages> GetLanguage()
        {
            return languageservice.GetAll();
        }
        // Post: api/v1/country by id
        [HttpPost("language")]
        public Languages GetBylanguageId(int Id)
        {
            return languageservice.GetByID(Id);
        }
    }
}
