using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando
{
    internal class JatekTabla
    {
        private static int Szamlalo = 0;
        public int Szelesseg { get; set; }
        public int Magassag { get; set; }

        public Hajo[] Hajok { get; set; }

        private Dictionary<String, char> TombElemeketTaroloDictionary;
        public char[,] Palya { get; set; }
        public JatekTabla(int magassag, int szelesseg)
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

            TombElemeketTaroloDictionary = new Dictionary<String, char>();

        }

        public void PalyatGeneral()
        {
         
         for (int i = -1; i < Magassag; i++)
            {
                char szamOszlop = '0';
                if (i > -1)
                {
                    szamOszlop += (char)i;
                }
                else
                {
                    szamOszlop = ' ';
                }
                Console.Write(szamOszlop);
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

                  
                    TombElemeketTaroloDictionary.Add(i.ToString() + j.ToString(), '~');
             
                    Console.Write(" " + Palya[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        public Boolean HajoLehelyezhetoE(Hajo h)
        {
            //Hiba ellenőrzés ide is 
            //Ellenőrzöm, hogy a hajók ne legyenek egymáson/egymás mellett
            if (Szamlalo == 6)
            {
                return false;
            }
            

            for (int i = 0; i < h.GetTipus(); i++)
            {
                
                if (h.Orientacio == 1)
                {
                    Console.WriteLine("A " + (h.Y) + ", " + (h.X + i) + " koordinátán szereplő dict karakter: " + TombElemeketTaroloDictionary[(h.Y ).ToString() + (h.X + i).ToString()]);

                    if (TombElemeketTaroloDictionary[(h.Y ).ToString() + (h.X+i).ToString()] != '~') 
                    {
                        
                        Console.WriteLine("HIBA, nem helyezheted el a hajódat ennyire közel egy másikhoz!!!");
                        return false;
                    }
                
                }
                else
                {
                    Console.WriteLine("A " + (h.Y+i) + ", " + (h.X) + " koordinátán szereplő dict karakter: " + TombElemeketTaroloDictionary[(h.Y+i).ToString() + (h.X).ToString()]);

                    if (TombElemeketTaroloDictionary[(h.Y+i).ToString() + (h.X).ToString()] != '~')
                    {
                        Console.WriteLine("HIBA, nem helyezheted el a hajódat ennyire közel egy másikhoz!!!");
                        return false;
                    }
               
                }

            }
            return true;

        }
        public void HajotElhelyez(Hajo h)
        {

            Console.WriteLine("A számláló: " + Szamlalo);
            Console.WriteLine("X: " + h.X + " Y: " + h.Y);
            for (int j = 0; j < h.GetTipus(); j++)
            {

                if (h.Orientacio == 1)
                {
                    try
                    {
                        Palya[h.Y, h.X + j] = 'O';
                    }
                    catch (IndexOutOfRangeException e)
                    {
                        Console.WriteLine("HIBA: " + e.Message);
                    }
                    TombElemeketTaroloDictionary[h.Y.ToString() + (h.X + j).ToString()] = 'O';

                    TombElemeketTaroloDictionary[(h.Y + 1).ToString() + (h.X + j).ToString()] = '_';
                    TombElemeketTaroloDictionary[(h.Y - 1).ToString() + (h.X + j).ToString()] = '_';
                    TombElemeketTaroloDictionary[h.Y.ToString() + (h.X + 1 + j).ToString()] = '_';
                    TombElemeketTaroloDictionary[h.Y.ToString() + (h.X - 1 + j).ToString()] = '_';
                    Console.WriteLine("A táblán a következő indexek foglaltak: " + (h.Y + 1) + ", " + (h.X + j));
                    Console.WriteLine("A táblán a következő indexek foglaltak: " + (h.Y - 1) + ", " + (h.X + j));
                    Console.WriteLine("A táblán a következő indexek foglaltak: " + (h.Y) + ", " + (h.X+1 + j));
                    Console.WriteLine("A táblán a következő indexek foglaltak: " + (h.Y) + ", " + (h.X-1 + j));

                }
                else
                {


                    try
                    {
                        Palya[h.Y + j, h.X] = 'O';
                    }
                    catch (IndexOutOfRangeException e)
                    {
                        Console.WriteLine("HIBA: " + e.Message);
                    }
                    TombElemeketTaroloDictionary[(h.Y + j).ToString() + h.X.ToString()] = 'O';

                    TombElemeketTaroloDictionary[(h.Y + 1 + j).ToString() + h.X.ToString()] = '_';
                    TombElemeketTaroloDictionary[(h.Y - 1 + j).ToString() + h.X.ToString()] = '_';
                    TombElemeketTaroloDictionary[(h.Y + j).ToString() + (h.X + 1).ToString()] = '_';
                    TombElemeketTaroloDictionary[(h.Y + j).ToString() + (h.X - 1).ToString()] = '_';

                }
            }
            Szamlalo++;

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
                char szamOszlop = '0';
                if (i > -1)
                {
                    szamOszlop += (char)i;
                }
                else
                {
                    szamOszlop = ' ';
                }
                Console.Write(szamOszlop);
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
