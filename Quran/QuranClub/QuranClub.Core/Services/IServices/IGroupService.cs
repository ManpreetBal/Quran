using PagedList.Core;
using QuranClub.Domain.Entities;
using System.Collections.Generic;

namespace QuranClub.Core.Services.IServices
{
    public interface IGroupService
    {
        void Create(Group group);
        void Edit(Group group);
        List<Group> GetAll(int? page, int? pageSize, string sortOrder, string searchString, string currentFilter);
        IEnumerable<Group> GetByGroupId(int? Id);
        void Delete(int? Id);
        Group GetByID(int? Id);
        void Dispose();
    }
}
