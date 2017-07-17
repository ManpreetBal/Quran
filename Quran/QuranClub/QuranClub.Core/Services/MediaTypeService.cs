using QuranClub.Core.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuranClub.Repository;
using QuranClub.Domain.Entities;

namespace QuranClub.Core.Services
{
    public class MediaTypeService : IMediaTypeService
    {
        private DBEntities _context;
        private DbSet<MediaType> mediatype;
        public MediaTypeService(DBEntities context)
        {
            this._context = context;
            mediatype = context.Set<MediaType>();
        }
        public void Create(MediaType mediatype)
        {
            _context.MediaType.Add(mediatype);
            _context.SaveChanges();
        }

        public void Delete(int? Id)
        {
            _context.MediaType.Remove(mediatype.Where(x => x.Id == Id).FirstOrDefault());
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Edit(MediaType mediatype)
        {
            _context.Entry(mediatype).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public IEnumerable<MediaType> GetAll()
        {
            return mediatype.AsEnumerable();
        }

        public IEnumerable<MediaType> GetByMediaId(int? Id)
        {
            return mediatype.Where(x => x.Id == Id).AsEnumerable();
        }

        public MediaType GetByID(int? Id)
        {
            return mediatype.Where(x => x.Id == Id).FirstOrDefault();
        }
    }
}
