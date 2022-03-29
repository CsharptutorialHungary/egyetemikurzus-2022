using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MintaShell.Commands
{
    [Loadable]
    internal class RulezCommand : ICommand
    {
        public void Execute(IConsole console)
        {
            Console.WriteLine("Reflection rulez!4!");
        }
    }
}
