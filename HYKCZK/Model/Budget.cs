using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BudgetManager.Model
{
    public class Budget
    {
        public List<decimal> Incomes { get; set; }
        public List<decimal> Costs { get; set; }
        public string Currency { get; set; }

        public Budget()
        {
            Incomes = new List<decimal>();
            Costs = new List<decimal>();
            Currency = "HUF";
        }
    }
}
