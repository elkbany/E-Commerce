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
            lblTitle = new Label();
            comboBoxCategory = new Guna.UI2.WinForms.Guna2ComboBox();
            txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            lblLoading = new Label();
            lblProductCount = new Label();
            panel1 = new Panel();
            panel3 = new Panel();
            panel2 = new Panel();
            flowLayoutPanelProducts = new FlowLayoutPanel();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            flowLayoutPanelProducts.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Dock = DockStyle.Left;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.Location = new Point(0, 0);
            lblTitle.Margin = new Padding(0);
            lblTitle.Name = "lblTitle";
            lblTitle.Padding = new Padding(20, 8, 0, 0);
            lblTitle.Size = new Size(126, 38);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Products";
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
            comboBoxCategory.Location = new Point(500, 5);
            comboBoxCategory.Name = "comboBoxCategory";
            comboBoxCategory.ShadowDecoration.CustomizableEdges = customizableEdges2;
            comboBoxCategory.Size = new Size(216, 36);
            comboBoxCategory.TabIndex = 3;
            comboBoxCategory.SelectedIndexChanged += comboBoxCategory_SelectedIndexChanged;
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.None;
            txtSearch.BorderRadius = 10;
            txtSearch.CustomizableEdges = customizableEdges3;
            txtSearch.DefaultText = "";
            txtSearch.Font = new Font("Segoe UI", 10F);
            txtSearch.Location = new Point(52, 5);
            txtSearch.Name = "txtSearch";
            txtSearch.PasswordChar = '\0';
            txtSearch.PlaceholderText = "Search products...";
            txtSearch.SelectedText = "";
            txtSearch.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtSearch.Size = new Size(397, 36);
            txtSearch.TabIndex = 4;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // lblLoading
            // 
            lblLoading.AutoSize = true;
            lblLoading.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLoading.Location = new Point(23, 0);
            lblLoading.Name = "lblLoading";
            lblLoading.Size = new Size(155, 45);
            lblLoading.TabIndex = 0;
            lblLoading.Text = "Loading...";
            lblLoading.Visible = false;
            // 
            // lblProductCount
            // 
            lblProductCount.Anchor = AnchorStyles.None;
            lblProductCount.AutoSize = true;
            lblProductCount.Font = new Font("Segoe UI", 10F);
            lblProductCount.ForeColor = Color.FromArgb(68, 88, 112);
            lblProductCount.Location = new Point(153, 17);
            lblProductCount.Name = "lblProductCount";
            lblProductCount.Size = new Size(78, 19);
            lblProductCount.TabIndex = 5;
            lblProductCount.Text = "Products: 0";
            // 
            // panel1
            // 
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1214, 47);
            panel1.TabIndex = 6;
            // 
            // panel3
            // 
            panel3.Controls.Add(lblTitle);
            panel3.Controls.Add(lblProductCount);
            panel3.Dock = DockStyle.Left;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(243, 47);
            panel3.TabIndex = 7;
            // 
            // panel2
            // 
            panel2.Controls.Add(txtSearch);
            panel2.Controls.Add(comboBoxCategory);
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(419, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(795, 47);
            panel2.TabIndex = 6;
            // 
            // flowLayoutPanelProducts
            // 
            flowLayoutPanelProducts.AutoScroll = true;
            flowLayoutPanelProducts.Controls.Add(lblLoading);
            flowLayoutPanelProducts.Dock = DockStyle.Fill;
            flowLayoutPanelProducts.Location = new Point(0, 47);
            flowLayoutPanelProducts.Name = "flowLayoutPanelProducts";
            flowLayoutPanelProducts.Padding = new Padding(20, 0, 0, 0);
            flowLayoutPanelProducts.Size = new Size(1214, 634);
            flowLayoutPanelProducts.TabIndex = 7;
            // 
            // frmProducts
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1214, 681);
            Controls.Add(flowLayoutPanelProducts);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmProducts";
            Text = "Browse Products";
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            flowLayoutPanelProducts.ResumeLayout(false);
            flowLayoutPanelProducts.PerformLayout();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblTitle;
        private Guna.UI2.WinForms.Guna2ComboBox comboBoxCategory;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private System.Windows.Forms.Label lblLoading;
        private System.Windows.Forms.Label lblProductCount; // إضافة التعريف للـ Label
        private Panel panel1;
        private FlowLayoutPanel flowLayoutPanelProducts;
        private Panel panel2;
        private Panel panel3;
    }
}