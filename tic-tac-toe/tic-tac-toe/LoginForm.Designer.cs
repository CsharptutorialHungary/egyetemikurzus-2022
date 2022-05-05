namespace tic_tac_toe
{
    partial class LoginForm
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
            this.login_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_p1_username = new System.Windows.Forms.TextBox();
            this.tb_p1_password = new System.Windows.Forms.TextBox();
            this.tb_p2_password = new System.Windows.Forms.TextBox();
            this.tb_p2_username = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // login_btn
            // 
            this.login_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.login_btn.Location = new System.Drawing.Point(282, 335);
            this.login_btn.Name = "login_btn";
            this.login_btn.Size = new System.Drawing.Size(191, 72);
            this.login_btn.TabIndex = 0;
            this.login_btn.Text = "Login";
            this.login_btn.UseVisualStyleBackColor = true;
            this.login_btn.Click += new System.EventHandler(this.login_btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(111, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Player1 Username:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(111, 207);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Player1 Password:";
            // 
            // tb_p1_username
            // 
            this.tb_p1_username.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.tb_p1_username.Location = new System.Drawing.Point(115, 130);
            this.tb_p1_username.Name = "tb_p1_username";
            this.tb_p1_username.Size = new System.Drawing.Size(209, 55);
            this.tb_p1_username.TabIndex = 3;
            // 
            // tb_p1_password
            // 
            this.tb_p1_password.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.tb_p1_password.Location = new System.Drawing.Point(115, 230);
            this.tb_p1_password.Name = "tb_p1_password";
            this.tb_p1_password.Size = new System.Drawing.Size(209, 55);
            this.tb_p1_password.TabIndex = 4;
            // 
            // tb_p2_password
            // 
            this.tb_p2_password.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.tb_p2_password.Location = new System.Drawing.Point(425, 230);
            this.tb_p2_password.Name = "tb_p2_password";
            this.tb_p2_password.Size = new System.Drawing.Size(209, 55);
            this.tb_p2_password.TabIndex = 8;
            // 
            // tb_p2_username
            // 
            this.tb_p2_username.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.tb_p2_username.Location = new System.Drawing.Point(425, 130);
            this.tb_p2_username.Name = "tb_p2_username";
            this.tb_p2_username.Size = new System.Drawing.Size(209, 55);
            this.tb_p2_username.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(421, 207);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Player2 Password:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(421, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(152, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Player2 Username:";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tb_p2_password);
            this.Controls.Add(this.tb_p2_username);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb_p1_password);
            this.Controls.Add(this.tb_p1_username);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.login_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoginForm";
            this.Text = "LoginForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button login_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_p1_username;
        private System.Windows.Forms.TextBox tb_p1_password;
        private System.Windows.Forms.TextBox tb_p2_password;
        private System.Windows.Forms.TextBox tb_p2_username;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}