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
    public class UserService : IUserService, IDisposable
    {
        private DBEntities _context;
        private DbSet<User> user;
        public UserService(DBEntities context)
        {
            this._context = context;
            user = context.Set<User>();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
        public IEnumerable<User> GetAll()
        {
            return user.AsEnumerable();
        }

    }
}
