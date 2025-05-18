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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pictureBoxProduct = new Guna.UI2.WinForms.Guna2PictureBox();
            lblProductName = new Label();
            lblPrice = new Label();
            numericQuantity = new Guna.UI2.WinForms.Guna2NumericUpDown();
            lblSubtotal = new Label();
            btnRemove = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)pictureBoxProduct).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericQuantity).BeginInit();
            SuspendLayout();
            // 
            // pictureBoxProduct
            // 
            pictureBoxProduct.BorderRadius = 10;
            pictureBoxProduct.CustomizableEdges = customizableEdges1;
            pictureBoxProduct.FillColor = Color.FromArgb(224, 224, 224);
            pictureBoxProduct.ImageRotate = 0F;
            pictureBoxProduct.Location = new Point(-1, -1);
            pictureBoxProduct.Name = "pictureBoxProduct";
            pictureBoxProduct.ShadowDecoration.CustomizableEdges = customizableEdges2;
            pictureBoxProduct.Size = new Size(294, 186);
            pictureBoxProduct.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxProduct.TabIndex = 0;
            pictureBoxProduct.TabStop = false;
            // 
            // lblProductName
            // 
            lblProductName.AutoSize = true;
            lblProductName.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblProductName.Location = new Point(44, 199);
            lblProductName.Name = "lblProductName";
            lblProductName.Size = new Size(120, 21);
            lblProductName.TabIndex = 1;
            lblProductName.Text = "Product Name";
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Font = new Font("Segoe UI", 10F);
            lblPrice.Location = new Point(44, 224);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(44, 19);
            lblPrice.TabIndex = 2;
            lblPrice.Text = "$0.00";
            // 
            // numericQuantity
            // 
            numericQuantity.BackColor = Color.Transparent;
            numericQuantity.BorderRadius = 5;
            numericQuantity.CustomizableEdges = customizableEdges3;
            numericQuantity.Font = new Font("Segoe UI", 9F);
            numericQuantity.Location = new Point(44, 247);
            numericQuantity.Name = "numericQuantity";
            numericQuantity.ShadowDecoration.CustomizableEdges = customizableEdges4;
            numericQuantity.Size = new Size(60, 30);
            numericQuantity.TabIndex = 3;
            numericQuantity.ValueChanged += numericQuantity_ValueChanged;
            // 
            // lblSubtotal
            // 
            lblSubtotal.AutoSize = true;
            lblSubtotal.Font = new Font("Segoe UI", 10F);
            lblSubtotal.Location = new Point(114, 252);
            lblSubtotal.Name = "lblSubtotal";
            lblSubtotal.Size = new Size(44, 19);
            lblSubtotal.TabIndex = 4;
            lblSubtotal.Text = "$0.00";
            // 
            // btnRemove
            // 
            btnRemove.AutoRoundedCorners = true;
            btnRemove.BorderRadius = 14;
            btnRemove.CustomizableEdges = customizableEdges5;
            btnRemove.FillColor = Color.FromArgb(255, 85, 85);
            btnRemove.Font = new Font("Segoe UI", 10F);
            btnRemove.ForeColor = Color.White;
            btnRemove.Location = new Point(171, 247);
            btnRemove.Name = "btnRemove";
            btnRemove.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnRemove.Size = new Size(100, 30);
            btnRemove.TabIndex = 5;
            btnRemove.Text = "Remove";
            btnRemove.Click += btnRemove_Click;
            // 
            // CartItemCard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(btnRemove);
            Controls.Add(lblSubtotal);
            Controls.Add(numericQuantity);
            Controls.Add(lblPrice);
            Controls.Add(lblProductName);
            Controls.Add(pictureBoxProduct);
            Name = "CartItemCard";
            Size = new Size(292, 287);
            ((System.ComponentModel.ISupportInitialize)pictureBoxProduct).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericQuantity).EndInit();
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