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
    public class AdvertService : IAdvertService
    {
        private DBEntities _context;
        private DbSet<Advert> advert;

        public AdvertService(DBEntities context)
        {
            this._context = context;
            advert = context.Set<Advert>();
        }
        public void Create(Advert advert)
        {
            _context.Advert.Add(advert);
            _context.SaveChanges();
        }

        public void Delete(int? Id)
        {
            _context.Advert.Remove(advert.Where(x => x.Id == Id).FirstOrDefault());
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Edit(Advert advert)
        {
            _context.Entry(advert).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public List<Advert> GetAll(int? page, int? pageSize, string sortOrder, string searchString, string currentFilter)
        {
            var TotalItemCount = advert.Count();
            IEnumerable<Advert> adverts = (from a in _context.Advert
                                           join b in _context.MediaType on a.MediaTypeId equals b.Id

                                           select new Advert
                                           {
                                               Id = a.Id,
                                               Title = a.Title,
                                               MediaType = b.Type,
                                               MediaUrl = a.MediaUrl,
                                               DailyQuota = a.DailyQuota,
                                               TotalAmount = a.TotalAmount,
                                               PaymentStaus = a.PaymentStaus,
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
                adverts = advert.Where(x => x.Title.Contains(searchString)).Skip((Convert.ToInt32(page) - 1) * Convert.ToInt32(pageSize)).Take(Convert.ToInt32(pageSize));
            }
            switch (sortOrder)
            {
                case "title_desc":
                    adverts = adverts.OrderByDescending(x => x.Title);
                    break;
                case "mediatype_asc":
                    adverts = adverts.OrderBy(x => x.MediaType);
                    break;
                case "mediatype_desc":
                    adverts = adverts.OrderByDescending(x => x.MediaType);
                    break;
                case "mediaurl_asc":
                    adverts = adverts.OrderBy(x => x.MediaUrl);
                    break;
                case "mediaurl_desc":
                    adverts = adverts.OrderByDescending(x => x.MediaUrl);
                    break;
                case "dailyquota_asc":
                    adverts = adverts.OrderBy(x => x.DailyQuota);
                    break;
                case "dailyquota_desc":
                    adverts = adverts.OrderByDescending(x => x.DailyQuota);
                    break;
                case "totalamount_asc":
                    adverts = adverts.OrderBy(x => x.TotalAmount);
                    break;
                case "totalamount_desc":
                    adverts = adverts.OrderByDescending(x => x.TotalAmount);
                    break;
                case "paymentstaus_asc":
                    adverts = adverts.OrderBy(x => x.PaymentStaus);
                    break;
                case "paymentstaus_desc":
                    adverts = adverts.OrderByDescending(x => x.PaymentStaus);
                    break;
                default:
                    adverts = adverts.OrderBy(x => x.Title);
                    break;
            }
            return new PagedList<Advert>(adverts, page ?? 1, pageSize ?? 10, TotalItemCount);
            //return PaginatedList<Advert>.CreateAsync(adverts.ToList(), page ?? 1, pageSize, count);
        }

        public IEnumerable<Advert> GetByAdvertId(int? Id)
        {
            return advert.Where(x => x.Id == Id).AsEnumerable();
        }

        public Advert GetByID(int? Id)
        {
            return advert.Where(x => x.Id == Id).FirstOrDefault();
        }


    }
}
