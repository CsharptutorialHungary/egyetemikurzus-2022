using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using BudgetManager.Enum;

namespace BudgetManager.Model
{
    internal class Budget
    {
        [JsonPropertyName("incomes")]
        public List<Transaction> Incomes { get; set; }

        [JsonPropertyName("costs")]
        public List<Transaction> Costs { get; set; }

        [JsonPropertyName("currency")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Currency Currency { get; set; }

        public Budget()
        {
            Incomes = new List<Transaction>();
            Costs = new List<Transaction>();
            Currency = Currency.HUF;
        }
    }
}
