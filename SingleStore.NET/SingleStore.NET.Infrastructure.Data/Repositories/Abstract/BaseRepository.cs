using SingleStore.NET.Domain.Entities;

namespace SingleStore.NET.Infrastructure.Data.Repositories
{
    public class BaseRepository<T> where T : AudutableEntity
    {
        protected readonly StocksDbContext _dbContext;

        public BaseRepository(StocksDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
    }
}
