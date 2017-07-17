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
    public class VerseReadService : IVerseReadService
    {
        private DBEntities _context;
        private DbSet<VerseRead> verseread;
        public VerseReadService(DBEntities context)
        {
            this._context = context;
            verseread = context.Set<VerseRead>();
        }

        public void Create(VerseRead verseread)
        {
            _context.VerseRead.Add(verseread);
            _context.SaveChanges();
        }

        public void Delete(int? ID)
        {
            _context.VerseRead.Remove(verseread.Where(x => x.Id == ID).FirstOrDefault());
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Edit(VerseRead verseread)
        {
            _context.Entry(verseread).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public IEnumerable<VerseRead> GetAll()
        {
            return verseread.AsEnumerable();
        }

        public VerseRead GetByID(int? ID)
        {
            return verseread.Where(x => x.Id == ID).FirstOrDefault();
        }
    }
}
