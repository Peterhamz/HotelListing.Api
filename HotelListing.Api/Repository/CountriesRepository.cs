using AutoMapper;
using HotelListing.Api.Contracts_IRepository_;
using HotelListing.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelListing.Api.Repository
{
    public class CountriesRepository : GenericRepository<Country>, ICountriesRepository
    {
        private readonly HotelListingDbContext context;
        private readonly IMapper mapper;

        public CountriesRepository(HotelListingDbContext context, IMapper mapper) : base(context, mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<Country> GetDetails(int id)
        {
            return await context.countries.Include(i => i.Hotels)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
