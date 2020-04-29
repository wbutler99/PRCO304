namespace CornerShopSecialistDesktop
{
    partial class Stock
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
            this.grdStock = new System.Windows.Forms.DataGridView();
            this.stockViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockViewModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // grdStock
            // 
            this.grdStock.AllowUserToDeleteRows = false;
            this.grdStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdStock.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.product,
            this.quantity});
            this.grdStock.Location = new System.Drawing.Point(72, 78);
            this.grdStock.Name = "grdStock";
            this.grdStock.ReadOnly = true;
            this.grdStock.Size = new System.Drawing.Size(253, 258);
            this.grdStock.TabIndex = 0;
            // 
            // stockViewModelBindingSource
            // 
            this.stockViewModelBindingSource.DataSource = typeof(CornerShopSecialistDesktop.Models.StockViewModel);
            // 
            // product
            // 
            this.product.HeaderText = "Product";
            this.product.Name = "product";
            this.product.ReadOnly = true;
            // 
            // quantity
            // 
            this.quantity.HeaderText = "Quantity";
            this.quantity.Name = "quantity";
            this.quantity.ReadOnly = true;
            // 
            // Stock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 669);
            this.Controls.Add(this.grdStock);
            this.Name = "Stock";
            this.Text = "Stock";
            ((System.ComponentModel.ISupportInitialize)(this.grdStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockViewModelBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdStock;
        private System.Windows.Forms.BindingSource stockViewModelBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn product;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantity;
    }
}