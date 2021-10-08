using SingleStore.NET.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SingleStore.NET.Domain.Interfaces
{
    public interface IStockRepository : IRepository
    {
        public Task<IEnumerable<Stock>> GetAllAsync(CancellationToken cancellationToken);
        public Task<Stock> GetByIdAsync(long id, CancellationToken cancellationToken);
        public Task<bool> Create(Stock model, CancellationToken cancellationToken);
        public Task<bool> Update(Stock model, CancellationToken cancellationToken);
        public Task<bool> Delete(long id, CancellationToken cancellationToken);
    }
}
