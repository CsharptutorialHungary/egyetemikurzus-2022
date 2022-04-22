using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MintaShell
{
    
    internal interface IConsole
    {
        //Write("helló");
        //Write("Hello {0}", asd);
        void Write(string format, params object[] args);
        void WriteLine(string format, params object[] args);
        string ReadLine();
    }
}
