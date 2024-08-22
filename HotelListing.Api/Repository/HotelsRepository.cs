using AutoMapper;
using HotelListing.Api.Contracts_IRepository_;
using HotelListing.Api.Data;

namespace HotelListing.Api.Repository
{
    public class HotelsRepository : GenericRepository<Hotel>, IHotelsRepository
    {
        private readonly HotelListingDbContext context;
        private readonly IMapper mapper;

        public HotelsRepository(HotelListingDbContext context, IMapper mapper) : base(context, mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
    }
}
