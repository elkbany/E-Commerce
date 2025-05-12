namespace E_Commerce.Presentation
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            pictureBox1 = new PictureBox();
            login_close = new Label();
            login_registerHere = new Label();
            label4 = new Label();
            login_showPassword = new CheckBox();
            login_btn = new Button();
            login_password = new TextBox();
            label3 = new Label();
            login_username = new TextBox();
            label2 = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(35, 45);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(407, 396);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 21;
            pictureBox1.TabStop = false;
            // 
            // login_close
            // 
            login_close.AutoSize = true;
            login_close.Cursor = Cursors.Hand;
            login_close.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            login_close.Location = new Point(975, 8);
            login_close.Name = "login_close";
            login_close.Size = new Size(18, 20);
            login_close.TabIndex = 20;
            login_close.Text = "X";
            login_close.Click += login_close_Click_1;
            // 
            // login_registerHere
            // 
            login_registerHere.AutoSize = true;
            login_registerHere.Cursor = Cursors.Hand;
            login_registerHere.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            login_registerHere.ForeColor = Color.FromArgb(0, 120, 212);
            login_registerHere.Location = new Point(727, 389);
            login_registerHere.Name = "login_registerHere";
            login_registerHere.Size = new Size(83, 15);
            login_registerHere.TabIndex = 18;
            login_registerHere.Text = "Register here";
            login_registerHere.Click += login_registerHere_Click_1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.ControlDarkDark;
            label4.Location = new Point(590, 389);
            label4.Name = "label4";
            label4.Size = new Size(131, 15);
            label4.TabIndex = 19;
            label4.Text = "Don't have an account?";
            // 
            // login_showPassword
            // 
            login_showPassword.AutoSize = true;
            login_showPassword.BackColor = Color.Transparent;
            login_showPassword.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            login_showPassword.ForeColor = SystemColors.AppWorkspace;
            login_showPassword.Location = new Point(708, 268);
            login_showPassword.Margin = new Padding(3, 2, 3, 2);
            login_showPassword.Name = "login_showPassword";
            login_showPassword.Size = new Size(123, 23);
            login_showPassword.TabIndex = 15;
            login_showPassword.Text = "Show Password";
            login_showPassword.UseVisualStyleBackColor = false;
            login_showPassword.CheckedChanged += login_showPassword_CheckedChanged_1;
            // 
            // login_btn
            // 
            login_btn.BackColor = Color.FromArgb(0, 120, 212);
            login_btn.Cursor = Cursors.Hand;
            login_btn.FlatAppearance.BorderSize = 0;
            login_btn.FlatStyle = FlatStyle.Flat;
            login_btn.ForeColor = Color.White;
            login_btn.Location = new Point(626, 307);
            login_btn.Margin = new Padding(3, 2, 3, 2);
            login_btn.Name = "login_btn";
            login_btn.Size = new Size(138, 46);
            login_btn.TabIndex = 17;
            login_btn.Text = "LOGIN";
            login_btn.UseVisualStyleBackColor = false;
            login_btn.Click += login_btn_Click_1;
            // 
            // login_password
            // 
            login_password.Font = new Font("Segoe UI", 10.2F);
            login_password.Location = new Point(564, 233);
            login_password.Margin = new Padding(3, 2, 3, 2);
            login_password.Multiline = true;
            login_password.Name = "login_password";
            login_password.PasswordChar = '*';
            login_password.Size = new Size(267, 24);
            login_password.TabIndex = 14;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(564, 213);
            label3.Name = "label3";
            label3.Size = new Size(70, 19);
            label3.TabIndex = 16;
            label3.Text = "Password:";
            // 
            // login_username
            // 
            login_username.Font = new Font("Segoe UI", 10.2F);
            login_username.Location = new Point(564, 176);
            login_username.Margin = new Padding(3, 2, 3, 2);
            login_username.Multiline = true;
            login_username.Name = "login_username";
            login_username.Size = new Size(267, 24);
            login_username.TabIndex = 12;
            login_username.TextChanged += login_username_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(564, 157);
            label2.Name = "label2";
            label2.Size = new Size(74, 19);
            label2.TabIndex = 13;
            label2.Text = "Username:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("MS UI Gothic", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(564, 121);
            label1.Name = "label1";
            label1.Size = new Size(161, 22);
            label1.TabIndex = 11;
            label1.Text = "Welcome Back!";
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1002, 500);
            Controls.Add(pictureBox1);
            Controls.Add(login_close);
            Controls.Add(login_registerHere);
            Controls.Add(label4);
            Controls.Add(login_showPassword);
            Controls.Add(login_btn);
            Controls.Add(login_password);
            Controls.Add(label3);
            Controls.Add(login_username);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "Login";
            Text = "Form1";
            Load += Login_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label login_close;
        private Label login_registerHere;
        private Label label4;
        private CheckBox login_showPassword;
        private Button login_btn;
        private TextBox login_password;
        private Label label3;
        private TextBox login_username;
        private Label label2;
        private Label label1;
        //private Guna.UI2.WinForms.Guna2Button guna2Button1;
        //private Guna.UI2.WinForms.Guna2Button guna2Button1;
        //private Guna.UI2.WinForms.Guna2Button guna2Button1;
    }
}
