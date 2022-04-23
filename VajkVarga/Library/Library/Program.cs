using System;
using System.Linq;

namespace Library
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to my library!");
            
            var books = FileReader.ReadAllBooks();
            if (!books.Any())
            {
                Console.WriteLine("No books found, exiting from program.");
                return;
            }

            while (true)
            {
                Console.WriteLine("Choose from the following options or type \"exit\" to quit:");
                Console.WriteLine("1 - Get all book data");
                Console.WriteLine("2 - Get all books published after 2010");
                Console.WriteLine("3 - Rent a book");
                var userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        Console.WriteLine("1 selected");
                        break;
                    case "2":
                        Console.WriteLine("2 selected");
                        break;
                    case "3":
                        Console.WriteLine("3 selected");
                        break;
                    case "exit":
                        return;
                    default:
                        Console.WriteLine("Invalid line, type \"1\", \"2\", \"3\" or \"exit\"");
                        break;
                }
            }
        }
    }
}
