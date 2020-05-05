namespace CornerShopSecialistDesktop
{
    partial class NewShift
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
            this.label2 = new System.Windows.Forms.Label();
            this.comStaff = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpShiftDate = new System.Windows.Forms.DateTimePicker();
            this.btnNewShift = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(44, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Create A New Shift";
            // 
            // lblShop
            // 
            this.lblShop.AutoSize = true;
            this.lblShop.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShop.Location = new System.Drawing.Point(265, 25);
            this.lblShop.Name = "lblShop";
            this.lblShop.Size = new System.Drawing.Size(0, 25);
            this.lblShop.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(177, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Staff Member:";
            // 
            // comStaff
            // 
            this.comStaff.FormattingEnabled = true;
            this.comStaff.Location = new System.Drawing.Point(315, 129);
            this.comStaff.Name = "comStaff";
            this.comStaff.Size = new System.Drawing.Size(121, 21);
            this.comStaff.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(177, 179);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Date of Shift:";
            // 
            // dtpShiftDate
            // 
            this.dtpShiftDate.Location = new System.Drawing.Point(315, 179);
            this.dtpShiftDate.Name = "dtpShiftDate";
            this.dtpShiftDate.Size = new System.Drawing.Size(148, 20);
            this.dtpShiftDate.TabIndex = 5;
            // 
            // btnNewShift
            // 
            this.btnNewShift.Location = new System.Drawing.Point(270, 244);
            this.btnNewShift.Name = "btnNewShift";
            this.btnNewShift.Size = new System.Drawing.Size(111, 23);
            this.btnNewShift.TabIndex = 6;
            this.btnNewShift.Text = "Add New Shift";
            this.btnNewShift.UseVisualStyleBackColor = true;
            this.btnNewShift.Click += new System.EventHandler(this.btnNewShift_Click);
            // 
            // NewShift
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnNewShift);
            this.Controls.Add(this.dtpShiftDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comStaff);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblShop);
            this.Controls.Add(this.label1);
            this.Name = "NewShift";
            this.Text = "New Shift";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblShop;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comStaff;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpShiftDate;
        private System.Windows.Forms.Button btnNewShift;
    }
}