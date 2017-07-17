using Microsoft.EntityFrameworkCore;
using QuranClub.Core.Services.IServices;
using QuranClub.Domain.Entities;
using QuranClub.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace QuranClub.Core.Services
{
    public class LanguageService : ILanguagesService, IDisposable
    {
        private DBEntities _context;
        private DbSet<Languages> language;
        public LanguageService(DBEntities context)
        {
            this._context = context;
            language = context.Set<Languages>();
        }
        public void Create(Languages language)
        {
            _context.Language.Add(language);
            _context.SaveChanges();
        }

        public void Delete(int? ID)
        {
            _context.Language.Remove(language.Where(x => x.Id == ID).FirstOrDefault());
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Edit(Languages language)
        {
            _context.Entry(language).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public IEnumerable<Languages> GetAll()
        {
          return  language.AsEnumerable();
        }

        public Languages GetByID(int? ID)
        {
            return language.Where(x => x.Id == ID).FirstOrDefault();
        }
    }
}
