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
            Books = books;
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
