using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QuranClub.Domain.Entities
{
    public class Cause
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [StringLength(10000, MinimumLength = 100, ErrorMessage = "Description Can't be less then 100 character.")]
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        //public int? PagesDontated { get; set; }
        //public int? KhatmsDonated { get; set; }
        //public int? MoneyDonated { get; set; }
        //public int? AdvertsWatched { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public int? CountryId { get; set; }
        public bool IsFeatured { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? LastUpdatedAt { get; set; }
        [NotMapped]

        public IEnumerable<Country> Countries { get; set; }
        [NotMapped]
        public string CountryName { get; set; }
        [NotMapped]
        public string WebRootPath { get; set; }
        [NotMapped]
        public int? page { get; set; }
    }
}
