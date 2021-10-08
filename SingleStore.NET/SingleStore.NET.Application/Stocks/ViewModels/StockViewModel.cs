﻿using System;

namespace SingleStore.NET.Application.ViewModels
{
    public class StockViewModel
    {
        public long Id { get; set; }

        public string Ticker { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Guid CountryId { get; set; }

        public virtual CountryViewModel Country { get; set; }
    }
}
