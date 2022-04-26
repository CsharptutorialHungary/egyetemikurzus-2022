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

        public Form1()
        {
            InitializeComponent();
        }

        private void hangszerBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            hangszerDbDAO.getHangszerek(hangszerDataGridView);
        }

        private void insertButton_Click(object sender, EventArgs e)
        {
            hangszerDbDAO.InsertHangszer(nameTextBox, typeComboBox, priceTextBox, hangszerDataGridView);
        }

        private void modifyButton_Click(object sender, EventArgs e)
        {
            hangszerDbDAO.ModifyHangszer(idTextBox, nameTextBox, typeComboBox, priceTextBox, hangszerDataGridView);
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            hangszerDbDAO.Search(nameTextBox, hangszerDataGridView);
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
    }
}
