using QuranClub.Domain.Entities;
using QuranClub.Core.Services.IServices;
using QuranClub.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace QuranClub.Core.Services
{
    public class AdminService:IAdminService
    {
        private DBEntities _context;
        private DbSet<Admin> Admin;
        public AdminService(DBEntities context)
        {
            this._context = context;
            Admin = context.Set<Admin>();
        }
        public Admin GetLoggedAdmin(int? Id)
        {
            return Admin.Where(x => x.Id == Id).FirstOrDefault();
        }

        public Admin GetLogin(string Username, string password)
        {
            return Admin.Where(x => x.Username == Username && x.Password == password).FirstOrDefault();
        }

        public bool IsLogin(string Username, string password)
        {
            var Admins = Admin.Where(x => x.Username == Username && x.Password == password).FirstOrDefault();
            if (Admins != null)
            {
                return true;
            }
            else
                return false;
        }

        public bool IsLogOut()
        {
            return true;
        }
    }
}
