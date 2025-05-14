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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges(); // لـ lblProductCount
            flowLayoutPanelProducts = new FlowLayoutPanel();
            lblTitle = new Label();
            lblNoProducts = new Label();
            comboBoxCategory = new Guna.UI2.WinForms.Guna2ComboBox();
            txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            lblLoading = new Label();
            lblProductCount = new Label(); // إضافة الـ Label الجديد
            SuspendLayout();
            // 
            // flowLayoutPanelProducts
            // 
            flowLayoutPanelProducts.AutoScroll = true;
            flowLayoutPanelProducts.Location = new Point(12, 80);
            flowLayoutPanelProducts.Name = "flowLayoutPanelProducts";
            flowLayoutPanelProducts.Size = new Size(948, 470);
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
            comboBoxCategory.CustomizableEdges = customizableEdges5;
            comboBoxCategory.DrawMode = DrawMode.OwnerDrawFixed;
            comboBoxCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCategory.FocusedColor = Color.FromArgb(94, 148, 255);
            comboBoxCategory.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            comboBoxCategory.Font = new Font("Segoe UI", 10F);
            comboBoxCategory.ForeColor = Color.FromArgb(68, 88, 112);
            comboBoxCategory.ItemHeight = 30;
            comboBoxCategory.Location = new Point(700, 12);
            comboBoxCategory.Name = "comboBoxCategory";
            comboBoxCategory.ShadowDecoration.CustomizableEdges = customizableEdges6;
            comboBoxCategory.Size = new Size(216, 36);
            comboBoxCategory.TabIndex = 3;
            comboBoxCategory.SelectedIndexChanged += comboBoxCategory_SelectedIndexChanged;
            // 
            // txtSearch
            // 
            txtSearch.BorderRadius = 10;
            txtSearch.CustomizableEdges = customizableEdges7;
            txtSearch.DefaultText = "";
            txtSearch.Font = new Font("Segoe UI", 10F);
            txtSearch.Location = new Point(175, 12);
            txtSearch.Name = "txtSearch";
            txtSearch.PasswordChar = '\0';
            txtSearch.PlaceholderText = "Search products...";
            txtSearch.SelectedText = "";
            txtSearch.ShadowDecoration.CustomizableEdges = customizableEdges8;
            txtSearch.Size = new Size(499, 36);
            txtSearch.TabIndex = 4;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // lblLoading
            // 
            lblLoading.AutoSize = true;
            lblLoading.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLoading.Location = new Point(389, 62);
            lblLoading.Name = "lblLoading";
            lblLoading.Size = new Size(155, 45);
            lblLoading.TabIndex = 0;
            lblLoading.Text = "Loading...";
            lblLoading.Visible = false;
            // 
            // lblProductCount
            // 
            lblProductCount.AutoSize = true;
            lblProductCount.Font = new Font("Segoe UI", 10F, FontStyle.Regular); // نفس Font بتاع txtSearch وcomboBoxCategory
            lblProductCount.ForeColor = Color.FromArgb(68, 88, 112); // نفس اللون بتاع النصوص
            lblProductCount.Location = new Point(12, 50); // تحت lblTitle وبجانب txtSearch
            lblProductCount.Name = "lblProductCount";
            lblProductCount.Size = new Size(80, 20); // حجم افتراضي، هيعدل نفسه بـ AutoSize
            lblProductCount.TabIndex = 5;
            lblProductCount.Text = "Products: 0";
            // 
            // frmProducts
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(972, 600);
            Controls.Add(lblProductCount); // إضافة الـ Label للـ Controls
            Controls.Add(lblLoading);
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
        private System.Windows.Forms.Label lblLoading;
        private System.Windows.Forms.Label lblProductCount; // إضافة التعريف للـ Label
    }
}