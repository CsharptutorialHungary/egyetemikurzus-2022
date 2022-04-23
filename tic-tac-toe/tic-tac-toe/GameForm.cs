﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tic_tac_toe
{
    public partial class GameForm : Form
    {
        Boolean checker;
        Boolean defChecker = true;
        int plusone;
        List<Button> btns;
        List<int> x_reserved_btns;
        List<int> o_reserved_btns;
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
            x_reserved_btns = new List<int>();
            o_reserved_btns = new List<int>();
            p_turn_lb.Text = "It's " + p1.Name + "'s turn.";
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            p1_label.Text = p1.Name + ": X";
            p2_label.Text = p2.Name + ": O";
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
            foreach (int[] steps in MenuForm.gameConfig.WinSteps)
            {
                var tempx_inters = steps.Intersect(x_reserved_btns);
                var tempy_inters = steps.Intersect(o_reserved_btns);
                if (tempx_inters.Count() == steps.Count())
                {
                    int[] win_step_btns_i = tempx_inters.ToArray();
                    game_end(win_step_btns_i, player_x_score_lbl, p1.Name);
                    game_win = true;
                    break;
                }
                if (tempy_inters.Count() == steps.Count())
                {
                    int[] win_step_btns_i = tempy_inters.ToArray();
                    game_end(win_step_btns_i, player_o_score_lbl, p2.Name);
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
            Player tempP1 = MenuForm.players.Find(p => { return p.Name == p1.Name;  });
            Player tempP2 = MenuForm.players.Find(p => p.Name == p2.Name);
            Console.WriteLine(p1.Name);
            if (p1.Name == playerName)
            {
                tempP1.Wins++;
                tempP2.Loses++;
            } else
            {
                tempP2.Wins++;
                tempP1.Loses++;
            }
            string playersJson = JsonSerializer.Serialize(MenuForm.players);
            File.WriteAllText(MenuForm.gameConfig.ToplistPath, playersJson);
        }

        private void draw_game()
        {
            MessageBox.Show("The game is draw!", "TicTacToe", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Buttons_Enable();
            MenuForm.players.Find(p => p.Name == p1.Name).Draw++;
            MenuForm.players.Find(p => p.Name == p2.Name).Draw++;
            string playersJson = JsonSerializer.Serialize(MenuForm.players);
            File.WriteAllText(MenuForm.gameConfig.ToplistPath, playersJson);
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
                p_turn_lb.Text = "It's " + p2.Name + "'s turn.";
            }
            else
            {
                btns[btn_i].Text = "O";
                o_reserved_btns.Add(btn_i);
                checker = false;
                p_turn_lb.Text = "It's " + p1.Name + "'s turn.";
            }
            btns[btn_i].Enabled = false;
            score();
        }

        private void p1_label_Click(object sender, EventArgs e)
        {

        }

        private void p2_label_Click(object sender, EventArgs e)
        {

        }

        private void button_new_game_Click(object sender, EventArgs e)
        {
            try
            {
                checker = !defChecker;
                defChecker = !defChecker;
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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
