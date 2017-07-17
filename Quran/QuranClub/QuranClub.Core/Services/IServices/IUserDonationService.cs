﻿using QuranClub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuranClub.Core.Services.IServices
{
   public interface IUserDonationService
    {
        void Create(UserDonation userdonation);
        void Edit(UserDonation userdonation);
        IEnumerable<UserDonation> GetAll();
        IEnumerable<UserDonation> GetByUserDonationId(int? Id);
        void Delete(int? Id);
        UserDonation GetByID(int? Id);
        void Dispose();
    }
}
