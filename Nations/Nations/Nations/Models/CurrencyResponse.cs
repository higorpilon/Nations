﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Nations.Models
{
    public class CurrencyResponse
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public string Symbol { get; set; }

        public override string ToString()
        {
            return $"{Name}";
        }

       
    }
}
