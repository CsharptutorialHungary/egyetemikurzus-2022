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
            this.playerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.winsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.losesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.drawDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.toplist)).BeginInit();
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
            // playerBindingSource
            // 
            this.playerBindingSource.DataSource = typeof(tic_tac_toe.Player);
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
            // ToplistForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.toplist);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ToplistForm";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.ToplistForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.toplist)).EndInit();
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
    }
}