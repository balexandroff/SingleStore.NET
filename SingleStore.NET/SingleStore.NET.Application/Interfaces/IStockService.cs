using SingleStore.NET.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SingleStore.NET.Application.Interfaces
{
    public interface IStockService: IService
    {
        public Task<IEnumerable<StockViewModel>> GetAllAsync(CancellationToken cancellationToken);
        public Task<StockViewModel> GetByIdAsync(long id, CancellationToken cancellationToken);
        public Task<bool> Create(StockViewModel model, CancellationToken cancellationToken);
        public Task<bool> Update(StockViewModel model, CancellationToken cancellationToken);
        public Task<bool> Delete(long id, CancellationToken cancellationToken);
    }
}
