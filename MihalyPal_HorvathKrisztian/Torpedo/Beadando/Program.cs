using System;

namespace Beadando
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("A hajók pozícióit úgy kell megadni, hogy megadod az X és Y koordinátákat, majd azt, hogy \n milyen" +
                "irányban legyen elforgatva. Ezeknek a leírása a következő:\n" +
                "1: ez az alapértelmezett, ilyenkor vízszintesen van elhelyezve a hajó.\n" +
                "2: ez a függőleges elhelyezés.\n" +
                "figyelj majd arra, hogy a hajók ne lógjanak ki a pályáról szóval az általad megadott pozíciótól\n" +
                "mindig számolj el annyi blokkot, jobbra,vagy lefele amilyen típusú  a hajód!");

            JatekTabla j = new JatekTabla(15, 10);
            j.PalyatGeneral();

            AdatokatBeker bekeres = new AdatokatBeker();

            for (int i = 0; i < j.Hajok.Length; i++)
            {
                bekeres.BekerHajot(j.Hajok[i]);
            }
            Boolean jatekban = true;

            while (jatekban == true)
            {

            }
            j.HajokatElhelyez();
            Console.WriteLine();
            j.tablatKiir();
        }
    }
}