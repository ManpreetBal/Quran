using QuranClub.Core.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using QuranClub.Domain.Entities;
using QuranClub.Repository;

namespace QuranClub.Core.Services
{
    public class UserGroupService : IUserGroupService
    {
        private DBEntities _context;
        private DbSet<UserGroup> usergroup;
        public UserGroupService(DBEntities context)
        {
            this._context = context;
            usergroup = context.Set<UserGroup>();
        }

        public void Create(UserGroup group)
        {
            _context.UserGroup.Add(group);
            _context.SaveChanges();
        }

        public void Delete(int? Id)
        {
            _context.UserGroup.Remove(usergroup.Where(x => x.Id == Id).FirstOrDefault());
            _context.SaveChanges();
        }


        public void Dispose()
        {
            _context.Dispose();
        }

        public void Edit(UserGroup group)
        {
            _context.Entry(group).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public IEnumerable<UserGroup> GetAll()
        {
            return usergroup.AsEnumerable();
        }

        public UserGroup GetByID(int? Id)
        {
            return usergroup.Where(x => x.Id == Id).FirstOrDefault();
        }

        public IEnumerable<UserGroup> GetByUserGroupId(int? Id)
        {
            return usergroup.Where(x => x.Id == Id).AsEnumerable();
        }
    }
}
