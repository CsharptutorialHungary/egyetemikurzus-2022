using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando
{
    record class AdatokatBeker
    {

        
        public string[] BekerHajot(Hajo h)
        { //TODO hibaellenőrzés rossz inputra
            
            Console.WriteLine("Kérlek helyezd el " + h.GetTipus() + " típusú hajódat orientációval együtt. (0||1)");
            string poziciok = Console.ReadLine();
            string [] splitPoziciok = poziciok.Split(' ');
            if (splitPoziciok.Length <= 2 )
            {
                Console.WriteLine("Hibásan adtad meg a koordinátákat!");
                splitPoziciok = BekerHajot(h);
            }
            h.X = Int32.Parse(splitPoziciok[0]);
            h.Y = Int32.Parse(splitPoziciok[1]);
            h.Orientacio = Int32.Parse(splitPoziciok[2]);
            return splitPoziciok;   
        }
        public int[] BekerLovest()
        {
            Console.WriteLine("Milyen pozícióra szeretnél lőni? (x,y)");
            string[] spliteltKoordinatak= Console.ReadLine().Split(' ');
            int[] eredmeny =new int[2];
            if (spliteltKoordinatak.Length == 0 || spliteltKoordinatak.Length == 1)
            {
                Console.WriteLine("Hibásan adtad meg a koordinátákat!");

                eredmeny = BekerLovest();
            }
            else
            {
                eredmeny[0] = Int32.Parse(spliteltKoordinatak[0]);
                eredmeny[1] = Int32.Parse(spliteltKoordinatak[1]);
            }
            return eredmeny;
            
        }
        // bekérLövést
        //bekérPályát (mekkora legyen)
        
    }
}
