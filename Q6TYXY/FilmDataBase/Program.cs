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
            Console.WriteLine("3. Szűrés rendező szerint");
            Console.WriteLine("4. Rendezés értékelés szerint");
            Console.WriteLine("5. Csoportosítás studio szerint");
            Console.WriteLine("6. Átlag értékelés");
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
                case "3":
                    Console.Write("Add meg a rendező nevét:");
                    ListByDirector(Console.ReadLine());
                    return true;
                case "4":
                    OrderByRate();
                    return true;
                case "5":
                    GroupByStudio();
                    return true;
                case "6":
                    MoviesRateAvarage();
                    return true;
                case "Q":
                    return false;
                default:
                    return true;
            }


        }

        private static void MoviesRateAvarage()
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<Film>));
            using (var f = File.OpenRead("../../../movies.xml"))
            {
                List<Film> movies = xs.Deserialize(f) as List<Film>;

                double Avg = movies.Select(x => x.Rate).Average();
                Console.WriteLine("A filmek átlag értékelése: " + Avg);
                Console.ReadLine();


            }
        }

        private static void GroupByStudio()
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<Film>));
            using (var f = File.OpenRead("../../../movies.xml"))
            {
                List<Film> movies = xs.Deserialize(f) as List<Film>;

                var result = from movie in movies
                             group movie by movie.Studio into titleWithStudio
                             select titleWithStudio;
                foreach (var titleWithStudio in result)
                {
                    foreach (var movie in titleWithStudio)
                    {
                        Console.WriteLine("Studio: " + movie.Studio);
                        Console.WriteLine("Cím: " + movie.Title);
                    }
                }
                Console.ReadLine();

            }
        }

        private static void OrderByRate()
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<Film>));
            using (var f = File.OpenRead("../../../movies.xml"))
            {
                List<Film> movies = xs.Deserialize(f) as List<Film>;

                var result = from movie in movies
                             orderby movie.Rate descending
                             select movie;
                foreach (var movie in result)
                {
                    Console.WriteLine("Film címe: " + movie.Title);
                    Console.WriteLine("Film éve: " + movie.Year);
                    Console.WriteLine("Film műfaja: " + movie.Genre);
                    Console.WriteLine("Film rendezője: " + movie.Director);
                    Console.WriteLine("Film stúdiója: " + movie.Studio);
                    Console.WriteLine("Film értékelése: " + movie.Rate);
                    Console.WriteLine("-----------------------------");
                }
                Console.ReadLine();

            }
        }

        private static void ListByDirector(String director)
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<Film>));
            using (var f = File.OpenRead("../../../movies.xml"))
            {
                List<Film> movies = xs.Deserialize(f) as List<Film>;

                var result = from movie in movies
                             where movie.Director == director
                             select movie;
                foreach (var movie in result)
                {
                    Console.WriteLine("Film címe: " + movie.Title);
                    Console.WriteLine("Film éve: " + movie.Year);
                    Console.WriteLine("Film műfaja: " + movie.Genre);
                    Console.WriteLine("Film rendezője: " + movie.Director);
                    Console.WriteLine("Film stúdiója: " + movie.Studio);
                    Console.WriteLine("Film értékelése: " + movie.Rate);
                    Console.WriteLine("-----------------------------");
                }
                Console.ReadLine();

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
                    Console.WriteLine("Film címe: " + movie.Title);
                    Console.WriteLine("Film éve: " + movie.Year);
                    Console.WriteLine("Film műfaja: " + movie.Genre);
                    Console.WriteLine("Film rendezője: " + movie.Director);
                    Console.WriteLine("Film stúdiója: " + movie.Studio);
                    Console.WriteLine("Film értékelése: " + movie.Rate);
                    Console.WriteLine("-----------------------------");
                }
                Console.ReadLine();

            }
        }

        private static void AddNewMovie()
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<Film>));
            if (File.Exists("../../../movies.xml"))
            {


                using (var f = File.OpenRead("../../../movies.xml"))
                {
                    List<Film> movies = xs.Deserialize(f) as List<Film>;
                    Console.WriteLine("Hány filmet szeretnél hozzáadni?:");
                    string movieCount = Console.ReadLine();

                    for (int i = 0; i < Int32.Parse(movieCount); i++)
                    {
                        try
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
                            Console.Write("Add meg a film értékelését:");
                            string Rate = Console.ReadLine();

                            var film = new Film
                            {
                                Title = Title,
                                Year = Int32.Parse(Year),
                                Genre = Genre,
                                Director = Director,
                                Studio = Studio,
                                Rate = Double.Parse(Rate)
                            };

                            movies.Add(film);

                        }
                        catch (Exception ex) when (ex is System.FormatException)
                        {
                            Console.WriteLine("Rossz formátumban adtad meg az adatokat!! " + ex.Message);
                            Console.ReadLine();

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            Console.ReadLine();

                        }


                    }
                    xs.Serialize(f, movies);




                }



            }
            else
            {

            }

            List<Film> list = new List<Film>();

            for (int i = 0; i < Int32.Parse(movieCount); i++)
            {

                try
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
                    Console.Write("Add meg a film értékelését:");
                    string Rate = Console.ReadLine();

                    var film = new Film
                    {
                        Title = Title,
                        Year = Int32.Parse(Year),
                        Genre = Genre,
                        Director = Director,
                        Studio = Studio,
                        Rate = Double.Parse(Rate)
                    };

                    list.Add(film);

                }
                catch (Exception ex) when (ex is System.FormatException)
                {
                    Console.WriteLine("Rossz formátumban adtad meg az adatokat!! " + ex.Message);
                    Console.ReadLine();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();

                }


            }
            XmlSerializer xs = new XmlSerializer(typeof(List<Film>));
            if (File.Exists("../../../movies.xml"))
            {

                try
                {
                    using (var f = File.OpenRead("../../../movies.xml"))
                    {
                        List<Film> movies = xs.Deserialize(f) as List<Film>;

                        movies.AddRange(list);
                        xs.Serialize(f, movies);


                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);

                }


            }
            else
            {
                try
                {

                    using (var f = File.Create("../../../movies.xml"))
                    {
                        xs.Serialize(f, list);
                    }

                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }

            }


        }
    }
}