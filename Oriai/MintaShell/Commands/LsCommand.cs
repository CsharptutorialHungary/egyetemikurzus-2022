using System;
using System.IO;

namespace MintaShell.Commands
{
    [Loadable]
    internal class LsCommand : ICommand
    {
        public void Execute(IConsole console)
        {
            string mappa = Environment.CurrentDirectory;
            foreach (var file in Directory.GetFiles(mappa))
            {
                console.WriteLine(file);
            }
        }
    }
}
