using System;
using System.Diagnostics;

namespace UserInput
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int szam;
                string szamSzoveg = Console.ReadLine();
                if (int.TryParse(szamSzoveg, out szam))
                {
                    Console.WriteLine("A szam negyzete: {0}", szam * szam);
                }
                else
                {
                    Console.WriteLine("Ez nem szám");
                }
                   

                /*szam = Convert.ToInt32(szamSzoveg);
                Console.WriteLine("A szam negyzete: {0}", szam * szam);*/
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
                //Pokémon exception handling
                Console.WriteLine("hiba");
            }
        }
    }
}
