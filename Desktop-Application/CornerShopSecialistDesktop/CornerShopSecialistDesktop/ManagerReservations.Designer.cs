namespace CornerShopSecialistDesktop
{
    partial class ManagerReservations
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
            this.grdReservation = new System.Windows.Forms.DataGridView();
            this.customerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblShop = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdReservation)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(43, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Reservations for Shop: ";
            // 
            // grdReservation
            // 
            this.grdReservation.AllowUserToDeleteRows = false;
            this.grdReservation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdReservation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.customerName,
            this.productName});
            this.grdReservation.Location = new System.Drawing.Point(117, 124);
            this.grdReservation.Name = "grdReservation";
            this.grdReservation.ReadOnly = true;
            this.grdReservation.Size = new System.Drawing.Size(543, 150);
            this.grdReservation.TabIndex = 1;
            // 
            // customerName
            // 
            this.customerName.HeaderText = "Customer Name";
            this.customerName.Name = "customerName";
            this.customerName.ReadOnly = true;
            this.customerName.Width = 300;
            // 
            // productName
            // 
            this.productName.HeaderText = "Product Name";
            this.productName.Name = "productName";
            this.productName.ReadOnly = true;
            this.productName.Width = 200;
            // 
            // lblShop
            // 
            this.lblShop.AutoSize = true;
            this.lblShop.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShop.Location = new System.Drawing.Point(286, 28);
            this.lblShop.Name = "lblShop";
            this.lblShop.Size = new System.Drawing.Size(62, 25);
            this.lblShop.TabIndex = 2;
            this.lblShop.Text = "Shop";
            // 
            // ManagerReservations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblShop);
            this.Controls.Add(this.grdReservation);
            this.Controls.Add(this.label1);
            this.Name = "ManagerReservations";
            this.Text = "ManagerReservations";
            ((System.ComponentModel.ISupportInitialize)(this.grdReservation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView grdReservation;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn productName;
        private System.Windows.Forms.Label lblShop;
    }
}