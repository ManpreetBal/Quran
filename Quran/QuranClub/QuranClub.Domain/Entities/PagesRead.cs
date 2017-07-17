using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuranClub.Domain.Entities
{
    public class PagesRead
    {
        public int Id { get; set; }
        public int? PageId { get; set; }
        public int? KhatmId { get; set; }
        public TimeSpan? CompletedTimestamp { get; set; }
        public string LocationLongitude { get; set; }
        public string LocationLatitude { get; set; }
        public int? UserGroupId { get; set; }
    }
}
