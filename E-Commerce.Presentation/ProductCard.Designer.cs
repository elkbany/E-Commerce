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
            pictureBoxProduct = new PictureBox();
            lblProductName = new Label();
            lblPrice = new Label();
            lblCategory = new Label();
            btnAddToCart = new Button();
            panelCard = new Panel();
            panelCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxProduct).BeginInit();
            SuspendLayout();
            // 
            // pictureBoxProduct
            // 
            pictureBoxProduct.Location = new Point(10, 10);
            pictureBoxProduct.Name = "pictureBoxProduct";
            pictureBoxProduct.Size = new Size(100, 100);
            pictureBoxProduct.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxProduct.TabIndex = 0;
            pictureBoxProduct.TabStop = false;
            // 
            // lblProductName
            // 
            lblProductName.AutoSize = true;
            lblProductName.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblProductName.Location = new Point(120, 10);
            lblProductName.Name = "lblProductName";
            lblProductName.Size = new Size(100, 21);
            lblProductName.TabIndex = 1;
            lblProductName.Text = "Product Name";
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Font = new Font("Segoe UI", 10F);
            lblPrice.Location = new Point(120, 40);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(70, 19);
            lblPrice.TabIndex = 2;
            lblPrice.Text = "Price: $50.00";
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Font = new Font("Segoe UI", 10F);
            lblCategory.Location = new Point(120, 65);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(90, 19);
            lblCategory.TabIndex = 3;
            lblCategory.Text = "Category: Tech";
            // 
            // btnAddToCart
            // 
            btnAddToCart.BackColor = Color.FromArgb(0, 120, 212);
            btnAddToCart.FlatStyle = FlatStyle.Flat;
            btnAddToCart.Font = new Font("Segoe UI", 10F);
            btnAddToCart.ForeColor = Color.White;
            btnAddToCart.Location = new Point(120, 90);
            btnAddToCart.Name = "btnAddToCart";
            btnAddToCart.Size = new Size(100, 30);
            btnAddToCart.TabIndex = 4;
            btnAddToCart.Text = "Add to Cart";
            btnAddToCart.UseVisualStyleBackColor = false;
            btnAddToCart.Click += btnAddToCart_Click;
            // 
            // panelCard
            // 
            panelCard.BackColor = Color.FromArgb(245, 245, 245);
            panelCard.BorderStyle = BorderStyle.FixedSingle;
            panelCard.Controls.Add(btnAddToCart);
            panelCard.Controls.Add(lblCategory);
            panelCard.Controls.Add(lblPrice);
            panelCard.Controls.Add(lblProductName);
            panelCard.Controls.Add(pictureBoxProduct);
            panelCard.Location = new Point(0, 0);
            panelCard.Name = "panelCard";
            panelCard.Size = new Size(260, 130);
            panelCard.TabIndex = 5;
            panelCard.Padding = new Padding(10);
            // 
            // ProductCard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panelCard);
            Name = "ProductCard";
            Size = new Size(260, 130);
            panelCard.ResumeLayout(false);
            panelCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxProduct).EndInit();
            ResumeLayout(false);
        }

        private PictureBox pictureBoxProduct;
        private Label lblProductName;
        private Label lblPrice;
        private Label lblCategory;
        private Button btnAddToCart;
        private Panel panelCard;
    }
}