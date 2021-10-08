﻿using System;
using System.Collections.Generic;

namespace SingleStore.NET.Domain.Entities
{
    public class Country : AudutableEntity
    {
        public string Name { get; set; }

        public ICollection<Stock> Stocks { get; set; } = new List<Stock>();
    }
}
