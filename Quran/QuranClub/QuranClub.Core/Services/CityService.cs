using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuranClub.Core.Services;
using QuranClub.Core.Services.IServices;
using Microsoft.EntityFrameworkCore;
using QuranClub.Repository;
using QuranClub.Domain.Entities;
using System.Text;

namespace QuranClub.Core.Services
{
    public class CityService : ICityService, IDisposable
    {
        private DBEntities _context;
        private DbSet<City> city;
        public CityService(DBEntities context)
        {
            this._context = context;
            city = context.Set<City>();
        }
        public void Create(City city)
        {
            _context.City.Add(city);
            _context.SaveChanges();
        }

        public void Delete(int? ID)
        {
            _context.City.Remove(city.Where(x => x.Id == ID).FirstOrDefault());
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Edit(City city)
        {
            _context.Entry(city).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public IEnumerable<City> GetAll()
        {
            return city.AsEnumerable();
        }

        public IEnumerable<City> GetByCountryId(int? ID)
        {
            return city.Where(x => x.CountryId == ID).AsEnumerable();
        }

        public City GetByID(int? ID)
        {
            return city.Where(x => x.Id == ID).FirstOrDefault();
        }
    }
}
