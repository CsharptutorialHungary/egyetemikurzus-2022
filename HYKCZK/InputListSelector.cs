using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BudgetManager
{
    public class InputListSelector
    {
        private List<string> _inputs;
        
        private int _firstLineIndex;
        private (int Left, int Top) _startCursorPosition;

        public InputListSelector(List<string> inputs)
        {
            _inputs = inputs;
        }
        
        public string Select()
        {
            _firstLineIndex = Console.CursorTop;
            _startCursorPosition = Console.GetCursorPosition();

            AddInputs();

            int resultIndex = GetSelectedIndex();

            var result = _inputs[resultIndex];

            ClearConsole();

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("  > {0}", result);
            Console.ResetColor();

            return result;
        }

        private int GetSelectedIndex()
        {
            int selectedIndex = 0;
            SelectInput(selectedIndex);

            ConsoleKeyInfo keyInfo;
            while (true)
            {
                keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    selectedIndex = (selectedIndex + 1) % _inputs.Count;
                }
                else if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    selectedIndex--;
                    if (selectedIndex < 0)
                    {
                        selectedIndex += _inputs.Count;
                    }
                }
                else if (keyInfo.Key == ConsoleKey.Enter)
                {
                    break;
                }
                else
                {
                    continue;
                }
                SelectInput(selectedIndex);
            }

            return selectedIndex;
        }

        private void SelectInput(int index)
        {
            ConsoleColor defaultColor = Console.ForegroundColor;
            var cursorPosition = Console.GetCursorPosition();

            ClearInputPrefixes();

            // Selection
            Console.SetCursorPosition(1, _firstLineIndex + index);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("*");
            Console.ForegroundColor = defaultColor;

            // Reset cursor
            Console.SetCursorPosition(cursorPosition.Left, cursorPosition.Top);
        }

        private void ClearInputPrefixes()
        {

            for (int i = 0; i < _inputs.Count; i++)
            {
                Console.CursorLeft = 1;
                Console.CursorTop = _firstLineIndex + i;
                Console.Write(" ");
            }
        }

        private void ClearConsole()
        {
            Console.SetCursorPosition(_startCursorPosition.Left, _startCursorPosition.Top);
            var bufferWidth = Console.BufferWidth;
            for (int i = 0; i < _inputs.Count + 1; i++)
            {
                for (int j = 0; j < bufferWidth; j++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine();
            }

            Console.CursorTop = _firstLineIndex;
        }

        private void AddInputs()
        {
            for (int i = 0; i < _inputs.Count; i++)
            {
                ConsoleColor defaultColor = Console.ForegroundColor;
                Console.ForegroundColor = defaultColor;
                Console.Write("   [");

                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write(i + 1);

                Console.ForegroundColor = defaultColor;
                Console.Write("]");

                Console.WriteLine(" {0}", _inputs[i]);
            }
        }
    }
}
