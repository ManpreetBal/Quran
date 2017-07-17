using QuranClub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuranClub.Core.Services.IServices
{
   public interface IVerseService
    {
        void Create(Verse verse);
        void Edit(Verse verse);
        IEnumerable<Verse> GetAll();
        IEnumerable<Verse> GetByVerseId(int? Id);
        void Delete(int? Id);
        Verse GetByID(int? Id);
        void Dispose();
    }
}
