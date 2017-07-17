using QuranClub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuranClub.Core.Services.IServices
{
    public interface IApplicationUserService
    {
        List<ApplicationUser> GetAll(int? page, int? pageSize, string sortOrder, string searchString, string currentFilter);
        void Delete(string Id);
        void Dispose();
    }
}
