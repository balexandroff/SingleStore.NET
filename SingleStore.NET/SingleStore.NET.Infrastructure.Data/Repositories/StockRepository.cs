using Microsoft.EntityFrameworkCore;
using SingleStore.NET.Domain.Entities;
using SingleStore.NET.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SingleStore.NET.Infrastructure.Data.Repositories
{
    public class StockRepository : BaseRepository<Stock>, IStockRepository
    {
        public StockRepository(StocksDbContext dbContext) : base(dbContext) { }

        public async Task<IEnumerable<Stock>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.Stocks.ToListAsync(cancellationToken);
        }

        public async Task<Stock> GetByIdAsync(long id, CancellationToken cancellationToken)
        {
            return await _dbContext.Stocks.Where(c => c.Id == id).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<bool> Create(Stock model, CancellationToken cancellationToken)
        {
            await _dbContext.Stocks.AddAsync(model, cancellationToken);

            var result = await _dbContext.SaveChangesAsync(cancellationToken);

            return result > 0;
        }

        public async Task<bool> Update(Stock model, CancellationToken cancellationToken)
        {
            var result = 0;
            var entity = await _dbContext.Stocks.Where(c => c.Id == model.Id).FirstOrDefaultAsync(cancellationToken);

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
            var entity = await _dbContext.Stocks.Where(c => c.Id == id).FirstOrDefaultAsync(cancellationToken);

            if (entity != null)
            {
                _dbContext.Remove(entity);

                result = await _dbContext.SaveChangesAsync(cancellationToken);
            }

            return result > 0;
        }
    }
}
