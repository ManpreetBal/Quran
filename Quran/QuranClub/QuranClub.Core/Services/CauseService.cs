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
    public class CauseService : ICauseService
    {
        private DBEntities _context;
        private DbSet<Cause> cause;
        public CauseService(DBEntities context)
        {
            this._context = context;
            cause = context.Set<Cause>();
        }
        public void Create(Cause cause)
        {
            _context.Cause.Add(cause);
            _context.SaveChanges();
        }

        public void Delete(int? Id)
        {
            _context.Cause.Remove(cause.Where(x => x.Id == Id).FirstOrDefault());
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Edit(Cause cause)
        {
            _context.Entry(cause).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public List<Cause> GetAll(int? page, int? pageSize, string sortOrder, string searchString, string currentFilter)
        {
            var TotalItemCount = cause.Count();
            IEnumerable<Cause> causes = (from a in _context.Cause
                                         join b in _context.Country on a.CountryId equals b.Id

                                         select new Cause
                                         {
                                             Id = a.Id,
                                             Title = a.Title,
                                             Description = a.Description,
                                             ImageUrl = a.ImageUrl,
                                             CreatedAt = a.CreatedAt,
                                             CountryName = b.CountryName,
                                         }).Skip((Convert.ToInt32(page) - 1) * Convert.ToInt32(pageSize)).Take(Convert.ToInt32(pageSize));
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            if (!string.IsNullOrEmpty(searchString))
            {
                causes = cause.Where(x => x.Title.Contains(searchString)).Skip((Convert.ToInt32(page) - 1) * Convert.ToInt32(pageSize)).Take(Convert.ToInt32(pageSize));
            }
            switch (sortOrder)
            {
                case "title_desc":
                    causes = causes.OrderByDescending(x => x.Title);
                    break;
                case "date_asc":
                    causes = causes.OrderBy(x => x.CreatedAt);
                    break;
                case "address_desc":
                    causes = causes.OrderByDescending(x => x.CreatedAt);
                    break;
                case "country_asc":
                    causes = causes.OrderBy(x => x.CountryName);
                    break;
                case "country_desc":
                    causes = causes.OrderByDescending(x => x.CountryName);
                    break;
                default:
                    causes = causes.OrderBy(x => x.Title);
                    break;
            }
            return new PagedList<Cause>(causes, page ?? 1, pageSize ?? 10, TotalItemCount);
            // return PaginatedList<Cause>.CreateAsync(causes.ToList(), page ?? 1, pageSize, count);
        }

        public IEnumerable<Cause> GetByCauseId(int? Id)
        {
            return cause.Where(x => x.Id == Id).AsEnumerable();
        }

        public Cause GetByID(int? Id)
        {
            return cause.Where(x => x.Id == Id).FirstOrDefault();
        }
    }
}
