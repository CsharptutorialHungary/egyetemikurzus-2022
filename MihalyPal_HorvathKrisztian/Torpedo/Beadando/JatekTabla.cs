using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando
{
    internal class JatekTabla
    {
        public int Szelesseg { get; set; }
        public int Magassag { get; set; }

        public Hajo[] Hajok { get; set; }
        public char[,] Palya { get; set; }
        public JatekTabla(int szelesseg, int magassag)
        {
            Szelesseg = szelesseg;
            Magassag = magassag;
            Palya = new char[magassag, szelesseg];
            Hajok = new Hajo[6]; //2-es 2 db, 3-as 2db, 4-es 1 db, 5-ös 1 db
            for (int i = 0; i < Hajok.Length; i++)
            {
                Hajok[i] = new Hajo();
            }
            Hajok[0].SetTipus(2);
            Hajok[1].SetTipus(2);
            Hajok[2].SetTipus(3);
            Hajok[3].SetTipus(3);
            Hajok[4].SetTipus(4);
            Hajok[5].SetTipus(5);
        }

        public void PalyatGeneral()


        {

            for (int i = -1; i < Magassag; i++)
            {
                char betuOszlop = 'A';
                if (i > -1)
                {
                    betuOszlop += (char)i;
                }
                else
                {
                    betuOszlop = ' ';
                }
                Console.Write(betuOszlop);
                if (i == -1)
                {
                    for (int j = 0; j < Szelesseg; j++)
                    {
                        int szamSor = 0;
                        szamSor += j;
                        Console.Write(" " + szamSor + " ");
                    }
                    Console.WriteLine();
                    continue;
                }
                for (int j = 0; j < Szelesseg; j++)
                {
                    Palya[i, j] = '~';
                    Console.Write(" " + Palya[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public Boolean HajotElhelyez(Hajo h)
        {
            //Hiba ellenőrzés ide is 
            //Ellenőrzöm, hogy a hajók ne legyenek egymáson/egymás mellett
            for (int i = 0; i < Hajok.Length; i++)
            {
                if(Hajok[i].X == h.X && Hajok[i].Y == h.Y)
                {
                    return false;
                }
            }
            for (int j = 0; j < h.GetTipus(); j++)
            {

                if (h.Orientacio == 1)
                {
                    Palya[h.X, h.Y + j] = 'O';
                    return true;

                }
                else
                {
                    Palya[h.X + j, h.Y] = 'O';
                    return true;
                }
            }

        }
        public void HajotLo(int x, int y)
        {
            for (int i = 0; i < Hajok.Length; i++)
            {
                if (Hajok[i].HajoKoordinataE(x, y) == true)
                {
                    Palya[x, y] = 'X';
                }
            }
            //Attributumai a pálya szélessége és magassága
            //egy tömb ami hajokat tartalmaz

            //Metódusai: Pályát létrehoz, Hajot elhelyez, Hajótkilő, Hajót elsüllyedt-e,

        }

        public void tablatKiir()
        {
            for (int i = -1; i < Magassag; i++)
            {
                char betuOszlop = 'A';
                if (i > -1)
                {
                    betuOszlop += (char)i;
                }
                else
                {
                    betuOszlop = ' ';
                }
                Console.Write(betuOszlop);
                if (i == -1)
                {
                    for (int j = 0; j < Szelesseg; j++)
                    {
                        int szamSor = 0;
                        szamSor += j;
                        Console.Write(" " + szamSor + " ");
                    }
                    Console.WriteLine();
                    continue;
                }
                for (int j = 0; j < Szelesseg; j++)
                {

                    Console.Write(" " + Palya[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
