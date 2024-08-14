using HotelListing.Api.Contracts_IRepository_;
using HotelListing.Api.Data;

namespace HotelListing.Api.Repository
{
    public class HotelsRepository : GenericRepository<Hotel>, IHotelsRepository
    {
        public HotelsRepository(HotelListingDbContext context) : base(context)
        {
        }
    }
}
