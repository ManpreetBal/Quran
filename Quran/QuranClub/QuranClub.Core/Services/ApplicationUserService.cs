using Microsoft.EntityFrameworkCore;
using QuranClub.Core.Services.IServices;
using QuranClub.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuranClub.Domain.Entities;

namespace QuranClub.Core.Services
{
    public class ApplicationUserService : IApplicationUserService
    {
        private DBEntities _context;
        private DbSet<ApplicationUser> user;
        public ApplicationUserService(DBEntities context)
        {
            this._context = context;
            user = context.Set<ApplicationUser>();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
        public List<ApplicationUser> GetAll(int? page, int? pageSize, string sortOrder, string searchString, string currentFilter)
        {
            var TotalItemCount = user.Count();
            IEnumerable<ApplicationUser> users = (from a in _context.AspNetUsers
                                                  join b in _context.Country on a.Country equals b.Id
                                                  join c in _context.City on a.City equals c.Id

                                                  select new ApplicationUser
                                                  {
                                                      Id = a.Id,
                                                      FirstName = a.FirstName,
                                                      UserName = a.UserName,
                                                      Address = a.Address,
                                                      CountryName = b.CountryName,
                                                      CityName = c.CityName,
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
                users = users.Where(x => x.FirstName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "firstname_desc":
                    users = users.OrderByDescending(x => x.FirstName);
                    break;
                case "address_asc":
                    users = users.OrderBy(x => x.Address);
                    break;
                case "address_desc":
                    users = users.OrderByDescending(x => x.Address);
                    break;
                case "country_asc":
                    users = users.OrderBy(x => x.CountryName);
                    break;
                case "country_desc":
                    users = users.OrderByDescending(x => x.CountryName);
                    break;
                case "city_asc":
                    users = users.OrderBy(x => x.CityName);
                    break;
                case "city_desc":
                    users = users.OrderByDescending(x => x.CityName);
                    break;
                case "username_asc":
                    users = users.OrderBy(x => x.UserName);
                    break;
                case "username_desc":
                    users = users.OrderByDescending(x => x.UserName);
                    break;
                default:
                    users = users.OrderBy(x => x.FirstName);
                    break;
            }
            return new PagedList<ApplicationUser>(users, page ?? 1, pageSize ?? 10, TotalItemCount);
            // return PaginatedList<ApplicationUser>.CreateAsync(users.ToList(), page ?? 1, pageSize, count);
        }

        public void Delete(string Id)
        {

            _context.AspNetUsers.Remove(user.Where(x => x.Id == Id).FirstOrDefault());
            _context.SaveChanges();
        }
    }
}
