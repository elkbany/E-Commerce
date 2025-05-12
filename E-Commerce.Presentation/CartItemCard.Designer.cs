namespace E_Commerce.Presentation
{
    partial class CartItemCard
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pictureBoxProduct = new Guna.UI2.WinForms.Guna2PictureBox();
            lblProductName = new System.Windows.Forms.Label();
            lblPrice = new System.Windows.Forms.Label();
            numericQuantity = new Guna.UI2.WinForms.Guna2NumericUpDown();
            lblSubtotal = new System.Windows.Forms.Label();
            btnRemove = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(pictureBoxProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(numericQuantity)).BeginInit();
            SuspendLayout();

            // pictureBoxProduct
            pictureBoxProduct.BorderRadius = 10;
            pictureBoxProduct.Location = new System.Drawing.Point(10, 10);
            pictureBoxProduct.Name = "pictureBoxProduct";
            pictureBoxProduct.Size = new System.Drawing.Size(100, 80);
            pictureBoxProduct.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBoxProduct.TabIndex = 0;
            pictureBoxProduct.TabStop = false;

            // lblProductName
            lblProductName.AutoSize = true;
            lblProductName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            lblProductName.Location = new System.Drawing.Point(120, 10);
            lblProductName.Name = "lblProductName";
            lblProductName.Size = new System.Drawing.Size(100, 21);
            lblProductName.TabIndex = 1;
            lblProductName.Text = "Product Name";

            // lblPrice
            lblPrice.AutoSize = true;
            lblPrice.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblPrice.Location = new System.Drawing.Point(120, 35);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new System.Drawing.Size(50, 19);
            lblPrice.TabIndex = 2;
            lblPrice.Text = "$0.00";

            // numericQuantity
            numericQuantity.BorderRadius = 5;
            numericQuantity.Location = new System.Drawing.Point(120, 60);
            numericQuantity.Maximum = 100;
            numericQuantity.Minimum = 0;
            numericQuantity.Name = "numericQuantity";
            numericQuantity.Size = new System.Drawing.Size(60, 30);
            numericQuantity.TabIndex = 3;
            numericQuantity.ValueChanged += numericQuantity_ValueChanged;

            // lblSubtotal
            lblSubtotal.AutoSize = true;
            lblSubtotal.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblSubtotal.Location = new System.Drawing.Point(190, 65);
            lblSubtotal.Name = "lblSubtotal";
            lblSubtotal.Size = new System.Drawing.Size(50, 19);
            lblSubtotal.TabIndex = 4;
            lblSubtotal.Text = "$0.00";

            // btnRemove
            btnRemove.AutoRoundedCorners = true;
            btnRemove.BorderRadius = 15;
            btnRemove.FillColor = System.Drawing.Color.FromArgb(255, 85, 85);
            btnRemove.ForeColor = System.Drawing.Color.White;
            btnRemove.Font = new System.Drawing.Font("Segoe UI", 10F);
            btnRemove.Location = new System.Drawing.Point(250, 60);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new System.Drawing.Size(100, 30);
            btnRemove.TabIndex = 5;
            btnRemove.Text = "Remove";
            btnRemove.Click += btnRemove_Click;

            // CartItemCard
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            Controls.Add(btnRemove);
            Controls.Add(lblSubtotal);
            Controls.Add(numericQuantity);
            Controls.Add(lblPrice);
            Controls.Add(lblProductName);
            Controls.Add(pictureBoxProduct);
            Name = "CartItemCard";
            Size = new System.Drawing.Size(360, 100);
            ((System.ComponentModel.ISupportInitialize)(pictureBoxProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(numericQuantity)).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Guna.UI2.WinForms.Guna2PictureBox pictureBoxProduct;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Label lblPrice;
        private Guna.UI2.WinForms.Guna2NumericUpDown numericQuantity;
        private System.Windows.Forms.Label lblSubtotal;
        private Guna.UI2.WinForms.Guna2Button btnRemove;
    }
}