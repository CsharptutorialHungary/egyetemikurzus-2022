using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tic_tac_toe
{
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void tb_username_TextChanged(object sender, EventArgs e)
        {

        }

        private void tb_password_TextChanged(object sender, EventArgs e)
        {

        }

        private void password_again_tb_TextChanged(object sender, EventArgs e)
        {

        }

        private void sign_up_btn_Click(object sender, EventArgs e)
        {
            if (tb_password.Text != tb_password_again.Text)
            {
                try
                {
                    MessageBox.Show("Passwords do not match!", "TicTacToe",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "TicTacToe", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                List<Player> playerList = ToplistForm.loadPlayersData();
                int exitCode = 0;
                foreach (Player player in playerList)
                {
                    if (player.Name == tb_username.Text)
                    {
                        MessageBox.Show("The username is already in use!", "TicTacToe",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        exitCode = 1;
                        break;
                    }
                }
                if (exitCode == 0)
                {
                    playerList.Add(new Player()
                    {
                        Name = tb_username.Text,
                        Password = tb_password.Text,
                        Wins = 0,
                        Loses = 0,
                        Draw = 0,
                    });
                    string playersJson = JsonSerializer.Serialize(playerList);
                    File.WriteAllText(@"C:\Users\gabri\Desktop\ISKOLA\6.félév\C#\egyetemikurzus-2022\toplist.json", playersJson);
                    MessageBox.Show("You have successfully logged in.", "TicTacToe",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
