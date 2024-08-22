using AutoMapper;
using AutoMapper.QueryableExtensions;
using HotelListing.Api.Contracts_IRepository_;
using HotelListing.Api.Data;
using HotelListing.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelListing.Api.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly HotelListingDbContext context;
        private readonly IMapper mapper;

        public GenericRepository(HotelListingDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<T> AddAsync(T entity)
        {
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetAsync(id);
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task<bool> Exists(int id)
        {
            var entity = await GetAsync(id);
            return entity != null;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<PagedResult<TResult>> GetAllAsync<TResult>(QueryParameters queryParameter)
        {
            var totalSize = await context.Set<T>().CountAsync();
            var items = await context.Set<T>()
                .Skip(queryParameter.StartIndex)
                .Take(queryParameter.PageSize)
                .ProjectTo<TResult>(mapper.ConfigurationProvider)
                .ToListAsync();
            return new PagedResult<TResult>
            {
                Items = items,
                PageNumber = queryParameter.StartIndex,
                RecordNumber = queryParameter.PageSize,
                TotalCount = totalSize
            };
        }

        public async Task<T> GetAsync(int? id)
        {
            if (id is null)
            {
                return null;
            }

            return await context.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
           context.Update(entity);
            await context.SaveChangesAsync();

        }
    }
}
