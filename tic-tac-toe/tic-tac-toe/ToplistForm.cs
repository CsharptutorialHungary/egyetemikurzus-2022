using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace tic_tac_toe
{
    public partial class ToplistForm : Form
    {
        public ToplistForm()
        {
            InitializeComponent();
        }

        private void ToplistForm_Load(object sender, EventArgs e)
        {
            toplist.DataSource = MenuForm.players;
        }

        private void toplist_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
