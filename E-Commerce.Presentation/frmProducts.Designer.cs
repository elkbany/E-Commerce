namespace E_Commerce.Presentation
{
    partial class frmProducts
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
            flowLayoutPanelProducts = new FlowLayoutPanel();
            lblTitle = new Label();
            lblNoProducts = new Label();
            comboBoxCategory = new Guna.UI2.WinForms.Guna2ComboBox();
            txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            SuspendLayout();
            // 
            // flowLayoutPanelProducts
            // 
            flowLayoutPanelProducts.AutoScroll = true;
            flowLayoutPanelProducts.Location = new Point(12, 80);
            flowLayoutPanelProducts.Name = "flowLayoutPanelProducts";
            flowLayoutPanelProducts.Size = new Size(776, 470);
            flowLayoutPanelProducts.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.Location = new Point(12, 10);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(106, 30);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Products";
            // 
            // lblNoProducts
            // 
            lblNoProducts.AutoSize = true;
            lblNoProducts.Font = new Font("Segoe UI", 12F);
            lblNoProducts.ForeColor = Color.Gray;
            lblNoProducts.Location = new Point(12, 110);
            lblNoProducts.Name = "lblNoProducts";
            lblNoProducts.Size = new Size(144, 21);
            lblNoProducts.TabIndex = 2;
            lblNoProducts.Text = "No products found.";
            lblNoProducts.Visible = false;
            // 
            // comboBoxCategory
            // 
            comboBoxCategory.BackColor = Color.Transparent;
            comboBoxCategory.BorderRadius = 10;
            comboBoxCategory.CustomizableEdges = customizableEdges1;
            comboBoxCategory.DrawMode = DrawMode.OwnerDrawFixed;
            comboBoxCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCategory.FocusedColor = Color.FromArgb(94, 148, 255);
            comboBoxCategory.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            comboBoxCategory.Font = new Font("Segoe UI", 10F);
            comboBoxCategory.ForeColor = Color.FromArgb(68, 88, 112);
            comboBoxCategory.ItemHeight = 30;
            comboBoxCategory.Location = new Point(600, 10);
            comboBoxCategory.Name = "comboBoxCategory";
            comboBoxCategory.ShadowDecoration.CustomizableEdges = customizableEdges2;
            comboBoxCategory.Size = new Size(188, 36);
            comboBoxCategory.TabIndex = 3;
            comboBoxCategory.SelectedIndexChanged += comboBoxCategory_SelectedIndexChanged;
            // 
            // txtSearch
            // 
            txtSearch.BorderRadius = 10;
            txtSearch.CustomizableEdges = customizableEdges3;
            txtSearch.DefaultText = "";
            txtSearch.Font = new Font("Segoe UI", 10F);
            txtSearch.Location = new Point(173, 10);
            txtSearch.Name = "txtSearch";
            txtSearch.PasswordChar = '\0';
            txtSearch.PlaceholderText = "Search products...";
            txtSearch.SelectedText = "";
            txtSearch.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtSearch.Size = new Size(421, 36);
            txtSearch.TabIndex = 4;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // frmProducts
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(800, 600);
            Controls.Add(txtSearch);
            Controls.Add(comboBoxCategory);
            Controls.Add(lblNoProducts);
            Controls.Add(lblTitle);
            Controls.Add(flowLayoutPanelProducts);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmProducts";
            Text = "Browse Products";
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelProducts;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblNoProducts;
        private Guna.UI2.WinForms.Guna2ComboBox comboBoxCategory;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
    }
}