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
    public class VerseService : IVerseService
    {
        private DBEntities _context;
        private DbSet<Verse> verse;
        public VerseService(DBEntities context)
        {
            this._context = context;
            verse = context.Set<Verse>();
        }
        public void Create(Verse verse)
        {
            _context.Verse.Add(verse);
            _context.SaveChanges();
        }

        public void Delete(int? Id)
        {
            _context.Verse.Remove(verse.Where(x => x.Id == Id).FirstOrDefault());
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Edit(Verse verse)
        {
            _context.Entry(verse).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public IEnumerable<Verse> GetAll()
        {
            return verse.AsEnumerable();
        }

        public Verse GetByID(int? Id)
        {
            return verse.Where(x => x.Id == Id).FirstOrDefault();
        }

        public IEnumerable<Verse> GetByVerseId(int? Id)
        {
            return verse.Where(x => x.Id == Id).AsEnumerable();
        }
    }
}
