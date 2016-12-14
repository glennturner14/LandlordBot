using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandlordApp.DomainModel.Entities
{
    public class Expense
    {
        public DateTime  Date { get; set; }
        public string Description { get; set; }
        public Category ExpenseCategory { get; set; }
        public decimal Amount { get; set; }
        public bool IsRepeatingCost { get; set; }
        public Frequency CostFrequency { get; set; }
        public DateTime EndDate { get; set; }
    }
}
