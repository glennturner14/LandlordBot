﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandlordApp.DomainModel.Entities
{
    public class StatementLine
    {
        public string Date { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
    }
}
