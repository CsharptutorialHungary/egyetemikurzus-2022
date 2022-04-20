namespace tic_tac_toe
{
    partial class MenuForm
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
            this.game = new System.Windows.Forms.Button();
            this.toplist = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tb_p2 = new System.Windows.Forms.TextBox();
            this.tb_p1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.mainpanel = new System.Windows.Forms.Panel();
            this.registraion = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // game
            // 
            this.game.Location = new System.Drawing.Point(32, 25);
            this.game.Name = "game";
            this.game.Size = new System.Drawing.Size(111, 56);
            this.game.TabIndex = 1;
            this.game.Text = "Game";
            this.game.UseVisualStyleBackColor = true;
            this.game.Click += new System.EventHandler(this.game_Click);
            // 
            // toplist
            // 
            this.toplist.Location = new System.Drawing.Point(32, 107);
            this.toplist.Name = "toplist";
            this.toplist.Size = new System.Drawing.Size(111, 56);
            this.toplist.TabIndex = 2;
            this.toplist.Text = "Toplist";
            this.toplist.UseVisualStyleBackColor = true;
            this.toplist.Click += new System.EventHandler(this.toplist_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.registraion);
            this.panel1.Controls.Add(this.tb_p2);
            this.panel1.Controls.Add(this.toplist);
            this.panel1.Controls.Add(this.tb_p1);
            this.panel1.Controls.Add(this.game);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(162, 484);
            this.panel1.TabIndex = 3;
            // 
            // tb_p2
            // 
            this.tb_p2.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_p2.Location = new System.Drawing.Point(68, 381);
            this.tb_p2.MaxLength = 11;
            this.tb_p2.Name = "tb_p2";
            this.tb_p2.Size = new System.Drawing.Size(57, 56);
            this.tb_p2.TabIndex = 4;
            this.tb_p2.TextChanged += new System.EventHandler(this.tb_p2_TextChanged);
            // 
            // tb_p1
            // 
            this.tb_p1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_p1.Location = new System.Drawing.Point(68, 278);
            this.tb_p1.MaxLength = 11;
            this.tb_p1.Name = "tb_p1";
            this.tb_p1.Size = new System.Drawing.Size(57, 56);
            this.tb_p1.TabIndex = 3;
            this.tb_p1.TextChanged += new System.EventHandler(this.tb_p1_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 4.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 407);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 9);
            this.label3.TabIndex = 2;
            this.label3.Text = "Player 2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 4.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 303);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 9);
            this.label1.TabIndex = 0;
            this.label1.Text = "Player 1";
            // 
            // mainpanel
            // 
            this.mainpanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainpanel.Location = new System.Drawing.Point(162, 0);
            this.mainpanel.Name = "mainpanel";
            this.mainpanel.Size = new System.Drawing.Size(1087, 484);
            this.mainpanel.TabIndex = 4;
            // 
            // registraion
            // 
            this.registraion.Location = new System.Drawing.Point(32, 193);
            this.registraion.Name = "registraion";
            this.registraion.Size = new System.Drawing.Size(111, 56);
            this.registraion.TabIndex = 5;
            this.registraion.Text = "Registration";
            this.registraion.UseVisualStyleBackColor = true;
            this.registraion.Click += new System.EventHandler(this.registraion_Click);
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1249, 484);
            this.Controls.Add(this.mainpanel);
            this.Controls.Add(this.panel1);
            this.Name = "MenuForm";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button game;
        private System.Windows.Forms.Button toplist;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel mainpanel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_p1;
        private System.Windows.Forms.TextBox tb_p2;
        private System.Windows.Forms.Button registraion;
    }
}