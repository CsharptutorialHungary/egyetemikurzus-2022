using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq
{
    public class User
    {
        public string UserName { get; set; }
        public int PokemonCount { get; set; }
    }

    //Extension methods
    public static class UserExtensions
    {
        public static bool IsNoob(this User user)
        {
            if (user.PokemonCount < 50)
                return true;
            return false;
        }
    }

    internal class Program
    {

        static void Main(string[] args)
        {
            List<User> Users = new List<User>
            {
            new User
            {
                UserName = "Alice",
                PokemonCount = 120,
            },
            new User
            {
                UserName = "Bob",
                PokemonCount = 30,
            },
            new User
            {
                UserName = "István",
                PokemonCount = 69,
            },
            };

            var bela = new User
            {
                UserName = "Béla",
                PokemonCount = 51,
            };

            bela.IsNoob();

            //LINQ - Language integrated Query
            //lambda syntax
            var max = Users.Max(user => user.PokemonCount);

            var Noobs = from user in Users
                        where user.IsNoob()
                        orderby user.PokemonCount descending
                        select user.UserName;

            foreach (var user in Noobs.Take(2))
            {
                Console.WriteLine(user);
            }
        }
    }
}
