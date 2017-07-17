using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuranClub.Domain.Entities
{
    public class UserGroup
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public int UserId { get; set; }
    }
}
