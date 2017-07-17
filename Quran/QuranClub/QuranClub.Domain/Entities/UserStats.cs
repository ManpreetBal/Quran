using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuranClub.Domain.Entities
{
    public class UserStats
    {
        public int Id { get; set; }
        public int? TotalPagesRead { get; set; }
        public int? TotalKhatms { get; set; }
        public int? TotalPagesDonated { get; set; }
        public int? TotalKhatmsDonated { get; set; }
        public int? TotalMoneyDonated { get; set; }
        public DateTime? LastUpdatedAt { get; set; }
    }
}
