using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MintaShell.Commands
{
    [Loadable]
    internal class HelloCommand : ICommand
    {
        public void Execute(IConsole console)
        {
            console.WriteLine("Hello");
        }
    }
}
