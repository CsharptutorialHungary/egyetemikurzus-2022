using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TornamentResults
{
    internal class DataType
    {
        public string Tournament { get; set; }
        public string Home { get; init; }
        public string Guest { get; init; }
        public int HomeScore { get; init; }
        public int GuestScore { get; init; }

        //konstruktor adatrögzítéshez
        public DataType(string Tournament, string Home, string Guest, Boolean Bride = false)
        {
            if (Home == Guest) throw new ArgumentException("A két csapat neve nem egyezhet meg");
            this.Tournament = Tournament;
            this.Home = Home;
            this.Guest = Guest;
            if (Bride)
            {
                Console.WriteLine("Mennyivel akarja megvesztegetni a személyzetet? (50-500$)");
                string? input = Console.ReadLine();
                int BrideVal=this.checkValue(input);
                if(BrideVal == -1)
                {
                    throw new Exception("Én megvesztegethetetlen vagyok! Meccsfelvételi jog megvonva.");
                }
                var goals=this.getGoals(this.Briding(BrideVal));
                this.HomeScore = goals[0];
                this.GuestScore = goals[1];

            }
            else
            {
                var goals = this.getGoals();
                this.HomeScore = goals[0];
                this.GuestScore = goals[1];
            }

        }

        //konstruktor json-ből való beolvasáshoz
        [JsonConstructorAttribute]
        public DataType(string tournament, string home, string guest, int homeScore, int guestScore)
        {
            Tournament = tournament;
            Home = home;
            Guest = guest;
            HomeScore = homeScore;
            GuestScore = guestScore;
        }

        //ellenőrizzük a vesztegetés összegét: 50-500 intervallumba esik-e, illetve számot adott-e meg a user
        private int checkValue(string? input)
        {
            int val = -1;
            while (true)
            {
                if (input != null)
                {
                    try
                    {
                        input = input.Replace("$", "").Trim();
                        val = int.Parse(input);
                        if(val < 50 || val > 500)
                        {
                            val = -1;
                            Console.WriteLine("Ennyivel nem vesztegethet! Eljátszotta esélyét!");
                            break;
                        }
                    }
                    catch (FormatException f)
                    {
                        Console.WriteLine("Nem számot adott meg, próbálja újra!");
                        input=Console.ReadLine();
                        continue;
                    }catch(Exception e)
                    {
                        Console.WriteLine("Egyéb hiba történt, próbálja újra!");
                        input = Console.ReadLine();
                        continue;
                    }
                    break;
                }
            }
            return val;           
        }

        //random gólok generálása
        private int[] getGoals(Boolean Sucess=false)
        {
            int[] goals = new int[2];
            Random rand = new Random();
            if (Sucess)
            {
                Console.WriteLine("Ki nyerjen? ('g': vendég / 'h': hazai)");
                string? winner=Console.ReadLine();
                if (winner.Trim() == "g")
                {
                    goals[0]=rand.Next(0,5);
                    goals[1]=goals[0]+1;
                }else if(winner.Trim() == "h")
                {
                    goals[1] = rand.Next(0, 5);
                    goals[0] = goals[0] + 1;
                }
                else
                {
                    Console.WriteLine("Látom nem tud dönteni, legyen döntetlen.");
                    goals[0] = goals[1] = rand.Next(0, 5);
                }
            }
            else
            {
                goals[0] = rand.Next(0,5);
                goals[1] = rand.Next(0,5);
            }
            return goals;
        }

        //sikerült-e a vesztegetés
        private Boolean Briding(int money)
        {
            Random random = new Random();
            if(random.Next(50, 500) <= money)
            {
                return true;
            }
            return false;
        }

        //toString metódus kiíráshoz
        public string toString()
        {
            return "Tournament: " + this.Tournament + "\nHome: " + this.Home + ", goals: " + this.HomeScore +
                "\nGuest: " + this.Guest + ", goals: " + this.GuestScore;
        }
    }
}
