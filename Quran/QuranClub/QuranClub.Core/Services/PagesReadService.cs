using QuranClub.Core.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuranClub.Repository;
using QuranClub.Domain.Entities;

namespace QuranClub.Core.Services
{
    public class PagesReadService : IPagesReadService
    {
        private DBEntities _context;
        private DbSet<PagesRead> pagesread;
        public PagesReadService(DBEntities context)
        {
            this._context = context;
            pagesread = context.Set<PagesRead>();
        }

        public void Create(PagesRead pagesread)
        {
            _context.PagesRead.Add(pagesread);
            _context.SaveChanges();
        }

        public void Delete(int? ID)
        {
            _context.PagesRead.Remove(pagesread.Where(x => x.Id == ID).FirstOrDefault());
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Edit(PagesRead pagesread)
        {
            _context.Entry(pagesread).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public IEnumerable<PagesRead> GetAll()
        {
            return pagesread.AsEnumerable();
        }

        public PagesRead GetByID(int? ID)
        {
            return pagesread.Where(x => x.Id == ID).FirstOrDefault();
        }
    }
}
