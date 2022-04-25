using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangszerUzlet.Controler
{
    class HangszerTipusDAO
    {
        HangszerDBDataContext context = new HangszerDBDataContext();

        public List<HangszerTipus> FillTipusok()
        {
            List<HangszerTipus> hangszerTipusList = new List<HangszerTipus>();
            hangszerTipusList = (from ht in context.HangszerTipus
                                 select new HangszerTipus
                                 {
                                     Nev = ht.Nev
                                 }).ToList();

            foreach (var item in hangszerTipusList)
            {
                HangszerTipus hangszerTipus = new HangszerTipus()
                {
                    Nev = item.Nev
                };

                hangszerTipusList.Add(hangszerTipus);
            }

            return hangszerTipusList;
        }
    }
}
