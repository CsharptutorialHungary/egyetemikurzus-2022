using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando
{
    internal class Hajo
    {
        private int X { get; set; }
        private int Y { get; set; }

        private int Tipus; 
        private int Eletero { get; set; }

        public Hajo(int x, int y, int tipus, int eletero)
        {
            X = x;  
            Y = y;  
            Tipus = tipus;  
            Eletero = eletero;  

        }
        public Hajo()
        {
            
        }
        public void SetTipus(int tipus)
        {
            if(tipus >= 2 && tipus <= 5)
            {
                this.Tipus = tipus;
            }
        }
        //Attributumai egy x és y kezdőérték 
        //tipusa: 2,3,4,5
        //életerő: ami kezdetben a típussal egyezik meg de ez csökken
    }
}
