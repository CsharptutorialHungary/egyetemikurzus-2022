﻿namespace tic_tac_toe
{
    partial class GameForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_new_game = new System.Windows.Forms.Button();
            this.player_o_score_lbl = new System.Windows.Forms.Label();
            this.player_x_score_lbl = new System.Windows.Forms.Label();
            this.p2_label = new System.Windows.Forms.Label();
            this.p1_label = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.p_turn_lb = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel2.Controls.Add(this.p_turn_lb);
            this.panel2.Controls.Add(this.player_o_score_lbl);
            this.panel2.Controls.Add(this.btn_new_game);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.player_x_score_lbl);
            this.panel2.Controls.Add(this.p1_label);
            this.panel2.Controls.Add(this.p2_label);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1084, 507);
            this.panel2.TabIndex = 1;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // btn_new_game
            // 
            this.btn_new_game.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F);
            this.btn_new_game.Location = new System.Drawing.Point(544, 380);
            this.btn_new_game.Name = "btn_new_game";
            this.btn_new_game.Size = new System.Drawing.Size(511, 111);
            this.btn_new_game.TabIndex = 0;
            this.btn_new_game.TabStop = false;
            this.btn_new_game.Text = "New Game";
            this.btn_new_game.UseVisualStyleBackColor = true;
            this.btn_new_game.Click += new System.EventHandler(this.button_new_game_Click);
            // 
            // player_o_score_lbl
            // 
            this.player_o_score_lbl.BackColor = System.Drawing.Color.White;
            this.player_o_score_lbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.player_o_score_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.player_o_score_lbl.Location = new System.Drawing.Point(868, 171);
            this.player_o_score_lbl.Name = "player_o_score_lbl";
            this.player_o_score_lbl.Size = new System.Drawing.Size(149, 58);
            this.player_o_score_lbl.TabIndex = 3;
            this.player_o_score_lbl.Text = "0";
            this.player_o_score_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // player_x_score_lbl
            // 
            this.player_x_score_lbl.BackColor = System.Drawing.Color.White;
            this.player_x_score_lbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.player_x_score_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.player_x_score_lbl.Location = new System.Drawing.Point(868, 81);
            this.player_x_score_lbl.Name = "player_x_score_lbl";
            this.player_x_score_lbl.Size = new System.Drawing.Size(149, 58);
            this.player_x_score_lbl.TabIndex = 2;
            this.player_x_score_lbl.Text = "0";
            this.player_x_score_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.player_x_score_lbl.Click += new System.EventHandler(this.p1_label_Click);
            // 
            // p2_label
            // 
            this.p2_label.AutoSize = true;
            this.p2_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.p2_label.Location = new System.Drawing.Point(553, 181);
            this.p2_label.Name = "p2_label";
            this.p2_label.Size = new System.Drawing.Size(186, 46);
            this.p2_label.TabIndex = 1;
            this.p2_label.Text = "Player O:";
            // 
            // p1_label
            // 
            this.p1_label.AutoSize = true;
            this.p1_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.p1_label.Location = new System.Drawing.Point(553, 91);
            this.p1_label.Name = "p1_label";
            this.p1_label.Size = new System.Drawing.Size(182, 46);
            this.p1_label.TabIndex = 0;
            this.p1_label.Text = "Player X:";
            this.p1_label.Click += new System.EventHandler(this.p2_label_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.button3);
            this.panel3.Controls.Add(this.button9);
            this.panel3.Controls.Add(this.button8);
            this.panel3.Controls.Add(this.button7);
            this.panel3.Controls.Add(this.button6);
            this.panel3.Controls.Add(this.button5);
            this.panel3.Controls.Add(this.button4);
            this.panel3.Controls.Add(this.button2);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Location = new System.Drawing.Point(14, 20);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(504, 480);
            this.panel3.TabIndex = 2;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.White;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.button3.Location = new System.Drawing.Point(333, 9);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(159, 150);
            this.button3.TabIndex = 9;
            this.button3.TabStop = false;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.White;
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.button9.Location = new System.Drawing.Point(333, 311);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(159, 150);
            this.button9.TabIndex = 8;
            this.button9.TabStop = false;
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.White;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.button8.Location = new System.Drawing.Point(173, 311);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(159, 150);
            this.button8.TabIndex = 7;
            this.button8.TabStop = false;
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.White;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.button7.Location = new System.Drawing.Point(13, 311);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(159, 150);
            this.button7.TabIndex = 6;
            this.button7.TabStop = false;
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.White;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.button6.Location = new System.Drawing.Point(333, 160);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(159, 150);
            this.button6.TabIndex = 5;
            this.button6.TabStop = false;
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.White;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.button5.Location = new System.Drawing.Point(173, 160);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(159, 150);
            this.button5.TabIndex = 4;
            this.button5.TabStop = false;
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.White;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.button4.Location = new System.Drawing.Point(13, 160);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(159, 150);
            this.button4.TabIndex = 3;
            this.button4.TabStop = false;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.button2.Location = new System.Drawing.Point(173, 9);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(159, 150);
            this.button2.TabIndex = 1;
            this.button2.TabStop = false;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.button1.Location = new System.Drawing.Point(13, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(159, 150);
            this.button1.TabIndex = 0;
            this.button1.TabStop = false;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // p_turn_lb
            // 
            this.p_turn_lb.AutoSize = true;
            this.p_turn_lb.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.p_turn_lb.Location = new System.Drawing.Point(553, 284);
            this.p_turn_lb.Name = "p_turn_lb";
            this.p_turn_lb.Size = new System.Drawing.Size(0, 46);
            this.p_turn_lb.TabIndex = 4;
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1106, 532);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GameForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.GameForm_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_new_game;
        private System.Windows.Forms.Label p2_label;
        private System.Windows.Forms.Label p1_label;
        private System.Windows.Forms.Label player_x_score_lbl;
        private System.Windows.Forms.Label player_o_score_lbl;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label p_turn_lb;
    }
}

