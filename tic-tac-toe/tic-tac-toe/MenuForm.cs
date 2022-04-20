using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tic_tac_toe
{
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
        }

        public void loadform(object Form)
        {
            if(this.mainpanel.Controls.Count > 0)
            {
                this.mainpanel.Controls.RemoveAt(0);
            }
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.mainpanel.Controls.Add(f);
            this.mainpanel.Tag = f;
            f.Show();
        }

        private void game_Click(object sender, EventArgs e)
        {
            loadform(new GameForm());
        }

        private void toplist_Click(object sender, EventArgs e)
        {
            loadform(new ToplistForm());
        }

        private void registraion_Click(object sender, EventArgs e)
        {
            loadform(new RegistrationForm());
        }

        private void tb_p1_TextChanged(object sender, EventArgs e)
        {
            GameForm.p1_name = tb_p1.Text;
        }

        private void tb_p2_TextChanged(object sender, EventArgs e)
        {
            GameForm.p2_name = tb_p2.Text;
        }
    }
}
