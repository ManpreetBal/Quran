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
    public class KhatmService : IKhatmService
    {
        private DBEntities _context;
        private DbSet<Khatm> khatm;
        public KhatmService(DBEntities context)
        {
            this._context = context;
            khatm = context.Set<Khatm>();
        }
        public void Create(Khatm khatm)
        {
            _context.Khatm.Add(khatm);
            _context.SaveChanges();
        }

        public void Delete(int? Id)
        {
            _context.Khatm.Remove(khatm.Where(x => x.Id == Id).FirstOrDefault());
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Edit(Khatm khatm)
        {
            _context.Entry(khatm).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public IEnumerable<Khatm> GetAll()
        {
            return khatm.AsEnumerable();
        }

        public Khatm GetByID(int? Id)
        {
            return khatm.Where(x => x.Id == Id).FirstOrDefault();
        }

        public IEnumerable<Khatm> GetByKhatmId(int? Id)
        {
            return khatm.Where(x => x.Id == Id).AsEnumerable();
        }
    }
}
