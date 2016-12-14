﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandlordApp.DomainModel.Entities
{
    public enum Frequency
    {
        Annually,
        Monthly,
        Weekly,
        Other
    }

    public class Income
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Frequency RentFrequency { get; set; }
        public decimal? RentAmount { get; set; }
        public bool IsCashBasis { get; set; }
    }
}