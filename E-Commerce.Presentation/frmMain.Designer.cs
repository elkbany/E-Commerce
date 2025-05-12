namespace E_Commerce.Presentation
{
    partial class frmMain
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            panel1 = new Panel();
            nightControlBox1 = new ReaLTaiizor.Controls.NightControlBox();
            label1 = new Label();
            btnDrag = new PictureBox();
            sidebar = new FlowLayoutPanel();
            panel2 = new Panel();
            label2 = new Label();
            labelUsername = new Label();
            btnProducts = new Button();
            btnCart = new Button();
            btnOrders = new Button();
            btnProfile = new Button();
            btnLogout = new Button();
            sidebarTransition = new System.Windows.Forms.Timer(components);
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btnDrag).BeginInit();
            sidebar.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(nightControlBox1);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btnDrag);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1289, 38);
            panel1.TabIndex = 0;
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
            nightControlBox1.Location = new Point(1150, 0);
            nightControlBox1.MaximizeHoverColor = Color.FromArgb(15, 255, 255, 255);
            nightControlBox1.MaximizeHoverForeColor = Color.White;
            nightControlBox1.MinimizeHoverColor = Color.FromArgb(15, 255, 255, 255);
            nightControlBox1.MinimizeHoverForeColor = Color.White;
            nightControlBox1.Name = "nightControlBox1";
            nightControlBox1.Size = new Size(139, 31);
            nightControlBox1.TabIndex = 5;
            nightControlBox1.Click += nightControlBox1_Click_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(76, 9);
            label1.Name = "label1";
            label1.Size = new Size(272, 21);
            label1.TabIndex = 3;
            label1.Text = "E-Commerce Management System";
            // 
            // btnDrag
            // 
            btnDrag.Image = (Image)resources.GetObject("btnDrag.Image");
            btnDrag.Location = new Point(5, 7);
            btnDrag.Name = "btnDrag";
            btnDrag.Size = new Size(52, 26);
            btnDrag.SizeMode = PictureBoxSizeMode.CenterImage;
            btnDrag.TabIndex = 2;
            btnDrag.TabStop = false;
            btnDrag.Click += btnDrag_Click;
            // 
            // sidebar
            // 
            sidebar.BackColor = Color.FromArgb(0, 120, 212);
            sidebar.Controls.Add(panel2);
            sidebar.Controls.Add(btnProducts);
            sidebar.Controls.Add(btnCart);
            sidebar.Controls.Add(btnOrders);
            sidebar.Controls.Add(btnProfile);
            sidebar.Controls.Add(btnLogout);
            sidebar.Dock = DockStyle.Left;
            sidebar.Location = new Point(0, 38);
            sidebar.Name = "sidebar";
            sidebar.Size = new Size(254, 666);
            sidebar.TabIndex = 2;
            // 
            // panel2
            // 
            panel2.Controls.Add(label2);
            panel2.Controls.Add(labelUsername);
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(251, 80);
            panel2.TabIndex = 10;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.Control;
            label2.Location = new Point(18, 27);
            label2.Name = "label2";
            label2.Size = new Size(99, 25);
            label2.TabIndex = 10;
            label2.Text = "Welcome :";
            // 
            // labelUsername
            // 
            labelUsername.AutoSize = true;
            labelUsername.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelUsername.ForeColor = SystemColors.Control;
            labelUsername.Location = new Point(123, 27);
            labelUsername.Name = "labelUsername";
            labelUsername.Size = new Size(63, 25);
            labelUsername.TabIndex = 9;
            labelUsername.Text = "label2";
            labelUsername.Click += labelUsername_Click;
            // 
            // btnProducts
            // 
            btnProducts.BackColor = Color.FromArgb(0, 120, 212);
            btnProducts.FlatStyle = FlatStyle.Flat;
            btnProducts.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnProducts.ForeColor = SystemColors.Control;
            btnProducts.Image = (Image)resources.GetObject("btnProducts.Image");
            btnProducts.ImageAlign = ContentAlignment.MiddleLeft;
            btnProducts.Location = new Point(0, 136);
            btnProducts.Margin = new Padding(0, 50, 3, 3);
            btnProducts.Name = "btnProducts";
            btnProducts.Padding = new Padding(10, 0, 0, 0);
            btnProducts.Size = new Size(251, 62);
            btnProducts.TabIndex = 4;
            btnProducts.Text = "Products";
            btnProducts.UseVisualStyleBackColor = false;
            btnProducts.Click += btnProducts_Click;
            // 
            // btnCart
            // 
            btnCart.BackColor = Color.FromArgb(0, 120, 212);
            btnCart.FlatStyle = FlatStyle.Flat;
            btnCart.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCart.ForeColor = SystemColors.Control;
            btnCart.Image = (Image)resources.GetObject("btnCart.Image");
            btnCart.ImageAlign = ContentAlignment.MiddleLeft;
            btnCart.Location = new Point(0, 204);
            btnCart.Margin = new Padding(0, 3, 3, 3);
            btnCart.Name = "btnCart";
            btnCart.Padding = new Padding(10, 0, 0, 0);
            btnCart.Size = new Size(251, 62);
            btnCart.TabIndex = 6;
            btnCart.Text = "Cart";
            btnCart.UseVisualStyleBackColor = false;
            // 
            // btnOrders
            // 
            btnOrders.AccessibleDescription = "";
            btnOrders.BackColor = Color.FromArgb(0, 120, 212);
            btnOrders.FlatStyle = FlatStyle.Flat;
            btnOrders.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnOrders.ForeColor = SystemColors.Control;
            btnOrders.Image = (Image)resources.GetObject("btnOrders.Image");
            btnOrders.ImageAlign = ContentAlignment.MiddleLeft;
            btnOrders.Location = new Point(0, 272);
            btnOrders.Margin = new Padding(0, 3, 3, 3);
            btnOrders.Name = "btnOrders";
            btnOrders.Padding = new Padding(10, 0, 0, 0);
            btnOrders.Size = new Size(251, 62);
            btnOrders.TabIndex = 5;
            btnOrders.Text = "Orders";
            btnOrders.UseVisualStyleBackColor = false;
            btnOrders.Click += btnOrders_Click;
            // 
            // btnProfile
            // 
            btnProfile.BackColor = Color.FromArgb(0, 120, 212);
            btnProfile.FlatStyle = FlatStyle.Flat;
            btnProfile.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnProfile.ForeColor = SystemColors.Control;
            btnProfile.Image = (Image)resources.GetObject("btnProfile.Image");
            btnProfile.ImageAlign = ContentAlignment.MiddleLeft;
            btnProfile.Location = new Point(0, 340);
            btnProfile.Margin = new Padding(0, 3, 3, 3);
            btnProfile.Name = "btnProfile";
            btnProfile.Padding = new Padding(10, 0, 0, 0);
            btnProfile.Size = new Size(251, 62);
            btnProfile.TabIndex = 7;
            btnProfile.Text = "Profile";
            btnProfile.UseVisualStyleBackColor = false;
            btnProfile.Click += btnProfile_Click;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.FromArgb(0, 120, 212);
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLogout.ForeColor = SystemColors.Control;
            btnLogout.Image = (Image)resources.GetObject("btnLogout.Image");
            btnLogout.ImageAlign = ContentAlignment.MiddleLeft;
            btnLogout.Location = new Point(0, 555);
            btnLogout.Margin = new Padding(0, 150, 3, 3);
            btnLogout.Name = "btnLogout";
            btnLogout.Padding = new Padding(10, 0, 0, 0);
            btnLogout.Size = new Size(251, 62);
            btnLogout.TabIndex = 8;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // sidebarTransition
            // 
            sidebarTransition.Interval = 10;
            sidebarTransition.Tick += sidebarTransition_Tick;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1289, 704);
            Controls.Add(sidebar);
            Controls.Add(panel1);
            ForeColor = SystemColors.ControlText;
            FormBorderStyle = FormBorderStyle.None;
            IsMdiContainer = true;
            Name = "frmMain";
            Text = "frmMain";
            Load += frmMain_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)btnDrag).EndInit();
            sidebar.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private PictureBox btnDrag;
        private FlowLayoutPanel sidebar;
        private Button btnProducts;
        private Button btnCart;
        private Button btnOrders;
        private Button btnProfile;
        private Button btnLogout;
        private System.Windows.Forms.Timer sidebarTransition;
        private Panel panel2;
        private Label labelUsername;
        private Label label2;
        private ReaLTaiizor.Controls.NightControlBox nightControlBox1;
    }
}