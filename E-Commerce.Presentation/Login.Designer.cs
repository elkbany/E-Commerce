namespace E_Commerce.Presentation
{
    partial class Login
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

        private CheckBox showPassword; // أضف دي مع الـ Fields

        private Label lblNoAccount; // أضف الـ Fields
        private Label lblSignUpHere;

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            lblTitle = new Label();
            lblUsername = new Label();
            txtUsername = new Guna.UI2.WinForms.Guna2TextBox();
            lblPassword = new Label();
            txtPassword = new Guna.UI2.WinForms.Guna2TextBox();
            btnLogin = new Guna.UI2.WinForms.Guna2Button();
            btnClose = new Label();
            pictureBox1 = new PictureBox();
            showPassword = new CheckBox();
            lblNoAccount = new Label();
            lblSignUpHere = new Label();
            guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitle.Location = new Point(708, 193);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(89, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Login";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 12F);
            lblUsername.Location = new Point(708, 263);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(125, 21);
            lblUsername.TabIndex = 1;
            lblUsername.Text = "Username/Email";
            // 
            // txtUsername
            // 
            txtUsername.BorderRadius = 10;
            txtUsername.CustomizableEdges = customizableEdges1;
            txtUsername.DefaultText = "";
            txtUsername.Font = new Font("Segoe UI", 12F);
            txtUsername.Location = new Point(708, 293);
            txtUsername.Name = "txtUsername";
            txtUsername.PasswordChar = '\0';
            txtUsername.PlaceholderText = "Enter username or email";
            txtUsername.SelectedText = "";
            txtUsername.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtUsername.Size = new Size(300, 40);
            txtUsername.TabIndex = 2;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 12F);
            lblPassword.Location = new Point(708, 343);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(76, 21);
            lblPassword.TabIndex = 3;
            lblPassword.Text = "Password";
            // 
            // txtPassword
            // 
            txtPassword.BorderRadius = 10;
            txtPassword.CustomizableEdges = customizableEdges3;
            txtPassword.DefaultText = "";
            txtPassword.Font = new Font("Segoe UI", 12F);
            txtPassword.Location = new Point(708, 367);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '●';
            txtPassword.PlaceholderText = "Enter password";
            txtPassword.SelectedText = "";
            txtPassword.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtPassword.Size = new Size(300, 40);
            txtPassword.TabIndex = 4;
            // 
            // btnLogin
            // 
            btnLogin.AutoRoundedCorners = true;
            btnLogin.BorderRadius = 21;
            btnLogin.CustomizableEdges = customizableEdges5;
            btnLogin.FillColor = Color.FromArgb(0, 120, 212);
            btnLogin.Font = new Font("Segoe UI", 12F);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(708, 463);
            btnLogin.Name = "btnLogin";
            btnLogin.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnLogin.Size = new Size(300, 45);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "Login";
            btnLogin.Click += btnLogin_Click;
            // 
            // btnClose
            // 
            btnClose.AutoSize = true;
            btnClose.Cursor = Cursors.Hand;
            btnClose.Font = new Font("Segoe UI", 10.8F);
            btnClose.Location = new Point(1112, 9);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(18, 20);
            btnClose.TabIndex = 6;
            btnClose.Text = "X";
            btnClose.Click += btnClose_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources._35168541;
            pictureBox1.Location = new Point(75, 141);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(526, 407);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // showPassword
            // 
            showPassword.AutoSize = true;
            showPassword.BackColor = Color.Transparent;
            showPassword.Font = new Font("Segoe UI", 10F);
            showPassword.ForeColor = Color.FromArgb(0, 120, 212);
            showPassword.Location = new Point(716, 426);
            showPassword.Name = "showPassword";
            showPassword.Size = new Size(123, 23);
            showPassword.TabIndex = 8;
            showPassword.Text = "Show Password";
            showPassword.UseVisualStyleBackColor = false;
            showPassword.CheckedChanged += showPassword_CheckedChanged;
            // 
            // lblNoAccount
            // 
            lblNoAccount.AutoSize = true;
            lblNoAccount.Font = new Font("Segoe UI", 9F);
            lblNoAccount.ForeColor = SystemColors.ControlDarkDark;
            lblNoAccount.Location = new Point(708, 523);
            lblNoAccount.Name = "lblNoAccount";
            lblNoAccount.Size = new Size(131, 15);
            lblNoAccount.TabIndex = 9;
            lblNoAccount.Text = "Don't have an account?";
            // 
            // lblSignUpHere
            // 
            lblSignUpHere.AutoSize = true;
            lblSignUpHere.Cursor = Cursors.Hand;
            lblSignUpHere.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblSignUpHere.ForeColor = Color.FromArgb(0, 120, 212);
            lblSignUpHere.Location = new Point(850, 523);
            lblSignUpHere.Name = "lblSignUpHere";
            lblSignUpHere.Size = new Size(77, 15);
            lblSignUpHere.TabIndex = 10;
            lblSignUpHere.Text = "Sign up here";
            lblSignUpHere.Click += lblSignUpHere_Click;
            // 
            // guna2BorderlessForm1
            // 
            guna2BorderlessForm1.BorderRadius = 20;
            guna2BorderlessForm1.ContainerControl = this;
            guna2BorderlessForm1.DockIndicatorColor = Color.FromArgb(0, 120, 212);
            guna2BorderlessForm1.DockIndicatorTransparencyValue = 1D;
            guna2BorderlessForm1.DragStartTransparencyValue = 1D;
            guna2BorderlessForm1.ResizeForm = false;
            guna2BorderlessForm1.ShadowColor = Color.FromArgb(0, 120, 212);
            guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1142, 700);
            Controls.Add(lblSignUpHere);
            Controls.Add(lblNoAccount);
            Controls.Add(showPassword);
            Controls.Add(pictureBox1);
            Controls.Add(btnClose);
            Controls.Add(btnLogin);
            Controls.Add(txtPassword);
            Controls.Add(lblPassword);
            Controls.Add(txtUsername);
            Controls.Add(lblUsername);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblUsername;
        private Guna.UI2.WinForms.Guna2TextBox txtUsername;
        private System.Windows.Forms.Label lblPassword;
        private Guna.UI2.WinForms.Guna2TextBox txtPassword;
        private Guna.UI2.WinForms.Guna2Button btnLogin;
        private System.Windows.Forms.Label btnClose;
        private PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
    }
}