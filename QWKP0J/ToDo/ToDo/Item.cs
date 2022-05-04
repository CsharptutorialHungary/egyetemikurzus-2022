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
        public Item(int id, string task)
        {
            Id = id;
            Task = task;
            IsComplete = false;
        }
    }
}
