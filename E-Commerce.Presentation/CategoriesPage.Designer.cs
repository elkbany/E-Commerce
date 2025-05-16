namespace E_Commerce.Presentation
{
    partial class CategoriesPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CategoriesPage));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            flowLayoutPanelCategories = new FlowLayoutPanel();
            btnAddCategory = new Guna.UI2.WinForms.Guna2Button();
            label3 = new Label();
            label5 = new Label();
            label4 = new Label();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // flowLayoutPanelCategories
            // 
            flowLayoutPanelCategories.AutoScroll = true;
            flowLayoutPanelCategories.Location = new Point(3, 144);
            flowLayoutPanelCategories.Name = "flowLayoutPanelCategories";
            flowLayoutPanelCategories.Size = new Size(1000, 613);
            flowLayoutPanelCategories.TabIndex = 0;
            // 
            // btnAddCategory
            // 
            btnAddCategory.BorderRadius = 15;
            btnAddCategory.CustomizableEdges = customizableEdges1;
            btnAddCategory.DisabledState.BorderColor = Color.DarkGray;
            btnAddCategory.DisabledState.CustomBorderColor = Color.DarkGray;
            btnAddCategory.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnAddCategory.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnAddCategory.FillColor = Color.FromArgb(24, 154, 180);
            btnAddCategory.Font = new Font("Sitka Text", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddCategory.ForeColor = Color.White;
            btnAddCategory.Image = (Image)resources.GetObject("btnAddCategory.Image");
            btnAddCategory.IndicateFocus = true;
            btnAddCategory.Location = new Point(839, 43);
            btnAddCategory.Name = "btnAddCategory";
            btnAddCategory.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnAddCategory.Size = new Size(181, 44);
            btnAddCategory.TabIndex = 12;
            btnAddCategory.Text = "Add New Category";
            btnAddCategory.Click += btnAddCategory_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label3.Location = new Point(0, 20);
            label3.Name = "label3";
            label3.Size = new Size(152, 37);
            label3.TabIndex = 23;
            label3.Text = "Categories";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label5.ForeColor = Color.Gray;
            label5.Location = new Point(90, 105);
            label5.Name = "label5";
            label5.Size = new Size(53, 21);
            label5.TabIndex = 18;
            label5.Text = "Name";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(27, 108);
            label4.Name = "label4";
            label4.Size = new Size(14, 15);
            label4.TabIndex = 17;
            label4.Text = "#";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label1.ForeColor = Color.Gray;
            label1.Location = new Point(1473, 102);
            label1.Name = "label1";
            label1.Size = new Size(91, 21);
            label1.TabIndex = 24;
            label1.Text = "Operations";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label2.ForeColor = Color.Gray;
            label2.Location = new Point(262, 105);
            label2.Name = "label2";
            label2.Size = new Size(94, 21);
            label2.TabIndex = 25;
            label2.Text = "Description";
            // 
            // CategoriesPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(label3);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(btnAddCategory);
            Controls.Add(flowLayoutPanelCategories);
            Name = "CategoriesPage";
            Size = new Size(1575, 760);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public FlowLayoutPanel flowLayoutPanelCategories;
        private Guna.UI2.WinForms.Guna2Button btnAddCategory;
        private Label label3;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label1;
        private Label label2;
    }
}
