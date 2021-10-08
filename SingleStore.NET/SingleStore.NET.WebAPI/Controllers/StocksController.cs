﻿using SingleStore.NET.Application.Common;
using SingleStore.NET.Application.Interfaces;
using SingleStore.NET.Application.Stocks.Commands;
using SingleStore.NET.Application.Stocks.Queries;
using SingleStore.NET.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SingleStore.NET.API.Controllers
{
    //[Authorize]
    public class StocksController : BaseController
    {
        private IStockService _stockService;

        public StocksController(IStockService stockService)
        {
            _stockService = stockService;
        }

        [HttpGet("getall")]
        public async Task<ActionResult<ServiceResult<IEnumerable<StockViewModel>>>> GetAllStocks(CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetAllStocksQuery(), cancellationToken));
        }

        [HttpGet("getbyid/{id}")]
        public async Task<ActionResult<ServiceResult<IEnumerable<StockViewModel>>>> GetById(long id, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetStockByIdQuery(id), cancellationToken));
        }

        [HttpPost("create")]
        public async Task<ActionResult<ServiceResult<IEnumerable<StockViewModel>>>> Create([FromBody] StockViewModel model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateStockCommand(model), cancellationToken));
        }

        [HttpPost("update")]
        public async Task<ActionResult<ServiceResult<IEnumerable<StockViewModel>>>> Update([FromBody] StockViewModel model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new UpdateStockCommand(model), cancellationToken));
        }

        [HttpPost("delete/{id}")]
        public async Task<ActionResult<ServiceResult<IEnumerable<StockViewModel>>>> Delete(long id, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new DeleteStockCommand(id), cancellationToken));
        }
    }
}
