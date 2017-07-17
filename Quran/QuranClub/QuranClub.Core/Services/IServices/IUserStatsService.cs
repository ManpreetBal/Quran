using QuranClub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuranClub.Core.Services.IServices
{
    public interface IUserStatsService
    {
        void Create(UserStats userstats);
        void Edit(UserStats userstats);
        IEnumerable<UserStats> GetAll();
        IEnumerable<UserStats> GetByUserStatsId(int? Id);
        void Delete(int? Id);
        UserStats GetByID(int? Id);
        void Dispose();
    }
}
