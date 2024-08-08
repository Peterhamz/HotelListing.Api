using Microsoft.EntityFrameworkCore;

namespace HotelListing.Api.Data
{
    public class HotelListingDbContext: DbContext
    {
        public HotelListingDbContext(DbContextOptions options): base(options)
        {
            
        }

        public DbSet<Hotel> hotels { get; set; }
        public DbSet<Country> countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Country>().HasData(
                 new Country
                 {
                     Id = 1,
                     Name = "Jamaica",
                     ShortName = "JM"
                 }, new Country
                 {
                     Id = 2,
                     Name = "Bahamas",
                     ShortName = "BS"
                 }, new Country
                 {
                     Id = 3,
                     Name = "Cayman Island",
                     ShortName = "CI"
                 }, new Country
                 {
                     Id = 4,
                     Name = "Nigeria",
                     ShortName = "NGR"
                 }

             );

            modelBuilder.Entity<Hotel>().HasData(
                 new Hotel
                 {
                     Id = 1,
                     Name = "Sandals Resort and Spa",
                     Address = "Negril",
                     CountryId = 1,
                     Rating = 4.5
                 },
                new Hotel
                {
                    Id = 2,
                    Name = "Comfort Suites",
                    Address = "George Town",
                    CountryId = 3,
                    Rating = 4.3
                }, new Hotel
                {
                    Id = 3,
                    Name = "Grand Palldium",
                    Address = "Nassua",
                    CountryId = 3,
                    Rating = 4.5
                }, new Hotel
                {
                    Id = 4,
                    Name = "Protea Hotel",
                    Address = "Lagos",
                    CountryId = 4,
                    Rating = 4
                }

                );
        }
    }
}
