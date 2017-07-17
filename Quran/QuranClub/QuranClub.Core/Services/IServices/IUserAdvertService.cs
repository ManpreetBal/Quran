using QuranClub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuranClub.Core.Services.IServices
{
    public interface IUserAdvertService
    {
        void Create(UserAdvert useradvert);
        void Edit(UserAdvert useradvert);
        IEnumerable<UserAdvert> GetAll();
        IEnumerable<UserAdvert> GetByUserStatsId(int? Id);
        void Delete(int? Id);
        UserAdvert GetByID(int? Id);
        void Dispose();
    }
}
