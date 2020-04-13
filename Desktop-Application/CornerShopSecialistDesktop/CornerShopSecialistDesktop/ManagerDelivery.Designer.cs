namespace CornerShopSecialistDesktop
{
    partial class ManagerDelivery
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
            this.lblDeliveryDate = new System.Windows.Forms.Label();
            this.lblDeliveryType = new System.Windows.Forms.Label();
            this.grdDelivery = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.grdDelivery)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDeliveryDate
            // 
            this.lblDeliveryDate.AutoSize = true;
            this.lblDeliveryDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeliveryDate.Location = new System.Drawing.Point(26, 13);
            this.lblDeliveryDate.Name = "lblDeliveryDate";
            this.lblDeliveryDate.Size = new System.Drawing.Size(153, 25);
            this.lblDeliveryDate.TabIndex = 0;
            this.lblDeliveryDate.Text = "Delivery Date: ";
            // 
            // lblDeliveryType
            // 
            this.lblDeliveryType.AutoSize = true;
            this.lblDeliveryType.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeliveryType.Location = new System.Drawing.Point(340, 13);
            this.lblDeliveryType.Name = "lblDeliveryType";
            this.lblDeliveryType.Size = new System.Drawing.Size(156, 25);
            this.lblDeliveryType.TabIndex = 1;
            this.lblDeliveryType.Text = "Delivery Type: ";
            // 
            // grdDelivery
            // 
            this.grdDelivery.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdDelivery.Location = new System.Drawing.Point(31, 89);
            this.grdDelivery.Name = "grdDelivery";
            this.grdDelivery.Size = new System.Drawing.Size(491, 292);
            this.grdDelivery.TabIndex = 2;
            // 
            // ManagerDelivery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 450);
            this.Controls.Add(this.grdDelivery);
            this.Controls.Add(this.lblDeliveryType);
            this.Controls.Add(this.lblDeliveryDate);
            this.Name = "ManagerDelivery";
            this.Text = "Next Delivery Due In";
            ((System.ComponentModel.ISupportInitialize)(this.grdDelivery)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDeliveryDate;
        private System.Windows.Forms.Label lblDeliveryType;
        private System.Windows.Forms.DataGridView grdDelivery;
    }
}