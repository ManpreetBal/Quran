using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using cloudscribe.Web.Pagination;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuranClub.Domain.Entities
{
    public class Charity
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string Name { get; set; }
        [NotMapped]
        public int? page { get; set; }
    }
}
