using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Text.Json;

namespace tic_tac_toe
{

    public partial class MenuForm : Form
    {

        public static List<Player> players = new List<Player>();
        public static GameConfig gameConfig = new GameConfig("tic-tac-toe");

        public MenuForm()
        {
            InitializeComponent();
            loadPlayersData();
            this.Text = gameConfig.GameName;
        }

        public void loadform(object Form)
        {
            if (this.mainpanel.Controls.Count > 0)
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

        public static void loadPlayersData()
        {
            if (File.Exists(gameConfig.ToplistPath))
            {
                using (StreamReader r = new StreamReader(gameConfig.ToplistPath))
                {
                    string json = r.ReadToEnd();
                    players = JsonSerializer.Deserialize<List<Player>>(json);
                }
            } else
            {
                List<Player> playerList = new List<Player>();
                string playersJson = JsonSerializer.Serialize(playerList);
                try {
                    File.WriteAllText(gameConfig.ToplistPath, playersJson);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "TicTacToe", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            loadPlayersData();
            }
        }

        private void game_Click(object sender, EventArgs e)
        {
            if (GameForm.p1 != null && GameForm.p2 != null)
            {
                loadform(new GameForm());
            }
            else
            {
                MessageBox.Show("You are need to be logged in.", "TicTacToe",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void toplist_Click(object sender, EventArgs e)
        {
            loadform(new ToplistForm());
        }

        private void registraion_Click(object sender, EventArgs e)
        {
            loadform(new RegistrationForm());
        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            loadform(new LoginForm());
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {

        }
    }
}
