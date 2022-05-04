using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo
{
    internal interface ICommand
    {
        void Execute(IConsole console, string text);
    }
}
