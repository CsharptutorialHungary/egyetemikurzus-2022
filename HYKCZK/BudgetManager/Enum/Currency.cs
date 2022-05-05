using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManager.Enum
{
    internal enum Currency
    {
        [Description("Hungarian Forint")]
        HUF,

        [Description("Euro")]
        EUR,

        [Description("United States Dollar")]
        USD
    }
}
