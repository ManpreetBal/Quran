using QuranClub.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuranClub.Core.Services;
using QuranClub.Repository;
using Microsoft.EntityFrameworkCore;
using QuranClub.Core.Services.IServices;
using QuranClub.Domain.Entities;
using System.Text;

namespace QuranClub.Core.Services
{
    public class CountryService : ICountryService, IDisposable
    {
        private DBEntities _context;
        private DbSet<Country> country;
        public CountryService(DBEntities context)
        {
            this._context = context;
            country = context.Set<Country>();
        }

        public void Create(Country country)
        {
            _context.Country.Add(country);
            _context.SaveChanges();
        }

        public void Delete(int? ID)
        {
            _context.Country.Remove(_context.Country.Where(x => x.Id == ID).FirstOrDefault());
            _context.SaveChanges();
        }

        public void Edit(Country country)
        {
            _context.Entry(country).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public IEnumerable<Country> GetAll()
        {
            return country.AsEnumerable();
        }

        public Country GetByID(int? ID)
        {
            return _context.Country.Where(x => x.Id == ID).FirstOrDefault();
        }

        StringBuilder ICountryService.GetByCountryId(int[] ID)
        {
            // throw new NotImplementedException();
            StringBuilder html = new StringBuilder();
            for (int i = 0; i <= ID.Length - 1; i++)
            {
                var countryname = _context.Country.Where(x => x.Id == ID[i]).Select(x => x.CountryName).FirstOrDefault();
                var cities = _context.City.Where(x => x.CountryId == ID[i]).ToList();
                if (cities.Count > 0)
                {
                    html.Append("<optgroup label=" + countryname  + ">");
                    foreach (var item in cities)
                    {
                        html.Append("<option value=" + item.Id + ">" + item.CityName + "</option>");
                    }
                    html.Append("</optgroup>");
                }
            }
            return html;
        }
        public void Dispose()
        {
            _context.Dispose ();
        }
    }
}
