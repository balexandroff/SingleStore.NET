using SingleStore.NET.Application.Common;
using SingleStore.NET.Application.Interfaces;
using SingleStore.NET.Application.ViewModels;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SingleStore.NET.Application.Stocks.Queries
{
    public class GetStockByIdQuery : IRequestWrapper<StockViewModel>
    {
        public long Id { get; private set; }

        public GetStockByIdQuery(long id)
        {
            Id = id;
        }
    }

    public class GetStockByIdQueryHandler : IRequestHandlerWrapper<GetStockByIdQuery, StockViewModel>
    {
        private readonly IStockService _stockService;

        public GetStockByIdQueryHandler(IStockService stockService)
        {
            _stockService = stockService;
        }

        public async Task<ServiceResult<StockViewModel>> Handle(GetStockByIdQuery request, CancellationToken cancellationToken)
        {
            var country = await this._stockService.GetByIdAsync(request.Id, cancellationToken);

            return country != null ? ServiceResult.Success(country) : ServiceResult.Failed<StockViewModel>(ServiceError.NotFound);
        }
    }
}
