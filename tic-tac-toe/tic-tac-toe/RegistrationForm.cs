using System;
using System.IO;
using System.Text.Json;
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
                int exitCode = 0;
                foreach (Player player in MenuForm.players)
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
                    MenuForm.players.Add(new Player()
                    {
                        Name = tb_username.Text,
                        Password = tb_password.Text,
                        Wins = 0,
                        Loses = 0,
                        Draw = 0,
                    });
                    string playersJson = JsonSerializer.Serialize(MenuForm.players);
                    try {
                        File.WriteAllText(MenuForm.gameConfig.ToplistPath, playersJson);
                        MessageBox.Show("You have successfully registered.", "TicTacToe",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MenuForm.loadPlayersData();
                    }
                        catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "TicTacToe", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
