using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandlordApp.DomainModel.Entities
{
    public enum Frequency
    {
        Unknown,
        Weekly,
        Monthly,
        Quarterly,
        Annually,
        Other
    }

    public class Income
    {
        public Property Property { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Frequency RentFrequency { get; set; }
        public decimal? RentAmount { get; set; }
        public bool IsCashBasis { get; set; }
    }
}
