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
            this.login_btn = new System.Windows.Forms.Button();
            this.registraion = new System.Windows.Forms.Button();
            this.mainpanel = new System.Windows.Forms.Panel();
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
            this.panel1.Controls.Add(this.login_btn);
            this.panel1.Controls.Add(this.registraion);
            this.panel1.Controls.Add(this.toplist);
            this.panel1.Controls.Add(this.game);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(162, 529);
            this.panel1.TabIndex = 3;
            // 
            // login_btn
            // 
            this.login_btn.Location = new System.Drawing.Point(32, 274);
            this.login_btn.Name = "login_btn";
            this.login_btn.Size = new System.Drawing.Size(111, 56);
            this.login_btn.TabIndex = 6;
            this.login_btn.Text = "Login";
            this.login_btn.UseVisualStyleBackColor = true;
            this.login_btn.Click += new System.EventHandler(this.login_btn_Click);
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
            // mainpanel
            // 
            this.mainpanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainpanel.Location = new System.Drawing.Point(162, 0);
            this.mainpanel.Name = "mainpanel";
            this.mainpanel.Size = new System.Drawing.Size(1087, 529);
            this.mainpanel.TabIndex = 4;
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1249, 529);
            this.Controls.Add(this.mainpanel);
            this.Controls.Add(this.panel1);
            this.Name = "MenuForm";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button game;
        private System.Windows.Forms.Button toplist;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel mainpanel;
        private System.Windows.Forms.Button registraion;
        private System.Windows.Forms.Button login_btn;
    }
}