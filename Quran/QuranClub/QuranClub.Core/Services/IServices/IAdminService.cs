using QuranClub.Domain;
using QuranClub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuranClub.Core.Services.IServices
{
   public interface IAdminService
    {
        Admin GetLogin(string Username, string password);
        bool IsLogin(string Username, string password);
        Admin GetLoggedAdmin(int? Id);
        bool IsLogOut();
    }
}
