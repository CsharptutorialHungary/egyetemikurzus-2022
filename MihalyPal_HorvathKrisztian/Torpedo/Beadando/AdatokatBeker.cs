using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando
{
    internal class AdatokatBeker
    {


        public Hajo BekerHajot(Hajo h)
        { //TODO hibaellenőrzés rossz inputra

            Console.WriteLine("Kérlek helyezd el " + h.GetTipus() + " típusú hajódat.");
            string poziciok = Console.ReadLine();
            string[] splitPoziciok = poziciok.Split(' ');
            h.X = Int32.Parse(splitPoziciok[0]);
            h.Y = Int32.Parse(splitPoziciok[1]);
            return h;
        }
        // bekérLövést
        //bekérPályát (mekkora legyen)

    }
}