namespace CornerShopSecialistDesktop
{
    partial class ManagerHome
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
            this.btnStock = new System.Windows.Forms.Button();
            this.btnDeliveries = new System.Windows.Forms.Button();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.btnNewStaff = new System.Windows.Forms.Button();
            this.btnReservations = new System.Windows.Forms.Button();
            this.btnShifts = new System.Windows.Forms.Button();
            this.btnHolidays = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnStock
            // 
            this.btnStock.Location = new System.Drawing.Point(101, 59);
            this.btnStock.Name = "btnStock";
            this.btnStock.Size = new System.Drawing.Size(88, 76);
            this.btnStock.TabIndex = 0;
            this.btnStock.Text = "Stock";
            this.btnStock.UseVisualStyleBackColor = true;
            this.btnStock.Click += new System.EventHandler(this.btnStock_Click);
            // 
            // btnDeliveries
            // 
            this.btnDeliveries.Location = new System.Drawing.Point(195, 59);
            this.btnDeliveries.Name = "btnDeliveries";
            this.btnDeliveries.Size = new System.Drawing.Size(94, 76);
            this.btnDeliveries.TabIndex = 1;
            this.btnDeliveries.Text = "Deliveries";
            this.btnDeliveries.UseVisualStyleBackColor = true;
            this.btnDeliveries.Click += new System.EventHandler(this.btnDeliveries_Click);
            // 
            // btnLogOut
            // 
            this.btnLogOut.ForeColor = System.Drawing.Color.Black;
            this.btnLogOut.Location = new System.Drawing.Point(205, 286);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(75, 23);
            this.btnLogOut.TabIndex = 2;
            this.btnLogOut.Text = "Log Out";
            this.btnLogOut.UseVisualStyleBackColor = true;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // btnNewStaff
            // 
            this.btnNewStaff.Location = new System.Drawing.Point(195, 141);
            this.btnNewStaff.Name = "btnNewStaff";
            this.btnNewStaff.Size = new System.Drawing.Size(94, 77);
            this.btnNewStaff.TabIndex = 3;
            this.btnNewStaff.Text = "New Staff Member";
            this.btnNewStaff.UseVisualStyleBackColor = true;
            this.btnNewStaff.Click += new System.EventHandler(this.btnNewStaff_Click);
            // 
            // btnReservations
            // 
            this.btnReservations.Location = new System.Drawing.Point(101, 141);
            this.btnReservations.Name = "btnReservations";
            this.btnReservations.Size = new System.Drawing.Size(88, 77);
            this.btnReservations.TabIndex = 4;
            this.btnReservations.Text = "Reservations";
            this.btnReservations.UseVisualStyleBackColor = true;
            this.btnReservations.Click += new System.EventHandler(this.btnReservations_Click);
            // 
            // btnShifts
            // 
            this.btnShifts.Location = new System.Drawing.Point(296, 59);
            this.btnShifts.Name = "btnShifts";
            this.btnShifts.Size = new System.Drawing.Size(93, 76);
            this.btnShifts.TabIndex = 5;
            this.btnShifts.Text = "Shifts";
            this.btnShifts.UseVisualStyleBackColor = true;
            this.btnShifts.Click += new System.EventHandler(this.btnShifts_Click);
            // 
            // btnHolidays
            // 
            this.btnHolidays.Location = new System.Drawing.Point(296, 142);
            this.btnHolidays.Name = "btnHolidays";
            this.btnHolidays.Size = new System.Drawing.Size(93, 76);
            this.btnHolidays.TabIndex = 6;
            this.btnHolidays.Text = "Holidays";
            this.btnHolidays.UseVisualStyleBackColor = true;
            this.btnHolidays.Click += new System.EventHandler(this.btnHolidays_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(303, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "Select the service you require:";
            // 
            // ManagerHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 379);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnHolidays);
            this.Controls.Add(this.btnShifts);
            this.Controls.Add(this.btnReservations);
            this.Controls.Add(this.btnNewStaff);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.btnDeliveries);
            this.Controls.Add(this.btnStock);
            this.Name = "ManagerHome";
            this.Text = "Manager Home";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStock;
        private System.Windows.Forms.Button btnDeliveries;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Button btnNewStaff;
        private System.Windows.Forms.Button btnReservations;
        private System.Windows.Forms.Button btnShifts;
        private System.Windows.Forms.Button btnHolidays;
        private System.Windows.Forms.Label label1;
    }
}