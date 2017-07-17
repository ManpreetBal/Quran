using QuranClub.Domain.Entities;
using System.Collections.Generic;

namespace QuranClub.Core.Services.IServices
{
    public interface ICharityService
    {
        void Create(Charity charity);
        void Edit(Charity charity);
        List<Charity> GetAll(int? page, int? pageSize, string sortOrder, string searchString, string currentFilter);
        IEnumerable<Charity> GetByCharityId(int? Id);
        void Delete(int? Id);
        Charity GetByID(int? Id);
        void Dispose(); 
    }
}
