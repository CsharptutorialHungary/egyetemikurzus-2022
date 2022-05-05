using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManager
{
    internal interface IConsole
    {
        ConsoleColor ForegroundColor { get; set; }

        void Write(string format, params object[] args);
        void WriteLine(string value);
        void WriteLine(string format, params object[] args);
        void WriteLine();
        string ReadString(string value);
        bool TryReadDecimal(out decimal result, string format, params object[] args);
        void ResetColor();
        T SelectFromList<T>(List<T> options);
    }
}
