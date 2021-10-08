using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using SingleStore.NET.Application.Common;
using SingleStore.NET.Application.Interfaces;
using SingleStore.NET.Application.ViewModels;

namespace SingleStore.NET.Application.Stocks.Queries
{
    public class GetAllStocksQuery : IRequestWrapper<IEnumerable<StockViewModel>>
    {

    }

    public class GetAllStocksQueryHandler : IRequestHandlerWrapper<GetAllStocksQuery, IEnumerable<StockViewModel>>
    {
        private readonly IStockService _stockService;

        public GetAllStocksQueryHandler(IStockService stockService)
        {
            _stockService = stockService;
        }

        public async Task<ServiceResult<IEnumerable<StockViewModel>>> Handle(GetAllStocksQuery request, CancellationToken cancellationToken)
        {
            var list = await this._stockService.GetAllAsync(cancellationToken);

            return list.Count() > 0 ? ServiceResult.Success(list) : ServiceResult.Failed<IEnumerable<StockViewModel>>(ServiceError.NotFound);
        }
    }
}
