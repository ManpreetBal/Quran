using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuranClub.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string Address { get;  set; }
        public int? City { get;  set; }
        public int? Country { get;  set; }
        public string FaceBookId { get;  set; }
        public string FirstName { get;  set; }
        public int? Language { get;  set; }
        public string LastName { get;  set; }
        public int? LastSeenPage { get;  set; }
        public string LocationLatitude { get;  set; }
        public string LocationLongitude { get;  set; }
        public string Postcode { get;  set; }
        [NotMapped]
        public string CountryName { get; set; }
        [NotMapped]
        public string CityName { get; set; }
        [NotMapped]
        public int? page { get; set; }
    }
}
