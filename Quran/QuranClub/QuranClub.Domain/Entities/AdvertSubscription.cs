using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QuranClub.Domain.Entities
{
    public class AdvertSubscription
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string Tier { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [RegularExpression(@"[0-9]*\.?[0-9]+", ErrorMessage = "Please enter valid Number")]
        public decimal? VideoRate { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [RegularExpression(@"[0-9]*\.?[0-9]+", ErrorMessage = "Please enter valid Number")]
        public decimal? VideoTotal { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [RegularExpression(@"[0-9]*\.?[0-9]+", ErrorMessage = "Please enter valid Number")]
        public decimal? ImageRate { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [RegularExpression(@"[0-9]*\.?[0-9]+", ErrorMessage = "Please enter valid Number")]
        public decimal? ImageTotal { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [RegularExpression(@"[0-9]*\.?[0-9]+", ErrorMessage = "Please enter valid Number")]
        public decimal? PerClick { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [RegularExpression(@"[0-9]*\.?[0-9]+", ErrorMessage = "Please enter valid Number")]
        [Range(typeof(Decimal),"1", "100", ErrorMessage = "Please use values between 1 to 100")]
        public decimal? PercentageToCharity { get; set; }
        [NotMapped]
        public int? page { get; set; }
    }
}
