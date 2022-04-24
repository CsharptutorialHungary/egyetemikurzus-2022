using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando
{
    internal class AdatokatBeker
    {

        
        public string BekerHajot(Hajo h)
        { //TODO hibaellenőrzés rossz inputra
            
            Console.WriteLine("Kérlek helyezd el " + h.GetTipus() + " típusú hajódat.");
            string poziciok = Console.ReadLine();
            string [] splitPoziciok = poziciok.Split(' ');
            h.X = Int32.Parse(splitPoziciok[0]);
            h.Y = Int32.Parse(splitPoziciok[1]);
            h.Orientacio = Int32.Parse(splitPoziciok[2]);
            return poziciok;   
        }
        public int[] BekerLovest()
        {
            Console.WriteLine("Milyen pozícióra szeretnél lőni? (x,y)");
            string[] spliteltKoordinatak= Console.ReadLine().Split(' ');
            int[] eredmeny =new int[2];
            eredmeny[0] = Int32.Parse(spliteltKoordinatak[0]);
            eredmeny[1] = Int32.Parse(spliteltKoordinatak[1]);
            return eredmeny;
            
        }
        // bekérLövést
        //bekérPályát (mekkora legyen)
        
    }
}
