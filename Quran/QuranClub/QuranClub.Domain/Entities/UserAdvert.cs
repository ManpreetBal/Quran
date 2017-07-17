using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuranClub.Domain.Entities
{
    public class UserAdvert
    {
        public int Id { get; set; }
        public int? AdvertId { get; set; }
        public int? UserId { get; set; }
        public string LocationLongitude { get; set; }
        public string LocationLatitude { get; set; }
        public int? Clicks { get; set; }
        public int? VideoTime { get; set; }
    }
}
