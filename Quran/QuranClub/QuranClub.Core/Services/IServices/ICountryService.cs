using QuranClub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuranClub.Core.Services.IServices
{
    public interface ICountryService
    {
        void Create(Country country);
        void Edit(Country country);
        IEnumerable<Country> GetAll();
        StringBuilder GetByCountryId(int[] ID);
        void Delete(int? ID);
        Country GetByID(int? ID);
        void Dispose();
    }
}
