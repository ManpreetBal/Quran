using QuranClub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuranClub.Core.Services.IServices
{
    public interface IKhatmService
    {
        void Create(Khatm khatm);
        void Edit(Khatm khatm);
        IEnumerable<Khatm> GetAll();
        IEnumerable<Khatm> GetByKhatmId(int? Id);
        void Delete(int? Id);
        Khatm GetByID(int? Id);
        void Dispose();
    }
}
