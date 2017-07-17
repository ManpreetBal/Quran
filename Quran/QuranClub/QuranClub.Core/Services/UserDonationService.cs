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
    public class UserDonationService : IUserDonationService
    {
        private DBEntities _context;
        private DbSet<UserDonation> userdonation;
        public UserDonationService(DBEntities context)
        {
            this._context = context;
            userdonation = context.Set<UserDonation>();
        }
        public void Create(UserDonation userdonation)
        {
            _context.UserDonation.Add(userdonation);
            _context.SaveChanges();
        }

        public void Delete(int? Id)
        {
            _context.UserDonation.Remove(userdonation.Where(x => x.Id == Id).FirstOrDefault());
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Edit(UserDonation userdonation)
        {
            _context.Entry(userdonation).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public IEnumerable<UserDonation> GetAll()
        {
            return userdonation.AsEnumerable();
        }

        public UserDonation GetByID(int? Id)
        {
            return userdonation.Where(x => x.Id == Id).FirstOrDefault();
        }

        public IEnumerable<UserDonation> GetByUserDonationId(int? Id)
        {
            return userdonation.Where(x => x.Id == Id).AsEnumerable();
        }
    }
}
