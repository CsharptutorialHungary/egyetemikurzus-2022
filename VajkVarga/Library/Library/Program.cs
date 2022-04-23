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

            var bookManager = new BookManager(books);

            while (true)
            {
                Console.WriteLine("Choose from the following options or type \"exit\" to quit:");
                Console.WriteLine("1 - Get all book data");
                Console.WriteLine("2 - Get all books published before 1991");
                var userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        bookManager.ShowAllBook();
                        break;
                    case "2":
                        bookManager.ShowBooksPublishedBefore(1991);
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
