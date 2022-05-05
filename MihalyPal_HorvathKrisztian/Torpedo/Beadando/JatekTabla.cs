using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando
{
    public class JatekTabla
    {
        private static int Szamlalo = 0;
        public int Szelesseg { get; set; }
        public int Magassag { get; set; }

        public List<Hajo> Hajok { get; set; }

        private Dictionary<String, char> TombElemeketTaroloDictionary;
        public char[,] Palya { get; set; }
        public JatekTabla(int magassag, int szelesseg)
        {
            Szelesseg = szelesseg;
            Magassag = magassag;
            Palya = new char[magassag, szelesseg];
            Hajok = new List<Hajo>();//2-es 2 db, 3-as 2db, 4-es 1 db, 5-ös 1 db
            for (int i = 0; i < 6; i++)
            {
                Hajo ujHajo = new Hajo();
                Hajok.Add(ujHajo);

            }


            var eredmeny = from hajo in Hajok
                           select hajo;
            int k = 0;

            foreach (var egyHajo in eredmeny)
            {

                if (k < 2)
                {
                    egyHajo.SetTipus(2);
                }
                else if (k >= 2 && k < 4)
                {
                    egyHajo.SetTipus(3);
                }
                else if (k == 4)
                {
                    egyHajo.SetTipus(4);
                }
                else
                {
                    egyHajo.SetTipus(k);
                }
                k++;

            }
            TombElemeketTaroloDictionary = new Dictionary<String, char>();


        }

        public void PalyatGeneral()
        {

            for (int i = 0; i < Magassag; i++)
            {

                for (int j = 0; j < Szelesseg; j++)
                {
                    Palya[i, j] = '~';
                    TombElemeketTaroloDictionary.Add(i.ToString() + j.ToString(), '~');

                }
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

                    if (h.X + i < 0 || h.Y < 0 || h.X + i >= Szelesseg || h.Y >= Magassag)
                    {
                        return false;
                    }

                    if (TombElemeketTaroloDictionary[(h.Y).ToString() + (h.X + i).ToString()] != '~')
                    {

                        Console.WriteLine("HIBA, nem helyezheted el a hajódat ennyire közel egy másikhoz!!!");
                        return false;
                    }

                }
                else
                {
                    if (h.X < 0 || h.Y + i < 0 || h.X >= Szelesseg || h.Y + i >= Magassag)
                    {
                        return false;
                    }

                    if (TombElemeketTaroloDictionary[(h.Y + i).ToString() + (h.X).ToString()] != '~')
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

            for (int j = 0; j < h.GetTipus(); j++)
            {

                if (h.Orientacio == 1)
                {
                    try
                    {
                        Palya[h.Y, h.X + j] = 'O';
                        h.XKoordinatak[j] = h.X + j;
                        h.YKoordinatak[j] = h.Y;
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
                }
                else
                {

                    try
                    {
                        Palya[h.Y + j, h.X] = 'O';
                        h.XKoordinatak[j] = h.X;
                        h.YKoordinatak[j] = h.Y + j;
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

        public Boolean hajotLoJatekos(int x, int y, JatekTabla lovoTabla)
        {
            for (int i = 0; i < Hajok.Count; i++)
            {
                if (Hajok[i] != null)
                {
                    for (int j = 0; j < Hajok[i].GetTipus(); j++)
                    {
                        if (this.Palya[y, x] == 'O' && Hajok[i].XKoordinatak[j] == x && Hajok[i].YKoordinatak[j] == y)
                        {

                            this.Palya[y, x] = '#';
                            lovoTabla.Palya[y, x] = '#';
                            Hajok[i].Eletero = Hajok[i].Eletero - 1;


                            if (Hajok[i].Eletero == 0)
                            {

                                return true;
                            }
                            return false;

                        }
                    }
                }

            }
            lovoTabla.Palya[y, x] = 'X';
            return false;
        }
        public int hajotLoGep(int counter)
        {
            Boolean ujra = true;
            while (ujra)
            {
                Random r = new Random();
                int x = r.Next(0, 10);
                int y = r.Next(0, 10);
                if (counter % 1 != 0)
                {
                    if (this.Palya[y, x] == '~')
                    {
                        this.Palya[y, x] = '_';
                        ujra = false;
                    }
                }
                else
                {
                    if (this.Palya[y, x] == 'O')
                    {
                        this.Palya[y, x] = 'X';
                        ujra = false;
                        for (int i = 0; i < Hajok.Count; i++)
                        {
                            if (Hajok[i] != null && Hajok[i].Tipus != null)
                            {
                                for (int j = 0; j < Hajok[i].GetTipus(); j++)
                                {

                                    if (Hajok[i].XKoordinatak[j] == x && Hajok[i].YKoordinatak[j] == y)
                                    {
                                        Hajok[i].Eletero--;
                                        if (Hajok[i].Eletero == 0)
                                        {
                                            //Hajok[i] = null;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

            }
            return (counter + 1);


        }
        public Boolean eletbenMaradtHajok()
        {
            Boolean vanMegHajo = false;
            var eredmeny = from hajo in Hajok
                           where hajo.Eletero != 0
                           select hajo;
            Console.WriteLine("Maradt még életben hajó!!!");
            foreach (var egyHajo in eredmeny)
            {

                vanMegHajo = true;
                Console.WriteLine(egyHajo.Tipus + " típusú hajó életereje: " + egyHajo.Eletero);
            }
            return vanMegHajo;

        }
        public Boolean jatszhatMeg()
        {
            for (int i = 0; i < Hajok.Count; i++)
            {
                if (Hajok[i].Eletero != 0)
                {
                    return true;
                }
            }
            return false;
        }


    }
}
