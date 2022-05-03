using HangszerUzlet.Controler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HangszerUzlet
{
    public partial class Form1 : Form
    {
        HangszerDbDAO hangszerDbDAO = new HangszerDbDAO();
        HangszerTipusDAO hangszerTipusDAO = new HangszerTipusDAO();

        public Form1()
        {
            InitializeComponent();
            hangszerTipusDAO.FillTipusok(typeComboBox);
        }

        private void hangszerBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            hangszerDbDAO.getHangszerek(hangszerDataGridView);
            hangszerDbDAO.AddNewRowOffline(dataGridViewAkcios);
        }

        private void insertButton_Click(object sender, EventArgs e)
        {
            _ = hangszerDbDAO.InsertHangszer(nameTextBox, typeComboBox, priceTextBox, hangszerDataGridView);
        }

        private void modifyButton_Click(object sender, EventArgs e)
        {
            hangszerDbDAO.ModifyHangszer(idTextBox, nameTextBox, typeComboBox, priceTextBox, hangszerDataGridView);
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            hangszerDbDAO.Search(nameTextBox, typeComboBox, hangszerDataGridView);
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            hangszerDbDAO.DeleteHangszer(idTextBox, hangszerDataGridView);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void saveToXML_Click(object sender, EventArgs e)
        {
            hangszerDbDAO.SaveToXML(hangszerDataGridView);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //hangszerDbDAO.AddNewRowOffline(dataGridViewAkcios);
        }
    }
}
