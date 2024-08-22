using HotelListing.Api.Models;

namespace HotelListing.Api.Contracts_IRepository_
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetAsync(int? id);
        Task<List<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        Task<PagedResult<TResult>> GetAllAsync<TResult>(QueryParameters queryParameter);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
        Task<bool> Exists(int id);
    }
}
