namespace CornerShopSecialistDesktop
{
    partial class CreateDelivery
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDeliveryName = new System.Windows.Forms.TextBox();
            this.comStoreName = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpDeliveryDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.comDeliveryType = new System.Windows.Forms.ComboBox();
            this.btnCreateDelivery = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(44, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Create New Delivery";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(201, 158);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Shop:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(171, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Delivery Name:";
            // 
            // txtDeliveryName
            // 
            this.txtDeliveryName.Location = new System.Drawing.Point(333, 111);
            this.txtDeliveryName.Name = "txtDeliveryName";
            this.txtDeliveryName.Size = new System.Drawing.Size(183, 20);
            this.txtDeliveryName.TabIndex = 3;
            // 
            // comStoreName
            // 
            this.comStoreName.FormattingEnabled = true;
            this.comStoreName.Location = new System.Drawing.Point(333, 156);
            this.comStoreName.Name = "comStoreName";
            this.comStoreName.Size = new System.Drawing.Size(152, 21);
            this.comStoreName.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(171, 220);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Delivery Date:";
            // 
            // dtpDeliveryDate
            // 
            this.dtpDeliveryDate.Location = new System.Drawing.Point(333, 219);
            this.dtpDeliveryDate.Name = "dtpDeliveryDate";
            this.dtpDeliveryDate.Size = new System.Drawing.Size(183, 20);
            this.dtpDeliveryDate.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(171, 270);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "Delivery Type:";
            // 
            // comDeliveryType
            // 
            this.comDeliveryType.FormattingEnabled = true;
            this.comDeliveryType.Items.AddRange(new object[] {
            "Frozen",
            "Chilled",
            "Grocery"});
            this.comDeliveryType.Location = new System.Drawing.Point(333, 270);
            this.comDeliveryType.Name = "comDeliveryType";
            this.comDeliveryType.Size = new System.Drawing.Size(152, 21);
            this.comDeliveryType.TabIndex = 8;
            // 
            // btnCreateDelivery
            // 
            this.btnCreateDelivery.Location = new System.Drawing.Point(277, 334);
            this.btnCreateDelivery.Name = "btnCreateDelivery";
            this.btnCreateDelivery.Size = new System.Drawing.Size(113, 23);
            this.btnCreateDelivery.TabIndex = 9;
            this.btnCreateDelivery.Text = "Create Delivery";
            this.btnCreateDelivery.UseVisualStyleBackColor = true;
            this.btnCreateDelivery.Click += new System.EventHandler(this.btnCreateDelivery_Click);
            // 
            // CreateDelivery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCreateDelivery);
            this.Controls.Add(this.comDeliveryType);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtpDeliveryDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comStoreName);
            this.Controls.Add(this.txtDeliveryName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "CreateDelivery";
            this.Text = "Create Delivery";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDeliveryName;
        private System.Windows.Forms.ComboBox comStoreName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpDeliveryDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comDeliveryType;
        private System.Windows.Forms.Button btnCreateDelivery;
    }
}