using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BudgetManager.Model
{
    internal class Transaction
    {
        [JsonPropertyName("amount")]
        public decimal Amount { get; }

        [JsonPropertyName("description")]
        public string Description { get; }

        [JsonPropertyName("accountedDateTime")]
        public DateTime AccountedDateTime { get; }

        public Transaction(decimal amount, string description, DateTime accountedDateTime)
        {
            Amount = amount;
            Description = description;
            AccountedDateTime = accountedDateTime;
        }
    }
}
