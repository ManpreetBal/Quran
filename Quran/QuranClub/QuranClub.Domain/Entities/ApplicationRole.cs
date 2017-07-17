using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuranClub.Domain.Entities
{
    public class ApplicationRole : IdentityRole
    {
        public string Id { get; set; }
        public string RoleName { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
