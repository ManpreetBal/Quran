using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using QuranClub.Repository;

namespace QuranClub.Web.Data.Migrations
{
    [DbContext(typeof(DBEntities))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("QuranClub.Domain.Entities.Admin", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Password");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Admin");
                });

            modelBuilder.Entity("QuranClub.Domain.Entities.Advert", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Cities");

                    b.Property<string>("Countries");

                    b.Property<string>("DailyQuota");

                    b.Property<string>("Languages");

                    b.Property<int?>("MediaTypeId");

                    b.Property<string>("MediaUrl");

                    b.Property<int?>("PaymentStaus");

                    b.Property<string>("Title");

                    b.Property<int?>("TotalAmount");

                    b.HasKey("Id");

                    b.ToTable("Advert");
                });

            modelBuilder.Entity("QuranClub.Domain.Entities.AdvertSubscription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal?>("ImageRate");

                    b.Property<decimal?>("ImageTotal");

                    b.Property<decimal?>("PerClick");

                    b.Property<decimal?>("PercentageToCharity");

                    b.Property<string>("Tier");

                    b.Property<decimal?>("VideoRate");

                    b.Property<decimal?>("VideoTotal");

                    b.HasKey("Id");

                    b.ToTable("AdvertSubscription");
                });

            modelBuilder.Entity("QuranClub.Domain.Entities.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("Address");

                    b.Property<int?>("City");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<int?>("Country");

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FaceBookId");

                    b.Property<string>("FirstName");

                    b.Property<int?>("Language");

                    b.Property<string>("LastName");

                    b.Property<int?>("LastSeenPage");

                    b.Property<string>("LocationLatitude");

                    b.Property<string>("LocationLongitude");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("Postcode");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("QuranClub.Domain.Entities.Cause", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AdvertsWatched");

                    b.Property<int?>("CountryId");

                    b.Property<DateTime?>("CreatedAt");

                    b.Property<string>("Description");

                    b.Property<string>("ImageUrl");

                    b.Property<bool>("IsFeatured");

                    b.Property<string>("KhatmsDonated");

                    b.Property<DateTime?>("LastUpdatedAt");

                    b.Property<string>("MoneyDonated");

                    b.Property<string>("PagesDontated");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Cause");
                });

            modelBuilder.Entity("QuranClub.Domain.Entities.Charity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Charity");
                });

            modelBuilder.Entity("QuranClub.Domain.Entities.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CityName");

                    b.Property<int>("CountryId");

                    b.HasKey("Id");

                    b.ToTable("City");
                });

            modelBuilder.Entity("QuranClub.Domain.Entities.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CountryCode");

                    b.Property<string>("CountryName");

                    b.HasKey("Id");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("QuranClub.Domain.Entities.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CreatedByUserId");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Group");
                });

            modelBuilder.Entity("QuranClub.Domain.Entities.Khatm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Completed");

                    b.Property<DateTime?>("EndTime");

                    b.Property<int?>("GroupId");

                    b.Property<DateTime?>("StartTime");

                    b.HasKey("Id");

                    b.ToTable("Khatm");
                });

            modelBuilder.Entity("QuranClub.Domain.Entities.Language", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Langauge");

                    b.HasKey("Id");

                    b.ToTable("Language");
                });

            modelBuilder.Entity("QuranClub.Domain.Entities.MediaType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.ToTable("MediaType");
                });

            modelBuilder.Entity("QuranClub.Domain.Entities.PagesRead", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<TimeSpan?>("CompletedTimestamp");

                    b.Property<int?>("KhatmId");

                    b.Property<string>("LocationLatitude");

                    b.Property<string>("LocationLongitude");

                    b.Property<int?>("PageId");

                    b.Property<int?>("UserGroupId");

                    b.HasKey("Id");

                    b.ToTable("PagesRead");
                });

            modelBuilder.Entity("QuranClub.Domain.Entities.User", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<int?>("City");

                    b.Property<int?>("Country");

                    b.Property<DateTime?>("CreatedAt");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FaceBookId");

                    b.Property<string>("FirstName");

                    b.Property<int?>("Language");

                    b.Property<string>("LastName");

                    b.Property<int?>("LastSeenPage");

                    b.Property<string>("LocationLatitude");

                    b.Property<string>("LocationLongitude");

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("Phone");

                    b.Property<string>("Postcode");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("QuranClub.Domain.Entities.UserAdvert", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AdvertId");

                    b.Property<int?>("Clicks");

                    b.Property<string>("LocationLatitude");

                    b.Property<string>("LocationLongitude");

                    b.Property<int?>("UserId");

                    b.Property<int?>("VideoTime");

                    b.HasKey("Id");

                    b.ToTable("UserAdvert");
                });

            modelBuilder.Entity("QuranClub.Domain.Entities.UserDonation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CauseId");

                    b.Property<DateTime?>("CreatedAt");

                    b.Property<bool>("GiftAid");

                    b.Property<string>("KhatmsDonated");

                    b.Property<string>("MoneyDonated");

                    b.Property<bool>("Monthly");

                    b.Property<string>("PagesDonated");

                    b.Property<int?>("UserId");

                    b.Property<bool>("Zakah");

                    b.HasKey("Id");

                    b.ToTable("UserDonation");
                });

            modelBuilder.Entity("QuranClub.Domain.Entities.UserGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("GroupId");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.ToTable("UserGroup");
                });

            modelBuilder.Entity("QuranClub.Domain.Entities.UserStats", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("LastUpdatedAt");

                    b.Property<int?>("TotalKhatms");

                    b.Property<int?>("TotalKhatmsDonated");

                    b.Property<int?>("TotalMoneyDonated");

                    b.Property<int?>("TotalPagesDonated");

                    b.Property<int?>("TotalPagesRead");

                    b.HasKey("Id");

                    b.ToTable("UserStats");
                });

            modelBuilder.Entity("QuranClub.Domain.Entities.Verse", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("PageId");

                    b.Property<int?>("SuraId");

                    b.HasKey("Id");

                    b.ToTable("Verse");
                });

            modelBuilder.Entity("QuranClub.Domain.Entities.VerseRead", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<TimeSpan?>("CompletedTimestamp");

                    b.Property<int?>("KhatmId");

                    b.Property<string>("LocationLatitude");

                    b.Property<string>("LocationLongitude");

                    b.Property<int?>("UserGroupId");

                    b.Property<int?>("VerseId");

                    b.HasKey("Id");

                    b.ToTable("VerseRead");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("QuranClub.Domain.Entities.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("QuranClub.Domain.Entities.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("QuranClub.Domain.Entities.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
