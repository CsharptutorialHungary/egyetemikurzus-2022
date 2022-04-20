using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tic_tac_toe
{
    public partial class GameForm : Form
    {
        Boolean checker;
        int plusone;
        List<Button> btns;
        List<int[]> winSteps;
        List<int> x_reserved_btns;
        List<int> o_reserved_btns;
        public static string p1_name;
        public static string p2_name;
        public static Player p1;
        public static Player p2;
        public GameForm()
        {
            InitializeComponent();
            InitializeForm();
        }

        private void InitializeForm()
        {
            btns = new List<Button>() { button1, button2, button3, button4, button5, button6, button7, button8, button9 };
            int[] step1 = { 0, 1, 2 };
            int[] step2 = { 3, 4, 5 };
            int[] step3 = { 6, 7, 8 };
            int[] step4 = { 0, 3, 6 };
            int[] step5 = { 1, 4, 7 };
            int[] step6 = { 2, 5, 8 };
            int[] step7 = { 0, 4, 8 };
            int[] step8 = { 2, 4, 6 };
            winSteps = new List<int[]>() { step1, step2, step3, step4, step5, step6, step7, step8 };
            x_reserved_btns = new List<int>();
            o_reserved_btns = new List<int>();
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            p1_label.Text = p1_name;
            p2_label.Text = p2_name;
        }

        private void Buttons_Enable()
        {
            foreach(Button btn in btns)
            {
                btn.Enabled = false;
            }
        }

        private void score()
        {
            bool game_win = false;
            foreach (int[] steps in winSteps)
            {
                var tempx_inters = steps.Intersect(x_reserved_btns);
                var tempy_inters = steps.Intersect(o_reserved_btns);
                if (tempx_inters.Count() == steps.Count())
                {
                    int[] win_step_btns_i = tempx_inters.ToArray();
                    game_end(win_step_btns_i, player_x_score_lbl, "Player X");
                    game_win = true;
                    break;
                }
                if (tempy_inters.Count() == steps.Count())
                {
                    int[] win_step_btns_i = tempy_inters.ToArray();
                    game_end(win_step_btns_i, player_o_score_lbl, "Player O");
                    game_win = true;
                    break;
                }
            }
            if (!game_win && x_reserved_btns.Count + o_reserved_btns.Count == 9)
            {
                draw_game();
            }
        }

        private void game_end(int[] win_btns_i, Label player, string playerName)
        {
            btns[win_btns_i[0]].BackColor = Color.PowderBlue;
            btns[win_btns_i[1]].BackColor = Color.PowderBlue;
            btns[win_btns_i[2]].BackColor = Color.PowderBlue;
            plusone = int.Parse(player.Text) + 1;
            player.Text = Convert.ToString(plusone);
            MessageBox.Show("The winner is " + playerName, "TicTacToe", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Buttons_Enable();
            List<Player> playerList = ToplistForm.loadPlayersData();
            if (p1.Name == playerName)
            {
                p1.Wins++;
                p2.Loses++;
            } else
            {
                p2.Wins++;
                p1.Loses++;
            }
            playerList.Add(p1);
            playerList.Add(p2);
            string playersJson = JsonSerializer.Serialize(playerList);
            File.WriteAllText(@"C:\Users\gabri\Desktop\ISKOLA\6.félév\C#\egyetemikurzus-2022\toplist.json", playersJson);
        }

        private void draw_game()
        {
            MessageBox.Show("The game is draw!", "TicTacToe", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Buttons_Enable();
            List<Player> playerList = ToplistForm.loadPlayersData();
            p1.Draw++;
            p2.Draw++;
            playerList.Add(p1);
            playerList.Add(p2);
            string playersJson = JsonSerializer.Serialize(playerList);
            File.WriteAllText(@"C:\Users\gabri\Desktop\ISKOLA\6.félév\C#\egyetemikurzus-2022\toplist.json", playersJson);


        }

        private void button1_Click(object sender, EventArgs e)
        {
            clicked_table_button(0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clicked_table_button(1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            clicked_table_button(2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            clicked_table_button(3);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            clicked_table_button(4);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            clicked_table_button(5);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            clicked_table_button(6);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            clicked_table_button(7);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            clicked_table_button(8);
        }

        private void clicked_table_button(int btn_i)
        {
            if (checker == false)
            {
                btns[btn_i].Text = "X";
                x_reserved_btns.Add(btn_i);
                checker = true;
            }
            else
            {
                btns[btn_i].Text = "O";
                o_reserved_btns.Add(btn_i);
                checker = false;
            }
            score();
            btns[btn_i].Enabled = false;
        }

        private void p1_label_Click(object sender, EventArgs e)
        {

        }

        private void p2_label_Click(object sender, EventArgs e)
        {

        }

        private void button_reset_Click(object sender, EventArgs e)
        {
            try {
                foreach (Button btn in btns)
                {
                    btn.Enabled = true;
                    btn.Text = "";
                    btn.BackColor = Color.White;
                }
                player_x_score_lbl.Text = "0";
                player_o_score_lbl.Text = "0";
                btn_reset.Enabled = true;
                x_reserved_btns = new List<int>();
                o_reserved_btns = new List<int>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "TicTacToe", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult iExit;
                iExit = MessageBox.Show("Confirm if you want to exit", "TicTacToe",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if(iExit == DialogResult.Yes)
                {
                    Application.Exit();
                }
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "TicTacToe", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_new_game_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Button btn in btns)
                {
                    btn.Enabled = true;
                    btn.Text = "";
                    btn.BackColor = Color.White;
                }
                btn_new_game.Enabled = true;
                x_reserved_btns = new List<int>();
                o_reserved_btns = new List<int>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "TicTacToe", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
