﻿using SingleStore.NET.Application.Common;
using SingleStore.NET.Application.Interfaces;
using SingleStore.NET.Application.ViewModels;
using System.Threading;
using System.Threading.Tasks;

namespace SingleStore.NET.Application.Stocks.Commands
{
    public class UpdateStockCommand : IRequestWrapper<bool>
    {
        public StockViewModel Model { get; private set; }

        public UpdateStockCommand(StockViewModel model)
        {
            Model = model;
        }
    }

    public class UpdateStockCommandHandler : IRequestHandlerWrapper<UpdateStockCommand, bool>
    {
        private readonly IStockService _stockService;

        public UpdateStockCommandHandler(IStockService stockService)
        {
            _stockService = stockService;
        }

        public async Task<ServiceResult<bool>> Handle(UpdateStockCommand request, CancellationToken cancellationToken)
        {
            var result = await _stockService.Update(request.Model, cancellationToken);

            return result ? ServiceResult.Success(result) : ServiceResult.Failed<bool>(ServiceError.NotFound);
        }
    }
}
