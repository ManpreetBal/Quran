using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuranClub.Domain.Entities
{
    public class Verse
    {
        public int? Id { get; set; }
        public int? PageId { get; set; }
        public int? SuraId { get; set; }
    }
}
