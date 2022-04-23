using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Library.Entities;
using Library.Serializer;

namespace Library
{
    internal static class FileReader
    {
        public static List<Book> ReadAllBooks()
        {
            Console.WriteLine("Reading all books...");

            var file = @"../../../Resources/allBooks.json";

            if (!File.Exists(file))
            {
                var fileName = Path.GetFileName(file);
                var fileFullPath = Path.GetFullPath(file);
                var directoryFullPath = Path.GetDirectoryName(fileFullPath);
                Console.WriteLine($"Error: Cannot find {fileName} in {directoryFullPath}.");
                return new();
            }

            string fileContent = String.Empty;
            try
            {
                fileContent = File.ReadAllText(file);
            }
            catch (Exception)
            {
                Console.WriteLine($"Error: Couldn't read {Path.GetFileName(file)} content.");
                return new();
            }

            var books = new List<Book>();
            try
            {
                books = JsonSerializer.Deserialize<List<Book>>(fileContent, new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Converters =
                    {
                        new CustomDateJsonConverter()
                    }
                });
            }
            catch (Exception)
            {
                Console.WriteLine($"Error: Couldn't serialize {Path.GetFileName(file)} content.");
                return new();
            }

            if (books.GroupBy(b => b.Id).Count() != books.Count)
            {
                Console.WriteLine($"Error: Multiple books found with the same Id.");
                return new();
            }

            books = books.Where(b => b.Id != Guid.Empty && b.PublishYear < 2200 &&
                !String.IsNullOrEmpty(b.Title) && !String.IsNullOrEmpty(b.Author) &&
                b.ReceivedDate.Year < 2200 && b.ReceivedDate.Year >= b.PublishYear).ToList();

            Console.WriteLine($"Successfully read {books.Count} books.");
            return books;
        }
    }
}
