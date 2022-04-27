namespace BudgetManager
{
    internal class SystemConsole : IConsole
    {
        public ConsoleColor ForegroundColor { get; set; }

        public void Write(string format, params object[] args)
        {
            Console.Write(format, args);
        }

        public void WriteLine(string value)
        {
            Console.WriteLine(value);
        }

        public void WriteLine(string format, params object[] args)
        {
            Console.WriteLine(format, args);
        }

        public void WriteLine()
        {
            Console.WriteLine();
        }

        public bool TryReadDecimal(out decimal result, string format, params object[] args)
        {
            Console.Write(format, args);

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            var input = Console.ReadLine();
            Console.ResetColor();

            return decimal.TryParse(input, out result);
        }

        public void ResetColor()
        {
            Console.ResetColor();
        }


        public T SelectFromList<T>(List<T> options)
        {
            // Initial values
            int firstLineIndex = Console.CursorTop;
            (int Left, int Top) startCursorPosition = Console.GetCursorPosition();

            // Setup
            AddOptions();

            // Select from list
            int selectedIndex = GetSelectedIndex();
            var selectedOption = options[selectedIndex];

            // Reset Console
            ClearConsole();
            Console.SetCursorPosition(startCursorPosition.Left, startCursorPosition.Top);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("  > {0}", selectedOption);
            Console.ResetColor();

            return selectedOption;

            #region Inline Methods

            int GetSelectedIndex()
            {
                int selectedOptionIndex = 0;
                SelectInput(selectedOptionIndex);

                ConsoleKeyInfo keyInfo;
                while (true)
                {
                    keyInfo = Console.ReadKey(true);

                    if (keyInfo.Key == ConsoleKey.DownArrow)
                    {
                        selectedOptionIndex = (selectedOptionIndex + 1) % options.Count;
                    }
                    else if (keyInfo.Key == ConsoleKey.UpArrow)
                    {
                        selectedOptionIndex--;
                        if (selectedOptionIndex < 0)
                        {
                            selectedOptionIndex += options.Count;
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
                    SelectInput(selectedOptionIndex);
                }

                return selectedOptionIndex;
            }

            void SelectInput(int index)
            {
                ConsoleColor defaultColor = Console.ForegroundColor;
                var cursorPosition = Console.GetCursorPosition();

                ClearInputPrefixes();

                // Selection
                Console.SetCursorPosition(1, firstLineIndex + index);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("*");
                Console.ForegroundColor = defaultColor;

                // Reset cursor
                Console.SetCursorPosition(cursorPosition.Left, cursorPosition.Top);
            }

            void ClearInputPrefixes()
            {
                for (int i = 0; i < options.Count; i++)
                {
                    Console.CursorLeft = 1;
                    Console.CursorTop = firstLineIndex + i;
                    Console.Write(" ");
                }
            }

            void ClearConsole()
            {
                Console.SetCursorPosition(startCursorPosition.Left, startCursorPosition.Top);
                var bufferWidth = Console.BufferWidth;

                for (int i = 0; i < options.Count + 1; i++)
                {
                    for (int j = 0; j < bufferWidth; j++)
                    {
                        Console.Write(" ");
                    }
                    Console.WriteLine();
                }
            }

            void AddOptions()
            {
                for (int i = 0; i < options.Count; i++)
                {
                    ConsoleColor defaultColor = Console.ForegroundColor;
                    Console.ForegroundColor = defaultColor;
                    Console.Write("   [");

                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Write(i + 1);

                    Console.ForegroundColor = defaultColor;
                    Console.Write("]");

                    Console.WriteLine(" {0}", options[i].ToString());
                }
            }
            
            #endregion
        }
    }
}