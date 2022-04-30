using FilmDataBase.Model;
using System.Text.Json;
using System.Xml.Serialization;

namespace FilmDataBase 
{
    class Program 
    {
        static void Main(string[] args)
        {

            bool showMenu = true;
            while (showMenu) 
            {
                showMenu = MainMenu();
            }
            
        }
        private static bool MainMenu() 
        {
            Console.Clear();
            Console.WriteLine("FILMES ADATBÁZIS");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Opciók:");
            Console.WriteLine();
            Console.WriteLine("1. Hozzáadás");
            Console.WriteLine("2. Listázás");
            Console.WriteLine("Q. Kilépés");
            Console.WriteLine();
            Console.Write("Válassz egy opciót: ");

            switch (Console.ReadLine())
            {
                case "1":
                    AddNewMovie();
                    return true;
                case "2":
                    ListMovies();
                    return true;
                case "Q":
                    return false;
                default:
                    return true;
            }
            

        }

        private static void ListMovies()
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<Film>));
            using (var f = File.OpenRead("../../../movies.xml")) 
            {
                List<Film> movies = xs.Deserialize(f) as List<Film>;

                foreach (var movie in movies)
                {
                    Console.WriteLine("Film címe: "+movie.Title);
                    Console.WriteLine("Film éve: "+movie.Year);
                    Console.WriteLine("Film műfaja: "+movie.Genre);
                    Console.WriteLine("Film rendezője: "+movie.Director);
                    Console.WriteLine("Film stúdiója: "+movie.Studio);
                    Console.WriteLine("-----------------------------");
                }
                Console.ReadLine();

            }
        }

        private static void AddNewMovie()
        {
            List<Film> list = new List<Film>();
            Console.WriteLine("Hány filmet szeretnél hozzáadni?:");
            string movieCount = Console.ReadLine();

            for (int i = 0; i < Int32.Parse(movieCount); i++)
            {
                Console.Write("Add meg a film címét:");
                string Title = Console.ReadLine();
                Console.Write("Add meg a film évét:");
                string Year = Console.ReadLine();
                Console.Write("Add meg a film műfaját:");
                string Genre = Console.ReadLine();
                Console.Write("Add meg a film rendezőjét:");
                string Director = Console.ReadLine();
                Console.Write("Add meg a film stúdiót:");
                string Studio = Console.ReadLine();

                var film = new Film
                {
                    Title = Title,
                    Year = Int32.Parse(Year),
                    Genre = Genre,
                    Director = Director,
                    Studio = Studio
                };

                list.Add(film);
                Console.WriteLine("-----------------------------");
            }
            

            XmlSerializer xs = new XmlSerializer(typeof(List<Film>));
            using (var f = File.Create("../../../movies.xml"))
            {
                xs.Serialize(f, list);
            }
        }
    }
}