using System;
using System.Collections.Generic;
using System.Linq;
using Library.Entities;

namespace Library
{
    internal class BookManager
    {
        private readonly List<Book> Books;

        public BookManager(List<Book> books)
        {
            Books = books.Distinct().ToList();
        }

        internal void StartConsoleLoop()
        {
            while (true)
            {
                Console.WriteLine("Choose from the following options or type \"exit\" to quit:");
                Console.WriteLine("1 - Get all book data");
                Console.WriteLine("2 - Get all books published before 1991");
                var userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        ShowAllBook();
                        break;
                    case "2":
                        ShowBooksPublishedBefore(1991);
                        break;
                    case "exit":
                        return;
                    default:
                        Console.WriteLine("Invalid line, type \"1\", \"2\" or \"exit\"");
                        break;
                }
            }
        }

        internal void ShowAllBook()
        {
            ShowBooks(Books);
        }

        internal void ShowBooksPublishedBefore(int year)
        {
            ShowBooks(Books.Where(b => b.PublishYear < year));
        }

        private void ShowBooks(IEnumerable<Book> books)
        {
            foreach (var book in books)
            {
                Console.WriteLine($"Title: {book.Title}");
                Console.WriteLine($"Author: {book.Author}");
                Console.WriteLine($"PublishYear: {book.PublishYear}");
                Console.WriteLine($"ReceivedDate: {book.ReceivedDate.ToString("yyyy-MM-dd")}");
                Console.WriteLine();
            }
        }
    }
}
