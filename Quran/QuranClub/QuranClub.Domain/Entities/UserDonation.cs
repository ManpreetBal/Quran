using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuranClub.Domain.Entities
{
    public class UserDonation
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? CauseId { get; set; }
        public string PagesDonated { get; set; }
        public string KhatmsDonated { get; set; }
        public string MoneyDonated { get; set; }
        public bool Monthly { get; set; }
        public bool Zakah { get; set; }
        public bool GiftAid { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
