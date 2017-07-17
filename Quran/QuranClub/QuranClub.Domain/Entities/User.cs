using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuranClub.Domain.Entities
{
    public class User
    {
        public int? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required(ErrorMessage = "This field is required!")]
        public string Email { get; set; }
        public string Address { get; set; }
        public int? City { get; set; }
        public int? Country { get; set; }
        public string Postcode { get; set; }
        [Required(ErrorMessage = "This field is required!")]
        public string Password { get; set; }
        public string Phone { get; set; }
        public string FaceBookId { get; set; }
        public string LocationLongitude { get; set; }
        public string LocationLatitude { get; set; }
        public int? Language { get; set; }
        public int? LastSeenPage { get; set; }
        public Nullable<DateTime> CreatedAt { get; set; }
    }
}
