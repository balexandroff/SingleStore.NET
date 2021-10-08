﻿using AutoMapper;
using SingleStore.NET.Application.Interfaces;
using SingleStore.NET.Application.ViewModels;
using SingleStore.NET.Domain.Entities;
using SingleStore.NET.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SingleStore.NET.Application.Services
{
    public class StockService: IStockService
    {
        private readonly IMapper _mapper;

        private readonly IStockRepository _stockRepository;

        public StockService(IStockRepository stockRepository, IMapper mapper)
        {
            this._stockRepository = stockRepository;
            this._mapper = mapper;
        }

        public async Task<IEnumerable<StockViewModel>> GetAllAsync(CancellationToken cancellationToken)
        {
            var allStocks = await this._stockRepository.GetAllAsync(cancellationToken);

            return this._mapper.Map<IEnumerable<StockViewModel>>(allStocks);
        }

        public async Task<StockViewModel> GetByIdAsync(long id, CancellationToken cancellationToken)
        {
            var stock = await this._stockRepository.GetByIdAsync(id, cancellationToken);

            return this._mapper.Map<StockViewModel>(stock);
        }

        public async Task<bool> Create(StockViewModel model, CancellationToken cancellationToken)
        {
            return await this._stockRepository.Create(this._mapper.Map<Stock>(model), cancellationToken);
        }

        public async Task<bool> Update(StockViewModel model, CancellationToken cancellationToken)
        {
            return await this._stockRepository.Update(this._mapper.Map<Stock>(model), cancellationToken);
        }

        public async Task<bool> Delete(long id, CancellationToken cancellationToken)
        {
            return await this._stockRepository.Delete(id, cancellationToken);
        }
    }
}
