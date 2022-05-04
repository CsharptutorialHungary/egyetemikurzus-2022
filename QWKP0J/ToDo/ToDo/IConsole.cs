using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo
{
    
    internal interface IConsole
    {
        void Write(string format, params object[] args);
        void WriteLine(string format, params object[] args);
        string ReadLine();
    }
}
