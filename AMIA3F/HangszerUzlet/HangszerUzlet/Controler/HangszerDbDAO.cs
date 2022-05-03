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
using System.Xml.Serialization;

namespace HangszerUzlet
{
    public class HangszerDbDAO
    {
        HangszerDBDataContext context = new HangszerDBDataContext();
        HangszerTipusDAO hangszerTipus = new HangszerTipusDAO();

        public readonly string readonlyNev = "Szintetizáror";
        public readonly string readonlyTipus = "Ütős";
        public readonly int readonlyRegiAr = 32500;
        public readonly int readonlyAr = 27500;

        public void getHangszerek(DataGridView dataGridView)
        {
            var hsz = from h in context.Hangszers select h;
            dataGridView.DataSource = hsz;
        }

        public void AddNewRowOffline(DataGridView dataGridView)
        {
            dataGridView.Rows.Clear();
            DataGridViewRow row = (DataGridViewRow)dataGridView.Rows[0].Clone();
            row.Cells[0].Value = readonlyNev;
            row.Cells[1].Value = readonlyTipus;
            row.Cells[2].Value = readonlyRegiAr;
            row.Cells[3].Value = readonlyAr;
            dataGridView.Rows.Add(row);
        }

        public async Task InsertHangszer(TextBox nev, ComboBox tipus, TextBox ar, DataGridView dataGridView)
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
            await Task.Run(() =>
            {
                MessageBox.Show("Sikeres Létrehozás");
            });
        }

        public void ModifyHangszer(TextBox id, TextBox nev, ComboBox tipus, TextBox ar, DataGridView dataGridView)
        {
            try
            {
                string netto = ar.Text;
                double brutto = Convert.ToInt32(netto) + (Convert.ToInt32(netto) * 0.27);

                var hsz = (from h in context.Hangszers where h.Id == Convert.ToInt32(id.Text) select h).FirstOrDefault();
                hsz.Nev = nev.Text;
                hsz.Tipus = tipus.SelectedItem.ToString();
                hsz.Ar = Convert.ToInt32(brutto);
                context.SubmitChanges();
                getHangszerek(dataGridView);

                MessageBox.Show("Sikeres Módosítás");
            }
            catch (Exception e)
            {
                MessageBox.Show("Sikertelen Módosítás, kérlek tölts ki pontosan minden adatot");
            }
        }

        public void DeleteHangszer(TextBox id, DataGridView dataGridView)
        {
            var hsz = (from h in context.Hangszers where h.Id == Convert.ToInt32(id.Text) select h).FirstOrDefault();
            context.Hangszers.DeleteOnSubmit(hsz);
            context.SubmitChanges();
            getHangszerek(dataGridView);
        }

        public void Search(TextBox nev, ComboBox tipus, DataGridView dataGridView)
        {
            try 
            {

                if (!string.IsNullOrEmpty(nev.Text) && tipus.SelectedItem == null)
                {
                    var hsz = context.Hangszers.Where(x => x.Nev == nev.Text).ToList();
                    dataGridView.DataSource = hsz;
                }

                if (tipus.SelectedItem != null && string.IsNullOrEmpty(nev.Text))
                {
                    var hsz = context.Hangszers.Where(x => x.Tipus == tipus.SelectedItem.ToString()).ToList();
                    dataGridView.DataSource = hsz;
                }

                if (tipus.SelectedItem != null && !string.IsNullOrEmpty(nev.Text))
                {
                    var hsz = context.Hangszers.Where(x => x.Nev == nev.Text && x.Tipus == tipus.SelectedItem.ToString()).ToList();
                    dataGridView.DataSource = hsz;
                }

            }
            catch (Exception e)
            {
                var result = MessageBox.Show(e.ToString(),
                        "Error",
                        MessageBoxButtons.AbortRetryIgnore,
                        MessageBoxIcon.Exclamation);
                if (result == DialogResult.Abort) throw;
            }
            
        }

        public void HangszerFiltering(DataGridView dataGridView, TextBox idTextBox, TextBox nameTextBox)
        {
            var hsz = from h in context.Hangszers where h.Nev == nameTextBox.Text select h;
            dataGridView.DataSource = hsz;
        }

        public void SaveToXML(DataGridView dataGridView)
        {

            List<HangszerModel> hangszerList = new List<HangszerModel>();
            XmlSerializer ser = new XmlSerializer(typeof(XmlElement));
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
            catch (Exception ex)
            {
                var result = MessageBox.Show(ex.ToString(),
                         "Error",
                         MessageBoxButtons.AbortRetryIgnore,
                         MessageBoxIcon.Exclamation);
                if (result == DialogResult.Abort) throw;
            }
        }
    }
}
