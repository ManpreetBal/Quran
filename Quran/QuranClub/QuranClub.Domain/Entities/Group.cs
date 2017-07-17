using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QuranClub.Domain.Entities
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreatedByUserId { get; set; }
        public DateTime? CreatedAt { get; set; }
        [NotMapped]
        public string CreatedByUserName { get; set; }
        [NotMapped]
        public int? page { get; set; }
    }
}
