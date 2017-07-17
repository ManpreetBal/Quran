using QuranClub.Core.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using QuranClub.Repository;
using QuranClub.Domain.Entities;
using cloudscribe.Web.Pagination;

namespace QuranClub.Core.Services
{
    public class CharityService : ICharityService
    {
        private DBEntities _context;
        private DbSet<Charity> charity;
        public CharityService(DBEntities context)
        {
            this._context = context;
            charity = context.Set<Charity>();
        }
        public void Create(Charity charity)
        {
            _context.Charity.Add(charity);
            _context.SaveChanges();
        }

        public void Delete(int? Id)
        {
            _context.Charity.Remove(charity.Where(x => x.Id == Id).FirstOrDefault());
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Edit(Charity charity)
        {
            _context.Entry(charity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public IEnumerable<Charity> GetByCharityId(int? Id)
        {
            return charity.Where(x => x.Id == Id).AsEnumerable();
        }

        public Charity GetByID(int? Id)
        {
            return charity.Where(x => x.Id == Id).FirstOrDefault();
        }

        public List<Charity> GetAll(int? page, int? pageSize, string sortOrder, string searchString, string currentFilter)
        {
            var TotalItemCount = charity.Count();
            var items = charity.Skip((Convert.ToInt32(page) - 1) * Convert.ToInt32(pageSize)).Take(Convert.ToInt32(pageSize));
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
                items = charity.Where(x => x.Name.Contains(searchString)).Skip((Convert.ToInt32(page) - 1) * Convert.ToInt32(pageSize)).Take(Convert.ToInt32(pageSize));
            }

            switch (sortOrder)
            {
                case "name_desc":

                    items = items.OrderByDescending(x => x.Name);
                    break;
                default:
                    items = items.OrderBy(x => x.Name);
                    break;
            }
            return new PagedList<Charity>(items, page ?? 1, pageSize ?? 10, TotalItemCount);
            //   return PaginatedList<Charity>.CreateAsync(items.ToList(), page ?? 1, pageSize, count);
        }
    }
}
