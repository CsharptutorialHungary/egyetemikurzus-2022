using System;

namespace Beadando
{
    internal class Program
    {
        static void Main(string[] args)
        {


            //Ellenfél táblájának generálása
         /*   JatekTabla ellenfelTabla = new JatekTabla(10, 10);
            ellenfelTabla.PalyatGeneral();
            for(int i = 0; i < 6; i++)
            {
                Random rnd = new Random();
                ellenfelTabla.Hajok[i].X = rnd.Next(0,9);
                ellenfelTabla.Hajok[i].Y = rnd.Next(0, 9);
                ellenfelTabla.Hajok[i].Orientacio = rnd.Next(0,2);

                ellenfelTabla.HajotElhelyez(ellenfelTabla.Hajok[i]);
                ellenfelTabla.tablatKiir();
            }
         */
            Console.Clear();
          
            //Ellenfél táblájának generálásának a vége
            Console.WriteLine("A hajók pozícióit úgy kell megadni, hogy megadod az X és Y koordinátákat, majd azt, hogy \n milyen" +
                "irányban legyen elforgatva. Ezeknek a leírása a következő:\n" +
                "1: ez az alapértelmezett, ilyenkor vízszintesen van elhelyezve a hajó.\n" +
                "2: ez a függőleges elhelyezés.\n" +
                "figyelj majd arra, hogy a hajók ne lógjanak ki a pályáról szóval az általad megadott pozíciótól\n" +
                "mindig számolj el annyi blokkot, jobbra,vagy lefele amilyen típusú  a hajód!");
            
            JatekTabla jatekTabla = new JatekTabla(10, 10);
            jatekTabla.PalyatGeneral();

            AdatokatBeker bekeres = new AdatokatBeker();

          
            Boolean jatekban = true;

            for (int i = 0; i < jatekTabla.Hajok.Length; i++)
            {
                Boolean joVoltE = false;
                while (joVoltE == false)
                {
                    bekeres.BekerHajot(jatekTabla.Hajok[i]);
                    joVoltE = jatekTabla.HajoLehelyezhetoE(jatekTabla.Hajok[i]);

                }

                if (joVoltE == true)
                {
                    jatekTabla.HajotElhelyez(jatekTabla.Hajok[i]);
                    jatekTabla.tablatKiir();
                }

            }

            Console.WriteLine();
            while (jatekban == true)
            {
               

            }
        }
    }
}
