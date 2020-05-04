namespace CornerShopSecialistDesktop
{
    partial class Holiday
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
            this.btnApproveHoliday = new System.Windows.Forms.Button();
            this.grdHolidays = new System.Windows.Forms.DataGridView();
            this.holidayReference = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.endDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reason = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdHolidays)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(274, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Holiday Requests for Shop:";
            // 
            // lblShop
            // 
            this.lblShop.AutoSize = true;
            this.lblShop.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShop.Location = new System.Drawing.Point(307, 27);
            this.lblShop.Name = "lblShop";
            this.lblShop.Size = new System.Drawing.Size(62, 25);
            this.lblShop.TabIndex = 1;
            this.lblShop.Text = "Shop";
            // 
            // btnApproveHoliday
            // 
            this.btnApproveHoliday.Location = new System.Drawing.Point(32, 68);
            this.btnApproveHoliday.Name = "btnApproveHoliday";
            this.btnApproveHoliday.Size = new System.Drawing.Size(126, 40);
            this.btnApproveHoliday.TabIndex = 2;
            this.btnApproveHoliday.Text = "Approve/Deny Holiday Requests";
            this.btnApproveHoliday.UseVisualStyleBackColor = true;
            this.btnApproveHoliday.Click += new System.EventHandler(this.btnApproveHoliday_Click);
            // 
            // grdHolidays
            // 
            this.grdHolidays.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdHolidays.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.holidayReference,
            this.username,
            this.startDate,
            this.endDate,
            this.reason,
            this.status});
            this.grdHolidays.Location = new System.Drawing.Point(12, 137);
            this.grdHolidays.Name = "grdHolidays";
            this.grdHolidays.Size = new System.Drawing.Size(1146, 150);
            this.grdHolidays.TabIndex = 3;
            // 
            // holidayReference
            // 
            this.holidayReference.HeaderText = "Reference";
            this.holidayReference.Name = "holidayReference";
            this.holidayReference.ReadOnly = true;
            this.holidayReference.Width = 150;
            // 
            // username
            // 
            this.username.HeaderText = "Username";
            this.username.Name = "username";
            this.username.ReadOnly = true;
            this.username.Width = 150;
            // 
            // startDate
            // 
            this.startDate.HeaderText = "Start Date of Holiday";
            this.startDate.Name = "startDate";
            this.startDate.ReadOnly = true;
            this.startDate.Width = 200;
            // 
            // endDate
            // 
            this.endDate.HeaderText = "End Date of Holiday";
            this.endDate.Name = "endDate";
            this.endDate.ReadOnly = true;
            this.endDate.Width = 200;
            // 
            // reason
            // 
            this.reason.HeaderText = "Reason For Holiday";
            this.reason.Name = "reason";
            this.reason.ReadOnly = true;
            this.reason.Width = 300;
            // 
            // status
            // 
            this.status.HeaderText = "Status of Request";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(436, 21);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 40);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // Holiday
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1258, 515);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.grdHolidays);
            this.Controls.Add(this.btnApproveHoliday);
            this.Controls.Add(this.lblShop);
            this.Controls.Add(this.label1);
            this.Name = "Holiday";
            this.Text = "Holiday";
            ((System.ComponentModel.ISupportInitialize)(this.grdHolidays)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblShop;
        private System.Windows.Forms.Button btnApproveHoliday;
        private System.Windows.Forms.DataGridView grdHolidays;
        private System.Windows.Forms.DataGridViewTextBoxColumn holidayReference;
        private System.Windows.Forms.DataGridViewTextBoxColumn username;
        private System.Windows.Forms.DataGridViewTextBoxColumn startDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn endDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn reason;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.Button btnRefresh;
    }
}