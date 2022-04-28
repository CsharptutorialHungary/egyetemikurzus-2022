using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Library.Entities;
using Library.Serializer;

namespace Library
{
    internal static class FileReader
    {
        public static List<Book> ReadAllBooks()
        {
            Console.WriteLine("Reading all books...");
            var now = DateTime.Now;

            var directory = @"../../../Resources";
            if (!Directory.Exists(directory))
            {
                Console.WriteLine($"Error: Cannot find directory {directory}.");
                return new();
            }

            var files = Directory.GetFiles(directory, "*.json", SearchOption.AllDirectories);

            var fileContents = new List<string>();
            var tasks = new List<Task<string>>();
            foreach (var file in files)
            {
                var task = Task.Run(() => ReadFileContent(file));
                tasks.Add(task);
            }
            Task.WaitAll(tasks.ToArray());
            fileContents.AddRange(tasks.Select(task => task.Result));

            var books = new List<Book>();
            foreach (var fileContent in fileContents)
            {
                try
                {
                    books.AddRange(JsonSerializer.Deserialize<List<Book>>(fileContent, new JsonSerializerOptions
                    {
                        WriteIndented = true,
                        Converters =
                        {
                            new CustomDateJsonConverter()
                        }
                    }));
                }
                catch (Exception)
                {
                    Console.WriteLine($"Error: Couldn't deserialize content.");
                    return new();
                }
            }

            books = books.Where(b => b.Id != Guid.Empty && b.ReceivedDate.Year >= b.PublishYear &&
                !String.IsNullOrEmpty(b.Title) && !String.IsNullOrEmpty(b.Author)).ToList();

            Console.WriteLine($"Successfully read {books.Count}({books.Distinct().Count()} distinct) books in {(DateTime.Now - now).TotalSeconds} seconds.");
            return books.Distinct().ToList();
        }

        private static Task<string> ReadFileContent(string file)
        {
            return File.ReadAllTextAsync(file); 
        }
    }
}
