﻿using SingleStore.NET.Application.Common;
using SingleStore.NET.Application.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SingleStore.NET.Application.Stocks.Commands
{
    public class DeleteStockCommand : IRequestWrapper<bool>
    {
        public long Id { get; private set; }

        public DeleteStockCommand(long id)
        {
            Id = id;
        }
    }

    public class DeleteStockCommandHandler : IRequestHandlerWrapper<DeleteStockCommand, bool>
    {
        private readonly IStockService _stockService;

        public DeleteStockCommandHandler(IStockService stockService)
        {
            _stockService = stockService;
        }

        public async Task<ServiceResult<bool>> Handle(DeleteStockCommand request, CancellationToken cancellationToken)
        {
            var result = await _stockService.Delete(request.Id, cancellationToken);

            return result ? ServiceResult.Success(result) : ServiceResult.Failed<bool>(ServiceError.NotFound);
        }
    }
}
