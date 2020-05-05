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
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnShops
            // 
            this.btnShops.Location = new System.Drawing.Point(95, 61);
            this.btnShops.Name = "btnShops";
            this.btnShops.Size = new System.Drawing.Size(92, 69);
            this.btnShops.TabIndex = 0;
            this.btnShops.Text = "Shops";
            this.btnShops.UseVisualStyleBackColor = true;
            this.btnShops.Click += new System.EventHandler(this.btnShops_Click);
            // 
            // btnNewDelivery
            // 
            this.btnNewDelivery.Location = new System.Drawing.Point(193, 61);
            this.btnNewDelivery.Name = "btnNewDelivery";
            this.btnNewDelivery.Size = new System.Drawing.Size(102, 69);
            this.btnNewDelivery.TabIndex = 1;
            this.btnNewDelivery.Text = "New Delivery";
            this.btnNewDelivery.UseVisualStyleBackColor = true;
            this.btnNewDelivery.Click += new System.EventHandler(this.btnNewDelivery_Click);
            // 
            // btnLogOut
            // 
            this.btnLogOut.Location = new System.Drawing.Point(153, 255);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(75, 23);
            this.btnLogOut.TabIndex = 2;
            this.btnLogOut.Text = "Log Out";
            this.btnLogOut.UseVisualStyleBackColor = true;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // btnNewManager
            // 
            this.btnNewManager.Location = new System.Drawing.Point(131, 145);
            this.btnNewManager.Name = "btnNewManager";
            this.btnNewManager.Size = new System.Drawing.Size(121, 81);
            this.btnNewManager.TabIndex = 3;
            this.btnNewManager.Text = "New Staff Member";
            this.btnNewManager.UseVisualStyleBackColor = true;
            this.btnNewManager.Click += new System.EventHandler(this.btnNewManager_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(303, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Select the service you require:";
            // 
            // AdminHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 315);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnNewManager);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.btnNewDelivery);
            this.Controls.Add(this.btnShops);
            this.Name = "AdminHome";
            this.Text = "Admin Home";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnShops;
        private System.Windows.Forms.Button btnNewDelivery;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Button btnNewManager;
        private System.Windows.Forms.Label label1;
    }
}