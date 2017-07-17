using QuranClub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuranClub.Core.Services.IServices
{
    public interface IUserGroupService
    {
        void Create(UserGroup group);
        void Edit(UserGroup group);
        IEnumerable<UserGroup> GetAll();
        IEnumerable<UserGroup> GetByUserGroupId(int? Id);
        void Delete(int? Id);
        UserGroup GetByID(int? Id);
        void Dispose();
    }
}
