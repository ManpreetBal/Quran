using QuranClub.Domain.Entities;
using System.Collections.Generic;
using System.Text;

namespace QuranClub.Core.Services.IServices
{
    public interface ICityService
    {
        void Create(City city);
        void Edit(City city);
        IEnumerable<City> GetAll();
        IEnumerable<City> GetByCountryId(int? ID);
        void Delete(int? ID);
        City GetByID(int? ID);
        void Dispose();
    }
}
