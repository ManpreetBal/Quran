using QuranClub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuranClub.Core.Services.IServices
{
   public  interface IVerseReadService
    {
        void Create(VerseRead verseread);
        void Edit(VerseRead verseread);
        IEnumerable<VerseRead> GetAll();
        void Delete(int? ID);
        VerseRead GetByID(int? ID);
        void Dispose();
    }
}
