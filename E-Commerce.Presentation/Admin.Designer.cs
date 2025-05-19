namespace E_Commerce.Presentation
{
    partial class Admin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Admin));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            panel1 = new Panel();
            label1 = new Label();
            btnSide = new PictureBox();
            nightControlBox1 = new ReaLTaiizor.Controls.NightControlBox();
            sidebar = new FlowLayoutPanel();
            panel2 = new Panel();
            label2 = new Label();
            btnProducts = new Guna.UI2.WinForms.Guna2Button();
            btnCategories = new Guna.UI2.WinForms.Guna2Button();
            btnUsers = new Guna.UI2.WinForms.Guna2Button();
            btnOrders = new Guna.UI2.WinForms.Guna2Button();
            guna2Button5 = new Guna.UI2.WinForms.Guna2Button();
            sidebarTransition = new System.Windows.Forms.Timer(components);
            mainContentPanel = new Panel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btnSide).BeginInit();
            sidebar.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btnSide);
            panel1.Controls.Add(nightControlBox1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1698, 39);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(50, 9);
            label1.Name = "label1";
            label1.Size = new Size(85, 19);
            label1.TabIndex = 1;
            label1.Text = "Admin Page";
            // 
            // btnSide
            // 
            btnSide.Image = (Image)resources.GetObject("btnSide.Image");
            btnSide.Location = new Point(3, 2);
            btnSide.Name = "btnSide";
            btnSide.Size = new Size(41, 35);
            btnSide.SizeMode = PictureBoxSizeMode.CenterImage;
            btnSide.TabIndex = 1;
            btnSide.TabStop = false;
            btnSide.Click += btnSide_Click_1;
            // 
            // nightControlBox1
            // 
            nightControlBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            nightControlBox1.BackColor = Color.Transparent;
            nightControlBox1.CloseHoverColor = Color.FromArgb(199, 80, 80);
            nightControlBox1.CloseHoverForeColor = Color.White;
            nightControlBox1.DefaultLocation = true;
            nightControlBox1.DisableMaximizeColor = Color.FromArgb(105, 105, 105);
            nightControlBox1.DisableMinimizeColor = Color.FromArgb(105, 105, 105);
            nightControlBox1.EnableCloseColor = Color.FromArgb(160, 160, 160);
            nightControlBox1.EnableMaximizeButton = true;
            nightControlBox1.EnableMaximizeColor = Color.FromArgb(160, 160, 160);
            nightControlBox1.EnableMinimizeButton = true;
            nightControlBox1.EnableMinimizeColor = Color.FromArgb(160, 160, 160);
            nightControlBox1.Location = new Point(1559, 0);
            nightControlBox1.MaximizeHoverColor = Color.FromArgb(15, 255, 255, 255);
            nightControlBox1.MaximizeHoverForeColor = Color.White;
            nightControlBox1.MinimizeHoverColor = Color.FromArgb(15, 255, 255, 255);
            nightControlBox1.MinimizeHoverForeColor = Color.White;
            nightControlBox1.Name = "nightControlBox1";
            nightControlBox1.Size = new Size(139, 31);
            nightControlBox1.TabIndex = 1;
            // 
            // sidebar
            // 
            sidebar.BackColor = Color.FromArgb(5, 68, 94);
            sidebar.Controls.Add(panel2);
            sidebar.Controls.Add(btnProducts);
            sidebar.Controls.Add(btnCategories);
            sidebar.Controls.Add(btnUsers);
            sidebar.Controls.Add(btnOrders);
            sidebar.Controls.Add(guna2Button5);
            sidebar.Dock = DockStyle.Left;
            sidebar.Location = new Point(0, 39);
            sidebar.Margin = new Padding(0);
            sidebar.Name = "sidebar";
            sidebar.Padding = new Padding(0, 30, 0, 0);
            sidebar.Size = new Size(250, 966);
            sidebar.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.Controls.Add(label2);
            panel2.Location = new Point(3, 33);
            panel2.Name = "panel2";
            panel2.Size = new Size(245, 60);
            panel2.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Image = (Image)resources.GetObject("label2.Image");
            label2.ImageAlign = ContentAlignment.MiddleLeft;
            label2.Location = new Point(62, 13);
            label2.Name = "label2";
            label2.Size = new Size(134, 25);
            label2.TabIndex = 3;
            label2.Text = "     Dashboard";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnProducts
            // 
            btnProducts.Animated = true;
            btnProducts.AutoRoundedCorners = true;
            btnProducts.BackColor = Color.Transparent;
            btnProducts.BorderRadius = 20;
            btnProducts.Cursor = Cursors.Hand;
            btnProducts.CustomizableEdges = customizableEdges1;
            btnProducts.DisabledState.BorderColor = Color.DarkGray;
            btnProducts.DisabledState.CustomBorderColor = Color.DarkGray;
            btnProducts.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnProducts.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnProducts.FillColor = Color.FromArgb(5, 78, 97);
            btnProducts.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnProducts.ForeColor = Color.White;
            btnProducts.Image = (Image)resources.GetObject("btnProducts.Image");
            btnProducts.ImageAlign = HorizontalAlignment.Left;
            btnProducts.ImageOffset = new Point(20, 0);
            btnProducts.IndicateFocus = true;
            btnProducts.Location = new Point(0, 146);
            btnProducts.Margin = new Padding(0, 50, 0, 0);
            btnProducts.Name = "btnProducts";
            btnProducts.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnProducts.Size = new Size(248, 42);
            btnProducts.TabIndex = 2;
            btnProducts.Text = "     Products";
            btnProducts.TextAlign = HorizontalAlignment.Left;
            btnProducts.Click += btnProducts_Click;
            // 
            // btnCategories
            // 
            btnCategories.Animated = true;
            btnCategories.AutoRoundedCorners = true;
            btnCategories.BackColor = Color.Transparent;
            btnCategories.BorderRadius = 20;
            btnCategories.Cursor = Cursors.Hand;
            btnCategories.CustomizableEdges = customizableEdges3;
            btnCategories.DisabledState.BorderColor = Color.DarkGray;
            btnCategories.DisabledState.CustomBorderColor = Color.DarkGray;
            btnCategories.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnCategories.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnCategories.FillColor = Color.FromArgb(5, 78, 97);
            btnCategories.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCategories.ForeColor = Color.White;
            btnCategories.Image = (Image)resources.GetObject("btnCategories.Image");
            btnCategories.ImageAlign = HorizontalAlignment.Left;
            btnCategories.ImageOffset = new Point(20, 0);
            btnCategories.IndicateFocus = true;
            btnCategories.Location = new Point(0, 203);
            btnCategories.Margin = new Padding(0, 15, 0, 0);
            btnCategories.Name = "btnCategories";
            btnCategories.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnCategories.Size = new Size(248, 42);
            btnCategories.TabIndex = 5;
            btnCategories.Text = "     Categories";
            btnCategories.TextAlign = HorizontalAlignment.Left;
            btnCategories.Click += btnCategories_Click;
            // 
            // btnUsers
            // 
            btnUsers.Animated = true;
            btnUsers.AutoRoundedCorners = true;
            btnUsers.BackColor = Color.Transparent;
            btnUsers.BorderRadius = 20;
            btnUsers.Cursor = Cursors.Hand;
            btnUsers.CustomizableEdges = customizableEdges5;
            btnUsers.DisabledState.BorderColor = Color.DarkGray;
            btnUsers.DisabledState.CustomBorderColor = Color.DarkGray;
            btnUsers.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnUsers.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnUsers.FillColor = Color.FromArgb(5, 78, 97);
            btnUsers.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnUsers.ForeColor = Color.White;
            btnUsers.Image = (Image)resources.GetObject("btnUsers.Image");
            btnUsers.ImageAlign = HorizontalAlignment.Left;
            btnUsers.ImageOffset = new Point(20, 0);
            btnUsers.IndicateFocus = true;
            btnUsers.Location = new Point(0, 260);
            btnUsers.Margin = new Padding(0, 15, 0, 0);
            btnUsers.Name = "btnUsers";
            btnUsers.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnUsers.Size = new Size(248, 42);
            btnUsers.TabIndex = 6;
            btnUsers.Text = "     Users";
            btnUsers.TextAlign = HorizontalAlignment.Left;
            btnUsers.Click += btnUsers_Click;
            // 
            // btnOrders
            // 
            btnOrders.Animated = true;
            btnOrders.AutoRoundedCorners = true;
            btnOrders.BackColor = Color.Transparent;
            btnOrders.BorderRadius = 20;
            btnOrders.Cursor = Cursors.Hand;
            btnOrders.CustomizableEdges = customizableEdges7;
            btnOrders.DisabledState.BorderColor = Color.DarkGray;
            btnOrders.DisabledState.CustomBorderColor = Color.DarkGray;
            btnOrders.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnOrders.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnOrders.FillColor = Color.FromArgb(5, 78, 97);
            btnOrders.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnOrders.ForeColor = Color.White;
            btnOrders.Image = (Image)resources.GetObject("btnOrders.Image");
            btnOrders.ImageAlign = HorizontalAlignment.Left;
            btnOrders.ImageOffset = new Point(20, 0);
            btnOrders.IndicateFocus = true;
            btnOrders.Location = new Point(0, 317);
            btnOrders.Margin = new Padding(0, 15, 0, 0);
            btnOrders.Name = "btnOrders";
            btnOrders.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnOrders.Size = new Size(248, 42);
            btnOrders.TabIndex = 8;
            btnOrders.Text = "     Orders";
            btnOrders.TextAlign = HorizontalAlignment.Left;
            btnOrders.Click += btnOrders_Click;
            // 
            // guna2Button5
            // 
            guna2Button5.Animated = true;
            guna2Button5.BackColor = Color.Transparent;
            guna2Button5.Cursor = Cursors.Hand;
            guna2Button5.CustomizableEdges = customizableEdges9;
            guna2Button5.DisabledState.BorderColor = Color.DarkGray;
            guna2Button5.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button5.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button5.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button5.FillColor = Color.FromArgb(5, 78, 97);
            guna2Button5.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            guna2Button5.ForeColor = Color.White;
            guna2Button5.Image = (Image)resources.GetObject("guna2Button5.Image");
            guna2Button5.ImageAlign = HorizontalAlignment.Left;
            guna2Button5.ImageOffset = new Point(20, 0);
            guna2Button5.IndicateFocus = true;
            guna2Button5.Location = new Point(0, 509);
            guna2Button5.Margin = new Padding(0, 150, 0, 0);
            guna2Button5.Name = "guna2Button5";
            guna2Button5.ShadowDecoration.CustomizableEdges = customizableEdges10;
            guna2Button5.Size = new Size(248, 42);
            guna2Button5.TabIndex = 9;
            guna2Button5.Text = "     Logout";
            guna2Button5.TextAlign = HorizontalAlignment.Left;
            guna2Button5.Click += guna2Button5_Click;
            // 
            // sidebarTransition
            // 
            sidebarTransition.Interval = 10;
            sidebarTransition.Tick += sidebarTransition_Tick_1;
            // 
            // mainContentPanel
            // 
            mainContentPanel.Dock = DockStyle.Fill;
            mainContentPanel.Location = new Point(250, 39);
            mainContentPanel.Name = "mainContentPanel";
            mainContentPanel.Size = new Size(1448, 966);
            mainContentPanel.TabIndex = 10;
            // 
            // Admin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1698, 1005);
            Controls.Add(mainContentPanel);
            Controls.Add(sidebar);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            KeyPreview = true;
            Name = "Admin";
            Text = "Form1";
            WindowState = FormWindowState.Maximized;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)btnSide).EndInit();
            sidebar.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private ReaLTaiizor.Controls.NightControlBox nightControlBox1;
        private PictureBox btnSide;
        private Label label1;
        private FlowLayoutPanel sidebar;
        private System.Windows.Forms.Timer sidebarTransition;
        private Guna.UI2.WinForms.Guna2Button btnProducts;
        private Label label2;
        private Panel panel2;
        private Guna.UI2.WinForms.Guna2Button btnCategories;
        private Guna.UI2.WinForms.Guna2Button btnUsers;
        private Guna.UI2.WinForms.Guna2Button btnOrders;
        private Guna.UI2.WinForms.Guna2Button guna2Button5;
        private Panel panelTemplate;
        private Guna.UI2.WinForms.Guna2Button btnEdit;
        private Guna.UI2.WinForms.Guna2Button DeleteButton;
        private Label lblPrice;
        private Label label24;
        public Label lblName;
        public Label lblCategory;
        public Label lblUnitsInStock;
        private Panel mainContentPanel;
    }
}
