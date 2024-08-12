using HotelListing.Api.Contracts_IRepository_;
using HotelListing.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelListing.Api.Repository
{
    public class CountriesRepository : GenericRepository<Country>, ICountriesRepository
    {
        private readonly HotelListingDbContext context;

        public CountriesRepository(HotelListingDbContext context): base(context)
        {
            this.context = context;
        }

        public async Task<Country> GetDetails(int id)
        {
            return await context.countries.Include(i => i.Hotels)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
