using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuranClub.Domain.Entities
{
    public class Country
    {
        public int Id { get; set; }
        public string CountryName { get; set; }
        public string CountryCode { get; set; }
    }
}
