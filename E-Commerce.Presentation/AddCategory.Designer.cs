namespace E_Commerce.Presentation
{
    partial class AddCategory
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            txtCategoryName = new Guna.UI2.WinForms.Guna2TextBox();
            btnCancel = new Guna.UI2.WinForms.Guna2Button();
            btnSave = new Guna.UI2.WinForms.Guna2Button();
            panel1 = new Panel();
            label1 = new Label();
            label2 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // txtCategoryName
            // 
            txtCategoryName.BorderRadius = 12;
            txtCategoryName.CustomizableEdges = customizableEdges1;
            txtCategoryName.DefaultText = "";
            txtCategoryName.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtCategoryName.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtCategoryName.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtCategoryName.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtCategoryName.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtCategoryName.Font = new Font("Segoe UI", 9F);
            txtCategoryName.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtCategoryName.Location = new Point(189, 86);
            txtCategoryName.Name = "txtCategoryName";
            txtCategoryName.PlaceholderText = "";
            txtCategoryName.SelectedText = "";
            txtCategoryName.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtCategoryName.Size = new Size(250, 28);
            txtCategoryName.TabIndex = 51;
            // 
            // btnCancel
            // 
            btnCancel.BorderRadius = 6;
            btnCancel.CustomizableEdges = customizableEdges3;
            btnCancel.DisabledState.BorderColor = Color.DarkGray;
            btnCancel.DisabledState.CustomBorderColor = Color.DarkGray;
            btnCancel.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnCancel.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnCancel.FillColor = Color.FromArgb(229, 105, 151);
            btnCancel.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(425, 188);
            btnCancel.Margin = new Padding(3, 2, 3, 2);
            btnCancel.Name = "btnCancel";
            btnCancel.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnCancel.Size = new Size(98, 32);
            btnCancel.TabIndex = 49;
            btnCancel.Text = "Cancel";
            btnCancel.Click += btnCancel_Click_1;
            // 
            // btnSave
            // 
            btnSave.BorderRadius = 6;
            btnSave.CustomizableEdges = customizableEdges5;
            btnSave.DisabledState.BorderColor = Color.DarkGray;
            btnSave.DisabledState.CustomBorderColor = Color.DarkGray;
            btnSave.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnSave.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnSave.FillColor = Color.FromArgb(102, 210, 214);
            btnSave.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(303, 188);
            btnSave.Margin = new Padding(3, 2, 3, 2);
            btnSave.Name = "btnSave";
            btnSave.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnSave.Size = new Size(98, 32);
            btnSave.TabIndex = 48;
            btnSave.Text = "Save";
            btnSave.Click += btnSave_Click_1;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 59, 115);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(564, 35);
            panel1.TabIndex = 47;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(208, 7);
            label1.Name = "label1";
            label1.Size = new Size(177, 25);
            label1.TabIndex = 0;
            label1.Text = "Add New Category";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(28, 95);
            label2.Name = "label2";
            label2.Size = new Size(119, 20);
            label2.TabIndex = 42;
            label2.Text = "CategoryName:";
            // 
            // AddCategory
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(564, 249);
            Controls.Add(txtCategoryName);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(panel1);
            Controls.Add(label2);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AddCategory";
            Text = "AddCategory";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        public Guna.UI2.WinForms.Guna2TextBox txtCategoryName;
        public Guna.UI2.WinForms.Guna2Button btnCancel;
        public Guna.UI2.WinForms.Guna2Button btnSave;
        private Panel panel1;
        private Label label1;
        private Label label2;
    }
}