using QuranClub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuranClub.Core.Services.IServices
{
    public interface IAdvertSubscriptionService
    {
        void Create(AdvertSubscription advertsubscription);
        void Edit(AdvertSubscription advertsubscription);
        List<AdvertSubscription> GetAll(int? page, int? pageSize, string sortOrder, string searchString, string currentFilter);
        IEnumerable<AdvertSubscription> GetByAdvertId(int? Id);
        void Delete(int? Id);
        AdvertSubscription GetByID(int? Id);
        void Dispose();
    }
}
