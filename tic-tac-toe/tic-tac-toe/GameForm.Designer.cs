namespace tic_tac_toe
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
            this.panel4 = new System.Windows.Forms.Panel();
            this.btn_reset = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.btn_new_game = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.player_o_score_lbl = new System.Windows.Forms.Label();
            this.player_x_score_lbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
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
            this.go_to_menu_btn = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(22, 133);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1177, 512);
            this.panel2.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Location = new System.Drawing.Point(612, 20);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(553, 480);
            this.panel4.TabIndex = 3;
            // 
            // btn_reset
            // 
            this.btn_reset.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F);
            this.btn_reset.Location = new System.Drawing.Point(3, 120);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(240, 124);
            this.btn_reset.TabIndex = 2;
            this.btn_reset.Text = "Reset";
            this.btn_reset.UseVisualStyleBackColor = true;
            this.btn_reset.Click += new System.EventHandler(this.button_reset_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F);
            this.btn_exit.Location = new System.Drawing.Point(249, 120);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(265, 124);
            this.btn_exit.TabIndex = 1;
            this.btn_exit.Text = "Exit";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.button_exit_Click);
            // 
            // btn_new_game
            // 
            this.btn_new_game.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F);
            this.btn_new_game.Location = new System.Drawing.Point(3, 3);
            this.btn_new_game.Name = "btn_new_game";
            this.btn_new_game.Size = new System.Drawing.Size(511, 111);
            this.btn_new_game.TabIndex = 0;
            this.btn_new_game.Text = "New Game";
            this.btn_new_game.UseVisualStyleBackColor = true;
            this.btn_new_game.Click += new System.EventHandler(this.button_new_game_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.player_o_score_lbl);
            this.panel5.Controls.Add(this.player_x_score_lbl);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Location = new System.Drawing.Point(20, 14);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(517, 207);
            this.panel5.TabIndex = 4;
            // 
            // player_o_score_lbl
            // 
            this.player_o_score_lbl.BackColor = System.Drawing.Color.White;
            this.player_o_score_lbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.player_o_score_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.player_o_score_lbl.Location = new System.Drawing.Point(253, 108);
            this.player_o_score_lbl.Name = "player_o_score_lbl";
            this.player_o_score_lbl.Size = new System.Drawing.Size(230, 58);
            this.player_o_score_lbl.TabIndex = 3;
            this.player_o_score_lbl.Text = "0";
            this.player_o_score_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // player_x_score_lbl
            // 
            this.player_x_score_lbl.BackColor = System.Drawing.Color.White;
            this.player_x_score_lbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.player_x_score_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.player_x_score_lbl.Location = new System.Drawing.Point(253, 18);
            this.player_x_score_lbl.Name = "player_x_score_lbl";
            this.player_x_score_lbl.Size = new System.Drawing.Size(230, 58);
            this.player_x_score_lbl.TabIndex = 2;
            this.player_x_score_lbl.Text = "0";
            this.player_x_score_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.player_x_score_lbl.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.label2.Location = new System.Drawing.Point(13, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(233, 58);
            this.label2.TabIndex = 1;
            this.label2.Text = "Player O:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.label1.Location = new System.Drawing.Point(20, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 58);
            this.label1.TabIndex = 0;
            this.label1.Text = "Player X:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.White;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.button3.Location = new System.Drawing.Point(397, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(191, 153);
            this.button3.TabIndex = 9;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.White;
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.button9.Location = new System.Drawing.Point(397, 321);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(191, 153);
            this.button9.TabIndex = 8;
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.White;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.button8.Location = new System.Drawing.Point(200, 321);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(191, 153);
            this.button8.TabIndex = 7;
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.White;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.button7.Location = new System.Drawing.Point(3, 321);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(191, 153);
            this.button7.TabIndex = 6;
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.White;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.button6.Location = new System.Drawing.Point(397, 162);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(191, 153);
            this.button6.TabIndex = 5;
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.White;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.button5.Location = new System.Drawing.Point(200, 162);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(191, 153);
            this.button5.TabIndex = 4;
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.White;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.button4.Location = new System.Drawing.Point(3, 162);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(191, 153);
            this.button4.TabIndex = 3;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.button2.Location = new System.Drawing.Point(200, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(191, 153);
            this.button2.TabIndex = 1;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(191, 153);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // go_to_menu_btn
            // 
            this.go_to_menu_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.go_to_menu_btn.Location = new System.Drawing.Point(18, 3);
            this.go_to_menu_btn.Name = "go_to_menu_btn";
            this.go_to_menu_btn.Size = new System.Drawing.Size(224, 91);
            this.go_to_menu_btn.TabIndex = 0;
            this.go_to_menu_btn.Text = "Go to menu";
            this.go_to_menu_btn.UseVisualStyleBackColor = true;
            this.go_to_menu_btn.Click += new System.EventHandler(this.go_to_menu_btn_Click);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btn_reset);
            this.panel6.Controls.Add(this.btn_exit);
            this.panel6.Controls.Add(this.btn_new_game);
            this.panel6.Location = new System.Drawing.Point(20, 227);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(517, 247);
            this.panel6.TabIndex = 5;
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
            this.panel3.Location = new System.Drawing.Point(15, 20);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(591, 480);
            this.panel3.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.go_to_menu_btn);
            this.panel1.Location = new System.Drawing.Point(22, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1177, 97);
            this.panel1.TabIndex = 0;
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(1219, 655);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "GameForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_reset;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Button btn_new_game;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label player_x_score_lbl;
        private System.Windows.Forms.Label player_o_score_lbl;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button go_to_menu_btn;
        private System.Windows.Forms.Panel panel1;
    }
}

