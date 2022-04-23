using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando
{
    internal class JatekTabla
    {
        private int Szelesseg { get; set; }
        private int Magassag { get; set; }

        private Hajo [] Hajok { get; set; }  
        private char [,]Palya { get; set; }
        public JatekTabla(int szelesseg, int magassag)
        {
            Szelesseg = szelesseg;
            Magassag = magassag;
            Palya = new char[szelesseg,magassag];
            Hajok = new Hajo[6]; //2-es 2 db, 3-as 2db, 4-es 1 db, 5-ös 1 db
        }

        public void PalyatGeneral()


        {

           for(int i = 0; i < Szelesseg; i++)
            {
                for (int j = 0; j < Magassag; j++)
                {
                    Palya[i,j] = '~';
                    Console.Write(" "+Palya[i,j]+" ");
                }
                Console.WriteLine();
            }
        }

        public void HajokatElhelyez()
        {
            for (int i = 0; i < Szelesseg; i++)
            {
                for (int j = 0; j < Magassag; j++)
                {
                    for(int k = 0; k <Hajok.Length; k++)
                    {

                        if (Hajok[k].X == i && Hajok[k].Y == j) {
                            Palya[i, j] = 'O';
                         }
                    }
                }
            }
        }
        //Attributumai a pálya szélessége és magassága
        //egy tömb ami hajokat tartalmaz

        //Metódusai: Pályát létrehoz, Hajot elhelyez, Hajótkilő, Hajót elsüllyedt-e,
    }
}
