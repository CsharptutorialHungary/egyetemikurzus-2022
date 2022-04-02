using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MintaShell
{
    internal interface ICommand
    {
        void Execute(IConsole console);
    }
}
