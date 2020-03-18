namespace CornerShopSecialistDesktop
{
    partial class AdminHome
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
            this.btnShops = new System.Windows.Forms.Button();
            this.btnNewDelivery = new System.Windows.Forms.Button();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.btnNewManager = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnShops
            // 
            this.btnShops.Location = new System.Drawing.Point(78, 61);
            this.btnShops.Name = "btnShops";
            this.btnShops.Size = new System.Drawing.Size(75, 23);
            this.btnShops.TabIndex = 0;
            this.btnShops.Text = "Shops";
            this.btnShops.UseVisualStyleBackColor = true;
            // 
            // btnNewDelivery
            // 
            this.btnNewDelivery.Location = new System.Drawing.Point(238, 60);
            this.btnNewDelivery.Name = "btnNewDelivery";
            this.btnNewDelivery.Size = new System.Drawing.Size(108, 23);
            this.btnNewDelivery.TabIndex = 1;
            this.btnNewDelivery.Text = "New Delivery";
            this.btnNewDelivery.UseVisualStyleBackColor = true;
            // 
            // btnLogOut
            // 
            this.btnLogOut.Location = new System.Drawing.Point(337, 401);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(75, 23);
            this.btnLogOut.TabIndex = 2;
            this.btnLogOut.Text = "Log Out";
            this.btnLogOut.UseVisualStyleBackColor = true;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // btnNewManager
            // 
            this.btnNewManager.Location = new System.Drawing.Point(423, 61);
            this.btnNewManager.Name = "btnNewManager";
            this.btnNewManager.Size = new System.Drawing.Size(121, 23);
            this.btnNewManager.TabIndex = 3;
            this.btnNewManager.Text = "New Staff Member";
            this.btnNewManager.UseVisualStyleBackColor = true;
            this.btnNewManager.Click += new System.EventHandler(this.btnNewManager_Click);
            // 
            // AdminHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnNewManager);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.btnNewDelivery);
            this.Controls.Add(this.btnShops);
            this.Name = "AdminHome";
            this.Text = "Admin Home";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnShops;
        private System.Windows.Forms.Button btnNewDelivery;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Button btnNewManager;
    }
}