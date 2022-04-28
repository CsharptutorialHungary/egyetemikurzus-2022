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
            bookManager.StartConsoleLoop();
        }
    }
}
