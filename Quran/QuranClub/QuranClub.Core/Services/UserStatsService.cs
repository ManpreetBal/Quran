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
    public class UserStatsService : IUserStatsService
    {
        private DBEntities _context;
        private DbSet<UserStats> userstats;
        public UserStatsService(DBEntities context)
        {
            this._context = context;
            userstats = context.Set<UserStats>();
        }
        public void Create(UserStats userstats)
        {
            _context.UserStats.Add(userstats);
            _context.SaveChanges();
        }

        public void Delete(int? Id)
        {
            _context.UserStats.Remove(userstats.Where(x => x.Id == Id).FirstOrDefault());
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Edit(UserStats userstats)
        {
            _context.Entry(userstats).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public IEnumerable<UserStats> GetAll()
        {
            return userstats.AsEnumerable();
        }

        public UserStats GetByID(int? Id)
        {
            return userstats.Where(x => x.Id == Id).FirstOrDefault();
        }

        public IEnumerable<UserStats> GetByUserStatsId(int? Id)
        {
            return userstats.Where(x => x.Id == Id).AsEnumerable();
        }
    }
}
