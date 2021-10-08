using Microsoft.EntityFrameworkCore;
using SingleStore.NET.Domain.Entities;
using SingleStore.NET.Domain.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SingleStore.NET.Infrastructure.Data.Repositories
{
    public class CountryRepository: BaseRepository<Country>, ICountryRepository
    {
        public CountryRepository(StocksDbContext dbContext) : base(dbContext) { }

        public async Task<IEnumerable<Country>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.Countries.ToListAsync(cancellationToken);
        }

        public async Task<Country> GetByIdAsync(long id, CancellationToken cancellationToken)
        {
            return await _dbContext.Countries.Where(c => c.Id == id).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<bool> Create(Country model, CancellationToken cancellationToken)
        {
            await _dbContext.Countries.AddAsync(model, cancellationToken);

            var result = await _dbContext.SaveChangesAsync(cancellationToken);

            return result > 0;
        }

        public async Task<bool> Update(Country model, CancellationToken cancellationToken)
        {
            var result = 0;
            var entity = await _dbContext.Countries.Where(c => c.Id == model.Id).FirstOrDefaultAsync(cancellationToken);

            if (entity != null)
            {
                entity.Name = model.Name;

                result = await _dbContext.SaveChangesAsync(cancellationToken);
            }

            return result > 0;
        }

        public async Task<bool> Delete(long id, CancellationToken cancellationToken)
        {
            var result = 0;
            var entity = await _dbContext.Countries.Where(c => c.Id == id).FirstOrDefaultAsync(cancellationToken);

            if (entity != null)
            {
                _dbContext.Remove(entity);

                result = await _dbContext.SaveChangesAsync(cancellationToken);
            }

            return result > 0;
        }
    }
}
