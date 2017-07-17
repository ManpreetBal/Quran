using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuranClub.Domain.Entities
{
    public class AdvertLanguage
    {
        public int Id { get; set; }
        public int AdvertId { get; set; }
        public int LanguageId { get; set; }
    }
}
