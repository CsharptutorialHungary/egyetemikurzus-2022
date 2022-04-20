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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            bool player1LoggedIn = false;
            bool player2LoggedIn = false;
            List<Player> playerList = ToplistForm.loadPlayersData();
            foreach(Player player in playerList)
            {
                if (player.Name == tb_p1_username.Text && player.Password == tb_p1_password.Text)
                {
                    player1LoggedIn = true;
                    GameForm.p1 = player;

                }
                if (player.Name == tb_p2_username.Text && player.Password == tb_p2_password.Text)
                {
                    player2LoggedIn = true;
                    GameForm.p2 = player;
                }
            }
            if(player1LoggedIn && player2LoggedIn)
            {
                GameForm.p1_name = tb_p1_username.Text;
                GameForm.p2_name = tb_p2_username.Text;
                MessageBox.Show("You have successfully logged in.", "TicTacToe",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else
            {
                if (!player1LoggedIn)
                {
                    MessageBox.Show("Invalid username or password for player1", "TicTacToe",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if(!player2LoggedIn)
                {

                    MessageBox.Show("Invalid username or password for player2", "TicTacToe",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
