namespace CornerShopSecialistDesktop
{
    partial class Shops
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
            this.grdShops = new System.Windows.Forms.DataGridView();
            this.storeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addressLineOne = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addressLineTwo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.postcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdShops)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(463, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "All shops supported by Corner Shop Specialist:";
            // 
            // grdShops
            // 
            this.grdShops.AllowUserToAddRows = false;
            this.grdShops.AllowUserToDeleteRows = false;
            this.grdShops.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdShops.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.storeName,
            this.addressLineOne,
            this.addressLineTwo,
            this.postcode});
            this.grdShops.Location = new System.Drawing.Point(64, 89);
            this.grdShops.Name = "grdShops";
            this.grdShops.ReadOnly = true;
            this.grdShops.Size = new System.Drawing.Size(703, 422);
            this.grdShops.TabIndex = 1;
            // 
            // storeName
            // 
            this.storeName.HeaderText = "Shop Name";
            this.storeName.Name = "storeName";
            this.storeName.ReadOnly = true;
            this.storeName.Width = 150;
            // 
            // addressLineOne
            // 
            this.addressLineOne.HeaderText = "Address Line One";
            this.addressLineOne.Name = "addressLineOne";
            this.addressLineOne.ReadOnly = true;
            this.addressLineOne.Width = 200;
            // 
            // addressLineTwo
            // 
            this.addressLineTwo.HeaderText = "Address Line Two";
            this.addressLineTwo.Name = "addressLineTwo";
            this.addressLineTwo.ReadOnly = true;
            this.addressLineTwo.Width = 200;
            // 
            // postcode
            // 
            this.postcode.HeaderText = "Postcode";
            this.postcode.Name = "postcode";
            this.postcode.ReadOnly = true;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(651, 14);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(97, 50);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // Shops
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 537);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.grdShops);
            this.Controls.Add(this.label1);
            this.Name = "Shops";
            this.Text = "Shops";
            ((System.ComponentModel.ISupportInitialize)(this.grdShops)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView grdShops;
        private System.Windows.Forms.DataGridViewTextBoxColumn storeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn addressLineOne;
        private System.Windows.Forms.DataGridViewTextBoxColumn addressLineTwo;
        private System.Windows.Forms.DataGridViewTextBoxColumn postcode;
        private System.Windows.Forms.Button btnRefresh;
    }
}