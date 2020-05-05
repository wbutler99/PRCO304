namespace CornerShopSecialistDesktop
{
    partial class Shifts
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblShop = new System.Windows.Forms.Label();
            this.grdShifts = new System.Windows.Forms.DataGridView();
            this.username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnNewShift = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdShifts)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(64, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Shifts for Shop:";
            // 
            // lblShop
            // 
            this.lblShop.AutoSize = true;
            this.lblShop.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShop.Location = new System.Drawing.Point(226, 33);
            this.lblShop.Name = "lblShop";
            this.lblShop.Size = new System.Drawing.Size(62, 25);
            this.lblShop.TabIndex = 1;
            this.lblShop.Text = "Shop";
            // 
            // grdShifts
            // 
            this.grdShifts.AllowUserToAddRows = false;
            this.grdShifts.AllowUserToDeleteRows = false;
            this.grdShifts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdShifts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.username,
            this.date});
            this.grdShifts.Location = new System.Drawing.Point(134, 130);
            this.grdShifts.Name = "grdShifts";
            this.grdShifts.ReadOnly = true;
            this.grdShifts.Size = new System.Drawing.Size(394, 150);
            this.grdShifts.TabIndex = 2;
            // 
            // username
            // 
            this.username.HeaderText = "Staff Username";
            this.username.Name = "username";
            this.username.ReadOnly = true;
            this.username.Width = 200;
            // 
            // date
            // 
            this.date.HeaderText = "Date of Shift";
            this.date.Name = "date";
            this.date.ReadOnly = true;
            this.date.Width = 150;
            // 
            // btnNewShift
            // 
            this.btnNewShift.Location = new System.Drawing.Point(101, 80);
            this.btnNewShift.Name = "btnNewShift";
            this.btnNewShift.Size = new System.Drawing.Size(101, 23);
            this.btnNewShift.TabIndex = 3;
            this.btnNewShift.Text = "Add New Shift";
            this.btnNewShift.UseVisualStyleBackColor = true;
            this.btnNewShift.Click += new System.EventHandler(this.btnNewShift_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(21, 130);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(91, 64);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // Shifts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnNewShift);
            this.Controls.Add(this.grdShifts);
            this.Controls.Add(this.lblShop);
            this.Controls.Add(this.label1);
            this.Name = "Shifts";
            this.Text = "Shifts";
            ((System.ComponentModel.ISupportInitialize)(this.grdShifts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblShop;
        private System.Windows.Forms.DataGridView grdShifts;
        private System.Windows.Forms.DataGridViewTextBoxColumn username;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.Button btnNewShift;
        private System.Windows.Forms.Button btnRefresh;
    }
}