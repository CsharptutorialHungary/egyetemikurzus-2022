using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace ToDo
{
    internal static class Program
    {
      static void Main(string[] args)
        {
            Console.WriteLine("[Add]");
            Console.WriteLine("[Complete]");
            Console.WriteLine("[Delete]");
            Console.WriteLine("[Exit]");

            

            Tasklist item = new Tasklist();
            while (true)
            {
                string input = Console.ReadLine();
                switch (input.ToLower())
                {
                    case "add":
                        Console.WriteLine("Task to do:");
                        string task = Console.ReadLine();

                        Item newItem = new Item(task);
                        item.AddItem(newItem);
                        Console.WriteLine("Added");
                        break;
                    case "complete":
                        
                        break;
                    case "delete":
                        break;
                    case "exit":
                        return;
                    default:
                        Console.WriteLine("valid command pls");
                        break;

                }
            }
            
        }
    }
}
