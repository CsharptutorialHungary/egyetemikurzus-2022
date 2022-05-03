using HangszerUzlet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HangszerUzlet.Controler
{
    class HangszerTipusDAO
    {
        HangszerDBDataContext context = new HangszerDBDataContext();

        public List<HangszerTipusModel> FillTipusok(ComboBox comboBox)
        {
            List<HangszerTipusModel> hangszerTipusList = new List<HangszerTipusModel>();
            List<HangszerTipusModel> hangszerTipusListResult = new List<HangszerTipusModel>();

            try
            {
               hangszerTipusList = (from ht in context.HangszerTipus
                                    select new HangszerTipusModel
                                    {
                                        Id = ht.Id,
                                        Nev = ht.Nev
                                    }).ToList();

                foreach (var item in hangszerTipusList)
                {
                    HangszerTipusModel hangszerTipus = new HangszerTipusModel()
                    {
                        Nev = item.Nev
                    };

                    hangszerTipusListResult.Add(hangszerTipus);
                }

                FillCombobox(comboBox, hangszerTipusList);

            }
            catch (Exception ex)
            {
                var result = MessageBox.Show(ex.ToString(),
                        "Error",
                        MessageBoxButtons.AbortRetryIgnore,
                        MessageBoxIcon.Exclamation);
                if (result == DialogResult.Abort) throw;
            }
            

            return hangszerTipusListResult;
        }


        public void FillCombobox(ComboBox comboBox, List<HangszerTipusModel> hangszerTipusList)
        {
            foreach (var tipus in hangszerTipusList)
            {
                comboBox.Items.Add(tipus.Nev);
            }
        }
    }
}
