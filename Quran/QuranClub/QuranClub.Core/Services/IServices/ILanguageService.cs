using QuranClub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuranClub.Core.Services.IServices
{
    public interface ILanguagesService
    {
        void Create(Languages language);
        void Edit(Languages language);
        IEnumerable<Languages> GetAll();
        void Delete(int? ID);
        Languages GetByID(int? ID);
        void Dispose();
    }
}
