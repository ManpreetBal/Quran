using QuranClub.Core.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using QuranClub.Repository;
using QuranClub.Domain.Entities;

namespace QuranClub.Core.Services
{
    public class GroupService : IGroupService
    {

        private DBEntities _context;
        private DbSet<Group> group;
        private DbSet<ApplicationUser> user;
        public GroupService(DBEntities context)
        {
            this._context = context;
            group = context.Set<Group>();
            user = context.Set<ApplicationUser>();
        }

        public void Delete(int? ID)
        {
            _context.Group.Remove(group.Where((x => x.Id == ID)).FirstOrDefault());
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Create(Group group)
        {
            _context.Group.Add(group);
            _context.SaveChanges();
        }

        public void Edit(Group group)
        {
            _context.Entry(group).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public List<Group> GetAll(int? page, int? pageSize, string sortOrder, string searchString, string currentFilter)
        {
            var TotalItemCount = _context.Group.Count();
            IEnumerable<Group> groups = (from a in _context.Group
                                         join b in @user on a.CreatedByUserId equals b.Id

                                         select new Group
                                         {
                                             Id = a.Id,
                                             Name = a.Name,
                                             Description = a.Description,
                                             CreatedByUserName = b.UserName,
                                             CreatedAt = a.CreatedAt,
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
                groups = group.Where(x => x.Name.Contains(searchString)).Skip((Convert.ToInt32(page) - 1) * Convert.ToInt32(pageSize)).Take(Convert.ToInt32(pageSize));

            }
            switch (sortOrder)
            {
                case "name_desc":
                    groups = groups.OrderByDescending(x => x.Name);
                    break;
                case "createdbyusername_asc":
                    groups = groups.OrderBy(x => x.CreatedByUserName);
                    break;
                case "createdbyusername_desc":
                    groups = groups.OrderByDescending(x => x.CreatedByUserName);
                    break;
                case "description_asc":
                    groups = groups.OrderBy(x => x.Description);
                    break;
                case "description_desc":
                    groups = groups.OrderByDescending(x => x.Description);
                    break;
                case "date_asc":
                    groups = groups.OrderBy(x => x.CreatedAt);
                    break;
                case "date_desc":
                    groups = groups.OrderByDescending(x => x.CreatedAt);
                    break;
                case "name_asc":
                    groups = groups.OrderBy(x => x.Name);
                    break;
            }
            return new PagedList<Group>(groups, page ?? 1, pageSize ?? 10, TotalItemCount);
            //  return PaginatedList<Group>.CreateAsync(groups.ToList(), page ?? 1, pageSize, count);
        }

        public IEnumerable<Group> GetByGroupId(int? Id)
        {
            return group.Where(x => x.Id == Id).AsEnumerable();
        }

        public Group GetByID(int? Id)
        {
            return group.Where(x => x.Id == Id).FirstOrDefault();
        }
    }
}
