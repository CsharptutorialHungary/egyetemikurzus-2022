using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando
{
    public class Hajo
    {
        //Itt megkéne csinálni a koordinátákat úgy, hogy az egész hajó testre érvényesek legyenek 
        public int X { get; set; }
        public int Y { get; set; }

        public int[] XKoordinatak { get; set; }

        public int[] YKoordinatak { get; set; }

        public int Tipus { get; set; }
        public int Eletero { get; set; }
        public int Orientacio { get; set; }
        public Hajo(int x, int y, int tipus, int eletero)
        {
            X = x;  
            Y = y;  
            Tipus = tipus;  
            Eletero = eletero;  
            XKoordinatak = new int[tipus];
            YKoordinatak = new int[tipus];

        }
        public Hajo()
        {
            Tipus = 0;
        }
        public void SetTipus(int tipus)
        {
            if(tipus >= 2 && tipus <= 5)
            {
                this.Tipus = tipus;
                this.Eletero = tipus;
                this.XKoordinatak = new int[tipus];
                this.YKoordinatak = new int[tipus];
            }
        }
        public int GetTipus() { return this.Tipus; }
        public Boolean HajoKoordinataE(int x, int y)
        {
            if(x == X && y == Y)
            {
                return true;    
            }
            else
            {
                return false;  
            }
        }
        //Attributumai egy x és y kezdőérték 
        //tipusa: 2,3,4,5
        //életerő: ami kezdetben a típussal egyezik meg de ez csökken
    }
}
