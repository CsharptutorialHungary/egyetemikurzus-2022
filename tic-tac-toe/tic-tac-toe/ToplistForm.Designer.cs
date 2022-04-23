namespace tic_tac_toe
{
    partial class ToplistForm
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
            this.toplist = new System.Windows.Forms.DataGridView();
            this.order_by_wins_btn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.order_by_draw_btn = new System.Windows.Forms.Button();
            this.order_by_loses_btn = new System.Windows.Forms.Button();
            this.order_by_name_btn = new System.Windows.Forms.Button();
            this.user_name_input = new System.Windows.Forms.TextBox();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.winsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.losesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.drawDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.playerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.find_by_user_name_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.toplist)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.playerBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // toplist
            // 
            this.toplist.AutoGenerateColumns = false;
            this.toplist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.toplist.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.winsDataGridViewTextBoxColumn,
            this.losesDataGridViewTextBoxColumn,
            this.drawDataGridViewTextBoxColumn});
            this.toplist.DataSource = this.playerBindingSource;
            this.toplist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toplist.Location = new System.Drawing.Point(0, 0);
            this.toplist.Name = "toplist";
            this.toplist.RowHeadersWidth = 51;
            this.toplist.RowTemplate.Height = 24;
            this.toplist.Size = new System.Drawing.Size(800, 450);
            this.toplist.TabIndex = 0;
            this.toplist.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.toplist_CellContentClick);
            // 
            // order_by_wins_btn
            // 
            this.order_by_wins_btn.Location = new System.Drawing.Point(24, 89);
            this.order_by_wins_btn.Name = "order_by_wins_btn";
            this.order_by_wins_btn.Size = new System.Drawing.Size(157, 55);
            this.order_by_wins_btn.TabIndex = 1;
            this.order_by_wins_btn.Text = "Order by Wins";
            this.order_by_wins_btn.UseVisualStyleBackColor = true;
            this.order_by_wins_btn.Click += new System.EventHandler(this.order_by_wins_btn_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.find_by_user_name_btn);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.user_name_input);
            this.panel1.Controls.Add(this.order_by_draw_btn);
            this.panel1.Controls.Add(this.order_by_loses_btn);
            this.panel1.Controls.Add(this.order_by_name_btn);
            this.panel1.Controls.Add(this.order_by_wins_btn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(600, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 450);
            this.panel1.TabIndex = 2;
            // 
            // order_by_draw_btn
            // 
            this.order_by_draw_btn.Location = new System.Drawing.Point(24, 241);
            this.order_by_draw_btn.Name = "order_by_draw_btn";
            this.order_by_draw_btn.Size = new System.Drawing.Size(157, 55);
            this.order_by_draw_btn.TabIndex = 4;
            this.order_by_draw_btn.Text = "Order by Draw";
            this.order_by_draw_btn.UseVisualStyleBackColor = true;
            this.order_by_draw_btn.Click += new System.EventHandler(this.order_by_draw_btn_Click);
            // 
            // order_by_loses_btn
            // 
            this.order_by_loses_btn.Location = new System.Drawing.Point(24, 164);
            this.order_by_loses_btn.Name = "order_by_loses_btn";
            this.order_by_loses_btn.Size = new System.Drawing.Size(157, 55);
            this.order_by_loses_btn.TabIndex = 3;
            this.order_by_loses_btn.Text = "Order by Loses";
            this.order_by_loses_btn.UseVisualStyleBackColor = true;
            this.order_by_loses_btn.Click += new System.EventHandler(this.order_by_loses_btn_Click);
            // 
            // order_by_name_btn
            // 
            this.order_by_name_btn.Location = new System.Drawing.Point(24, 12);
            this.order_by_name_btn.Name = "order_by_name_btn";
            this.order_by_name_btn.Size = new System.Drawing.Size(157, 55);
            this.order_by_name_btn.TabIndex = 2;
            this.order_by_name_btn.Text = "Order by Name";
            this.order_by_name_btn.UseVisualStyleBackColor = true;
            this.order_by_name_btn.Click += new System.EventHandler(this.order_by_name_btn_Click);
            // 
            // user_name_input
            // 
            this.user_name_input.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.user_name_input.Location = new System.Drawing.Point(3, 331);
            this.user_name_input.MaxLength = 30;
            this.user_name_input.Name = "user_name_input";
            this.user_name_input.Size = new System.Drawing.Size(194, 45);
            this.user_name_input.TabIndex = 5;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            this.nameDataGridViewTextBoxColumn.Width = 125;
            // 
            // winsDataGridViewTextBoxColumn
            // 
            this.winsDataGridViewTextBoxColumn.DataPropertyName = "Wins";
            this.winsDataGridViewTextBoxColumn.HeaderText = "Wins";
            this.winsDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.winsDataGridViewTextBoxColumn.Name = "winsDataGridViewTextBoxColumn";
            this.winsDataGridViewTextBoxColumn.ReadOnly = true;
            this.winsDataGridViewTextBoxColumn.Width = 125;
            // 
            // losesDataGridViewTextBoxColumn
            // 
            this.losesDataGridViewTextBoxColumn.DataPropertyName = "Loses";
            this.losesDataGridViewTextBoxColumn.HeaderText = "Loses";
            this.losesDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.losesDataGridViewTextBoxColumn.Name = "losesDataGridViewTextBoxColumn";
            this.losesDataGridViewTextBoxColumn.ReadOnly = true;
            this.losesDataGridViewTextBoxColumn.Width = 125;
            // 
            // drawDataGridViewTextBoxColumn
            // 
            this.drawDataGridViewTextBoxColumn.DataPropertyName = "Draw";
            this.drawDataGridViewTextBoxColumn.HeaderText = "Draw";
            this.drawDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.drawDataGridViewTextBoxColumn.Name = "drawDataGridViewTextBoxColumn";
            this.drawDataGridViewTextBoxColumn.ReadOnly = true;
            this.drawDataGridViewTextBoxColumn.Width = 125;
            // 
            // playerBindingSource
            // 
            this.playerBindingSource.DataSource = typeof(tic_tac_toe.Player);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 312);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Username";
            // 
            // find_by_user_name_btn
            // 
            this.find_by_user_name_btn.Location = new System.Drawing.Point(24, 383);
            this.find_by_user_name_btn.Name = "find_by_user_name_btn";
            this.find_by_user_name_btn.Size = new System.Drawing.Size(157, 55);
            this.find_by_user_name_btn.TabIndex = 7;
            this.find_by_user_name_btn.Text = "Find";
            this.find_by_user_name_btn.UseVisualStyleBackColor = true;
            this.find_by_user_name_btn.Click += new System.EventHandler(this.find_by_user_name_btn_Click);
            // 
            // ToplistForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toplist);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ToplistForm";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.ToplistForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.toplist)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.playerBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView toplist;
        private System.Windows.Forms.BindingSource playerBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn winsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn losesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn drawDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button order_by_wins_btn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button order_by_name_btn;
        private System.Windows.Forms.Button order_by_draw_btn;
        private System.Windows.Forms.Button order_by_loses_btn;
        private System.Windows.Forms.TextBox user_name_input;
        private System.Windows.Forms.Button find_by_user_name_btn;
        private System.Windows.Forms.Label label1;
    }
}