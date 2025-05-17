namespace E_Commerce.Presentation
{
    partial class ProductCard
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
            lblProductName = new Label();
            lblPrice = new Label();
            lblCategory = new Label();
            btnAddToCart = new Guna.UI2.WinForms.Guna2Button();
            guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lblProductName
            // 
            lblProductName.AutoSize = true;
            lblProductName.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblProductName.Location = new Point(51, 174);
            lblProductName.Name = "lblProductName";
            lblProductName.Size = new Size(120, 21);
            lblProductName.TabIndex = 1;
            lblProductName.Text = "Product Name";
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Font = new Font("Segoe UI", 10F);
            lblPrice.Location = new Point(51, 199);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(44, 19);
            lblPrice.TabIndex = 2;
            lblPrice.Text = "$0.00";
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Font = new Font("Segoe UI", 9F);
            lblCategory.ForeColor = Color.Gray;
            lblCategory.Location = new Point(51, 219);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(55, 15);
            lblCategory.TabIndex = 3;
            lblCategory.Text = "Category";
            // 
            // btnAddToCart
            // 
            btnAddToCart.AutoRoundedCorners = true;
            btnAddToCart.BorderRadius = 16;
            btnAddToCart.CustomizableEdges = customizableEdges1;
            btnAddToCart.FillColor = Color.FromArgb(0, 120, 212);
            btnAddToCart.Font = new Font("Segoe UI", 10F);
            btnAddToCart.ForeColor = Color.White;
            btnAddToCart.Location = new Point(51, 240);
            btnAddToCart.Name = "btnAddToCart";
            btnAddToCart.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnAddToCart.Size = new Size(200, 35);
            btnAddToCart.TabIndex = 4;
            btnAddToCart.Text = "Add to Cart";
            btnAddToCart.Click += btnAddToCart_Click;
            // 
            // guna2PictureBox1
            // 
            guna2PictureBox1.CustomizableEdges = customizableEdges3;
            guna2PictureBox1.FillColor = Color.FromArgb(224, 224, 224);
            guna2PictureBox1.ImageRotate = 0F;
            guna2PictureBox1.Location = new Point(-1, -1);
            guna2PictureBox1.Name = "guna2PictureBox1";
            guna2PictureBox1.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2PictureBox1.Size = new Size(294, 158);
            guna2PictureBox1.TabIndex = 5;
            guna2PictureBox1.TabStop = false;
            // 
            // ProductCard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(guna2PictureBox1);
            Controls.Add(btnAddToCart);
            Controls.Add(lblCategory);
            Controls.Add(lblPrice);
            Controls.Add(lblProductName);
            Name = "ProductCard";
            Size = new Size(292, 287);
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblCategory;
        private Guna.UI2.WinForms.Guna2Button btnAddToCart;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
    }
}