using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Types
{
    internal abstract record class Item
    {
        public virtual string? Name { get; set; }
    }
}
