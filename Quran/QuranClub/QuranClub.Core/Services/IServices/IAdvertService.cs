using QuranClub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuranClub.Core.Services.IServices
{
   public interface IAdvertService
    {
        void Create(Advert advert);
        void Edit(Advert advert);
        List<Advert> GetAll(int? page, int? pageSize, string sortOrder, string searchString, string currentFilter);
        IEnumerable<Advert> GetByAdvertId(int? Id);
        void Delete(int? Id);
        Advert GetByID(int? Id);
        void Dispose();
    }
}
