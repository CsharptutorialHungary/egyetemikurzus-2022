using HangszerUzlet.Controler;
using HangszerUzlet.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace HangszerUzlet
{
    public class HangszerDbDAO
    {
        HangszerDBDataContext context = new HangszerDBDataContext();
        HangszerTipusDAO hangszerTipus = new HangszerTipusDAO();

        public void getHangszerek(DataGridView dataGridView)
        {
            var hsz = from h in context.Hangszers select h;
            dataGridView.DataSource = hsz;
        }

        public void InsertHangszer(TextBox nev, ComboBox tipus, TextBox ar, DataGridView dataGridView)
        {
            string netto = ar.Text;
            double brutto = Convert.ToInt32(netto) + (Convert.ToInt32(netto) * 0.27);

            var hsz = new Hangszer
            {
                Nev = nev.Text,
                Tipus = tipus.SelectedItem.ToString(),
                Ar = Convert.ToInt32(brutto)
            };
            context.Hangszers.InsertOnSubmit(hsz);
            context.SubmitChanges();
            getHangszerek(dataGridView);
        }

        public void ModifyHangszer(TextBox id, TextBox nev, ComboBox tipus, TextBox ar, DataGridView dataGridView)
        {
            string netto = ar.Text;
            double brutto = Convert.ToInt32(netto) + (Convert.ToInt32(netto) * 0.27);

            var hsz = (from h in context.Hangszers where h.Id == Convert.ToInt32(id.Text) select h).FirstOrDefault();
            hsz.Nev = nev.Text;
            hsz.Tipus = tipus.SelectedItem.ToString();
            hsz.Ar = Convert.ToInt32(brutto);
            context.SubmitChanges();
            getHangszerek(dataGridView);
        }

        public void DeleteHangszer(TextBox id, DataGridView dataGridView)
        {
            var hsz = (from h in context.Hangszers where h.Id == Convert.ToInt32(id.Text) select h).FirstOrDefault();
            context.Hangszers.DeleteOnSubmit(hsz);
            context.SubmitChanges();
            getHangszerek(dataGridView);
        }

        public void Search(TextBox name, DataGridView dataGridView)
        {
            var hsz = from h in context.Hangszers where h.Nev == name.Text select h;
            dataGridView.DataSource = hsz;
        }

        public void SaveToXML(DataGridView dataGridView)
        {
            List<HangszerModel> hangszerList = new List<HangszerModel>();

            try
            {
                 hangszerList = (from h in context.Hangszers
                                               select new HangszerModel
                                               {
                                                   Id = h.Id,
                                                   Nev = h.Nev,
                                                   Tipus = h.Tipus,
                                                   Ar = h.Ar
                                               }).ToList();

                XElement element = new XElement("Hangszerek",
                                       (from h in hangszerList 
                                        select new XElement("Hangszer",
                                            new XElement("Name", h.Nev),
                                            new XElement("Type", h.Tipus),
                                            new XElement("Price", h.Ar))));

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "XML Files|*.xml";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    element.Save(saveFileDialog.FileName);
                }

            }
            catch(Exception ex) 
            {
               var result = MessageBox.Show(ex.ToString(),
                        "Error Information",
                        MessageBoxButtons.AbortRetryIgnore,
                        MessageBoxIcon.Exclamation);
                if (result == DialogResult.Abort) throw;
            }

           
        }
    }
}
