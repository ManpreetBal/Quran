using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuranClub.Domain.Entities;

namespace QuranClub.Repository
{
    public sealed class DBEntities : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        public DBEntities(DbContextOptions<DBEntities> options)
            : base(options)
        {
        }

        public DBEntities() : base()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

        }
        public static DBEntities create()
        {
            return new DBEntities();
        }

        public DbSet<Country> Country { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Languages> Language { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Group> Group { get; set; }
        public DbSet<UserGroup> UserGroup { get; set; }
        public DbSet<Verse> Verse { get; set; }
        public DbSet<VerseRead> VerseRead { get; set; }
        public DbSet<PagesRead> PagesRead { get; set; }
        public DbSet<Khatm> Khatm { get; set; }
        public DbSet<Charity> Charity { get; set; }
        public DbSet<Cause> Cause { get; set; }
        public DbSet<AdvertSubscription> AdvertSubscription { get; set; }
        public DbSet<MediaType> MediaType { get; set; }
        public DbSet<Advert> Advert { get; set; }
        public DbSet<UserDonation> UserDonation { get; set; }
        public DbSet<UserStats> UserStats { get; set; }
        public DbSet<UserAdvert> UserAdvert { get; set; }
        public DbSet<ApplicationUser> AspNetUsers { get; set; }
    }
}
