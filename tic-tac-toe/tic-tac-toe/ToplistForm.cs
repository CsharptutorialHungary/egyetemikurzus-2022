using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Threading.Tasks;

namespace tic_tac_toe
{
    public partial class ToplistForm : Form
    {
        bool nameOrderByAsc = true;
        bool winsOrderByAsc = true;
        bool losesOrderByAsc = true;
        bool drawOrderByAsc = true;

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

        private async void order_by_wins_btn_Click(object sender, EventArgs e)
        {
            toplist.DataSource = await orderBy(winsOrderByAsc, "Wins");
            winsOrderByAsc = !winsOrderByAsc;
        }

        private async void order_by_name_btn_Click(object sender, EventArgs e)
        {
            toplist.DataSource = await orderBy(nameOrderByAsc, "Name");
            nameOrderByAsc = !nameOrderByAsc;
        }

        private async void order_by_loses_btn_Click(object sender, EventArgs e)
        {
            toplist.DataSource = await orderBy(losesOrderByAsc, "Loses");
            losesOrderByAsc = !losesOrderByAsc;
        }

        private async void order_by_draw_btn_Click(object sender, EventArgs e)
        {
            toplist.DataSource = await orderBy(drawOrderByAsc, "Draw");
            drawOrderByAsc = !drawOrderByAsc;
        }

        private async Task<List<Player>> orderBy(bool by, string ordered)
        {
            if (by)
            {
                return MenuForm.players.OrderByDescending(player => player.GetType().GetProperty(ordered).GetValue(player, null)).ToList();
            }
            else
            {
                return MenuForm.players.OrderBy(player => player.GetType().GetProperty(ordered).GetValue(player, null)).ToList();
            }
        }

        private void find_by_user_name_btn_Click(object sender, EventArgs e)
        {
            toplist.DataSource = MenuForm.players.Where(player => player.Name == user_name_input.Text).ToList();
        }
    }
}
