using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QuranClub.Domain.Entities
{
    public class Advert
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string Title { get; set; }
        public int? MediaTypeId { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string MediaUrl { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string DailyQuota { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string Countries { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string Cities { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string Languages { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [RegularExpression(@"[0-9]*", ErrorMessage = "Please enter valid Number")]
        public int? TotalAmount { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [RegularExpression(@"[0-9]*", ErrorMessage = "Please enter valid Number")]
        [Range(typeof(Int32), "0", "1", ErrorMessage = "Please use value  0 or 1")]
        public int? PaymentStaus { get; set; }
        [NotMapped]
        public int CountryId { get; set; }
        [NotMapped]
        public string MediaType { get; set; }
        [NotMapped]
        public IEnumerable<MediaType> Media { get; set; }
        [NotMapped]
        public IEnumerable<Languages> Language { get; set; }
        [NotMapped]
        public IEnumerable<Country> Country { get; set; }
        [NotMapped]
        public int? page { get; set; }
    }
}
