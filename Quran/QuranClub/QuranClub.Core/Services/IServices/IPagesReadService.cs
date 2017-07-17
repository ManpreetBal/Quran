using QuranClub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuranClub.Core.Services.IServices
{
    public interface IPagesReadService
    {
        void Create(PagesRead pagesread);
        void Edit(PagesRead pagesread);
        IEnumerable<PagesRead> GetAll();
        void Delete(int? ID);
        PagesRead GetByID(int? ID);
        void Dispose();
    }
}
