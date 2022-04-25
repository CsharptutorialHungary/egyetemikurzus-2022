using HangszerUzlet.Controler;
using HangszerUzlet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            tipus.DataSource = hangszerTipus.FillTipusok();

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
            tipus.DataSource = hangszerTipus.FillTipusok();

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
    }
}
