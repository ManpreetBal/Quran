using QuranClub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuranClub.Core.Services.IServices
{
    public interface ICauseService
    {
        void Create(Cause cause);
        void Edit(Cause cause);
        List<Cause> GetAll(int? page, int? pageSize, string sortOrder, string searchString, string currentFilter);
        IEnumerable<Cause> GetByCauseId(int? Id);
        void Delete(int? Id);
        Cause GetByID(int? Id);
        void Dispose();
    }
}
