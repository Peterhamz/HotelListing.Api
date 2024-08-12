using HotelListing.Api.Data;

namespace HotelListing.Api.Contracts_IRepository_
{
    public interface ICountriesRepository: IGenericRepository<Country>
    {
        Task<Country> GetDetails(int id);
    }
}
