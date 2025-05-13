namespace E_Commerce.Presentation
{
    partial class ProductsPage
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductsPage));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            flowLayoutPanelProducts = new FlowLayoutPanel();
            btnAddProduct = new Guna.UI2.WinForms.Guna2Button();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // flowLayoutPanelProducts
            // 
            flowLayoutPanelProducts.AutoScroll = true;
            flowLayoutPanelProducts.Location = new Point(0, 147);
            flowLayoutPanelProducts.Name = "flowLayoutPanelProducts";
            flowLayoutPanelProducts.Size = new Size(1572, 613);
            flowLayoutPanelProducts.TabIndex = 0;
            // 
            // btnAddProduct
            // 
            btnAddProduct.BorderRadius = 15;
            btnAddProduct.CustomizableEdges = customizableEdges1;
            btnAddProduct.DisabledState.BorderColor = Color.DarkGray;
            btnAddProduct.DisabledState.CustomBorderColor = Color.DarkGray;
            btnAddProduct.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnAddProduct.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnAddProduct.FillColor = Color.FromArgb(24, 154, 180);
            btnAddProduct.Font = new Font("Sitka Text", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddProduct.ForeColor = Color.White;
            btnAddProduct.Image = (Image)resources.GetObject("btnAddProduct.Image");
            btnAddProduct.IndicateFocus = true;
            btnAddProduct.Location = new Point(1393, 13);
            btnAddProduct.Name = "btnAddProduct";
            btnAddProduct.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnAddProduct.Size = new Size(181, 44);
            btnAddProduct.TabIndex = 4;
            btnAddProduct.Text = "Add New Product";
            btnAddProduct.Click += btnAddProduct_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label9.ForeColor = Color.Gray;
            label9.Location = new Point(1471, 95);
            label9.Name = "label9";
            label9.Size = new Size(91, 21);
            label9.TabIndex = 15;
            label9.Text = "Operations";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label8.ForeColor = Color.Gray;
            label8.Location = new Point(1110, 95);
            label8.Name = "label8";
            label8.Size = new Size(78, 21);
            label8.TabIndex = 14;
            label8.Text = "Category";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label7.ForeColor = Color.Gray;
            label7.Location = new Point(769, 95);
            label7.Name = "label7";
            label7.Size = new Size(102, 21);
            label7.TabIndex = 13;
            label7.Text = "UnitsInStock";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label6.ForeColor = Color.Gray;
            label6.Location = new Point(400, 95);
            label6.Name = "label6";
            label6.Size = new Size(46, 21);
            label6.TabIndex = 12;
            label6.Text = "Price";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label5.ForeColor = Color.Gray;
            label5.Location = new Point(87, 95);
            label5.Name = "label5";
            label5.Size = new Size(53, 21);
            label5.TabIndex = 11;
            label5.Text = "Name";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(16, 98);
            label4.Name = "label4";
            label4.Size = new Size(14, 15);
            label4.TabIndex = 10;
            label4.Text = "#";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label3.Location = new Point(0, 20);
            label3.Name = "label3";
            label3.Size = new Size(127, 37);
            label3.TabIndex = 16;
            label3.Text = "Products";
            // 
            // ProductsPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label3);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(btnAddProduct);
            Controls.Add(flowLayoutPanelProducts);
            Name = "ProductsPage";
            Size = new Size(1575, 760);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public FlowLayoutPanel flowLayoutPanelProducts;
        private Guna.UI2.WinForms.Guna2Button btnAddProduct;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
    }
}
