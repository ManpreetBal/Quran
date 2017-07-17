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
    public class AdvertSubscriptionService : IAdvertSubscriptionService
    {
        private DBEntities _context;
        private DbSet<AdvertSubscription> advertsubscription;
        public AdvertSubscriptionService(DBEntities context)
        {
            this._context = context;
            advertsubscription = context.Set<AdvertSubscription>();
        }
        public void Create(AdvertSubscription advertsubscription)
        {
            _context.AdvertSubscription.Add(advertsubscription);
            _context.SaveChanges();
        }

        public void Delete(int? Id)
        {
            _context.AdvertSubscription.Remove(advertsubscription.Where(x => x.Id == Id).FirstOrDefault());
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Edit(AdvertSubscription advertsubscription)
        {
            _context.Entry(advertsubscription).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public List<AdvertSubscription> GetAll(int? page, int? pageSize, string sortOrder, string searchString, string currentFilter)
        {
            var TotalItemCount = advertsubscription.Count();
            var advertsubscriptions = advertsubscription.Skip((Convert.ToInt32(page) - 1) * Convert.ToInt32(pageSize)).Take(Convert.ToInt32(pageSize));
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
                advertsubscriptions = advertsubscription.Where(x => x.Tier.Contains(searchString)).Skip((Convert.ToInt32(page) - 1) * Convert.ToInt32(pageSize)).Take(Convert.ToInt32(pageSize));
            }
            switch (sortOrder)
            {
                case "tier_desc":
                    advertsubscriptions = advertsubscriptions.OrderByDescending(x => x.Tier);
                    break;
                case "videorate_asc":
                    advertsubscriptions = advertsubscriptions.OrderBy(x => x.VideoRate);
                    break;
                case "videorate_desc":
                    advertsubscriptions = advertsubscriptions.OrderByDescending(x => x.VideoRate);
                    break;
                case "videototal_asc":
                    advertsubscriptions = advertsubscriptions.OrderBy(x => x.VideoTotal);
                    break;
                case "videototal_desc":
                    advertsubscriptions = advertsubscriptions.OrderByDescending(x => x.VideoTotal);
                    break;
                case "imagerate_asc":
                    advertsubscriptions = advertsubscriptions.OrderBy(x => x.ImageRate);
                    break;
                case "imagerate_desc":
                    advertsubscriptions = advertsubscriptions.OrderByDescending(x => x.ImageRate);
                    break;
                case "imagetotal_asc":
                    advertsubscriptions = advertsubscriptions.OrderBy(x => x.ImageTotal);
                    break;
                case "imagetotal_desc":
                    advertsubscriptions = advertsubscriptions.OrderByDescending(x => x.ImageTotal);
                    break;
                case "perclick_asc":
                    advertsubscriptions = advertsubscriptions.OrderBy(x => x.PerClick);
                    break;
                case "perclick_desc":
                    advertsubscriptions = advertsubscriptions.OrderByDescending(x => x.PerClick);
                    break;
                case "percentagetocharity_asc":
                    advertsubscriptions = advertsubscriptions.OrderBy(x => x.PercentageToCharity);
                    break;
                case "percentagetocharity_desc":
                    advertsubscriptions = advertsubscriptions.OrderByDescending(x => x.PercentageToCharity);
                    break;
                default:
                    advertsubscriptions = advertsubscription.OrderBy(x => x.Tier);
                    break;
            }
            return new PagedList<AdvertSubscription>(advertsubscriptions, page ?? 1, pageSize ?? 10, TotalItemCount);
            // return PaginatedList<AdvertSubscription>.CreateAsync(advertsubscriptions.ToList(), page ?? 1, pageSize, count);
        }

        public IEnumerable<AdvertSubscription> GetByAdvertId(int? Id)
        {
            return advertsubscription.Where(x => x.Id == Id).AsEnumerable();
        }

        public AdvertSubscription GetByID(int? Id)
        {
            return advertsubscription.Where(x => x.Id == Id).FirstOrDefault();
        }
    }
}
