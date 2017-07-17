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
    public class UserAdvertService : IUserAdvertService
    {
        private DBEntities _context;
        private DbSet<UserAdvert> useradvert;
        public UserAdvertService(DBEntities context)
        {
            this._context = context;
            useradvert = context.Set<UserAdvert>();
        }
        public void Create(UserAdvert useradvert)
        {
            _context.UserAdvert.Add(useradvert);
            _context.SaveChanges();
        }

        public void Delete(int? Id)
        {
            _context.UserAdvert.Remove(useradvert.Where(x => x.Id == Id).FirstOrDefault());
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Edit(UserAdvert useradvert)
        {
            _context.Entry(useradvert).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public IEnumerable<UserAdvert> GetAll()
        {
            return useradvert.AsEnumerable();
        }

        public UserAdvert GetByID(int? Id)
        {
            return useradvert.Where(x => x.Id == Id).FirstOrDefault();
        }

        public IEnumerable<UserAdvert> GetByUserStatsId(int? Id)
        {
            return useradvert.Where(x => x.Id == Id).AsEnumerable();
        }
    }
}
