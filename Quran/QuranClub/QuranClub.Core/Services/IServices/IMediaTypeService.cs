using QuranClub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuranClub.Core.Services.IServices
{
    public interface IMediaTypeService
    {
        void Create(MediaType mediatype);
        void Edit(MediaType mediatype);
        IEnumerable<MediaType> GetAll();
        IEnumerable<MediaType> GetByMediaId(int? Id);
        void Delete(int? Id);
        MediaType GetByID(int? Id);
        void Dispose();
    }
}
