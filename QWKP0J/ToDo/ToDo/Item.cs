using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo
{
    internal class Item
    {
        public int Id { get; set; }
        public string Task { get; set; }
        public bool IsComplete { get; set; }
        public Item (string task)
        {
            Id = 1;
            Task = task;
            IsComplete = false;
        }
    }
}
