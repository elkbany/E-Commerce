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
            panel1 = new Panel();
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
            panel2 = new Panel();
            label7 = new Label();
            pictureBox1 = new PictureBox();
            label6 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(login_close);
            panel1.Controls.Add(login_registerHere);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(login_showPassword);
            panel1.Controls.Add(login_btn);
            panel1.Controls.Add(login_password);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(login_username);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(0, 2);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(569, 334);
            panel1.TabIndex = 0;
            // 
            // login_close
            // 
            login_close.AutoSize = true;
            login_close.Cursor = Cursors.Hand;
            login_close.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            login_close.Location = new Point(541, 5);
            login_close.Name = "login_close";
            login_close.Size = new Size(18, 20);
            login_close.TabIndex = 9;
            login_close.Text = "X";
            login_close.Click += login_close_Click;
            // 
            // login_registerHere
            // 
            login_registerHere.AutoSize = true;
            login_registerHere.Cursor = Cursors.Hand;
            login_registerHere.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            login_registerHere.ForeColor = SystemColors.ControlDarkDark;
            login_registerHere.Location = new Point(424, 300);
            login_registerHere.Name = "login_registerHere";
            login_registerHere.Size = new Size(83, 15);
            login_registerHere.TabIndex = 8;
            login_registerHere.Text = "Register here";
            login_registerHere.Click += login_registerHere_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.ControlDarkDark;
            label4.Location = new Point(276, 300);
            label4.Name = "label4";
            label4.Size = new Size(131, 15);
            label4.TabIndex = 7;
            label4.Text = "Don't have an account?";
            // 
            // login_showPassword
            // 
            login_showPassword.AutoSize = true;
            login_showPassword.BackColor = Color.Transparent;
            login_showPassword.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            login_showPassword.ForeColor = SystemColors.AppWorkspace;
            login_showPassword.Location = new Point(388, 178);
            login_showPassword.Margin = new Padding(3, 2, 3, 2);
            login_showPassword.Name = "login_showPassword";
            login_showPassword.Size = new Size(123, 23);
            login_showPassword.TabIndex = 6;
            login_showPassword.Text = "Show Password";
            login_showPassword.UseVisualStyleBackColor = false;
            login_showPassword.CheckedChanged += login_showPassword_CheckedChanged;
            // 
            // login_btn
            // 
            login_btn.BackColor = Color.MidnightBlue;
            login_btn.Cursor = Cursors.Hand;
            login_btn.FlatAppearance.BorderSize = 0;
            login_btn.ForeColor = Color.White;
            login_btn.Location = new Point(250, 204);
            login_btn.Margin = new Padding(3, 2, 3, 2);
            login_btn.Name = "login_btn";
            login_btn.Size = new Size(119, 46);
            login_btn.TabIndex = 5;
            login_btn.Text = "LOGIN";
            login_btn.UseVisualStyleBackColor = false;
            login_btn.Click += login_btn_Click;
            // 
            // login_password
            // 
            login_password.Font = new Font("Segoe UI", 10.2F);
            login_password.Location = new Point(250, 144);
            login_password.Margin = new Padding(3, 2, 3, 2);
            login_password.Multiline = true;
            login_password.Name = "login_password";
            login_password.PasswordChar = '*';
            login_password.Size = new Size(267, 24);
            login_password.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(250, 124);
            label3.Name = "label3";
            label3.Size = new Size(70, 19);
            label3.TabIndex = 3;
            label3.Text = "Password:";
            // 
            // login_username
            // 
            login_username.Font = new Font("Segoe UI", 10.2F);
            login_username.Location = new Point(250, 87);
            login_username.Margin = new Padding(3, 2, 3, 2);
            login_username.Multiline = true;
            login_username.Name = "login_username";
            login_username.Size = new Size(267, 24);
            login_username.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(250, 68);
            label2.Name = "label2";
            label2.Size = new Size(74, 19);
            label2.TabIndex = 1;
            label2.Text = "Username:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("MS UI Gothic", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(250, 32);
            label1.Name = "label1";
            label1.Size = new Size(161, 22);
            label1.TabIndex = 0;
            label1.Text = "Welcome Back!";
            // 
            // panel2
            // 
            panel2.BackColor = Color.MidnightBlue;
            panel2.Controls.Add(label7);
            panel2.Controls.Add(pictureBox1);
            panel2.Controls.Add(label6);
            panel2.Location = new Point(0, 2);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(245, 334);
            panel2.TabIndex = 0;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label7.ForeColor = SystemColors.ButtonFace;
            label7.Location = new Point(74, 107);
            label7.Name = "label7";
            label7.Size = new Size(94, 21);
            label7.TabIndex = 9;
            label7.Text = "Image here ";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(57, 68);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(135, 94);
            pictureBox1.TabIndex = 9;
            pictureBox1.TabStop = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe Print", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.White;
            label6.Location = new Point(8, 173);
            label6.Name = "label6";
            label6.Size = new Size(219, 33);
            label6.TabIndex = 9;
            label6.Text = "E-Commerce Project";
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(569, 338);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Panel panel2;
        private TextBox login_username;
        private Label label2;
        private Button login_btn;
        private TextBox login_password;
        private Label label3;
        private CheckBox login_showPassword;
        private Label login_registerHere;
        private Label label4;
        private PictureBox pictureBox1;
        private Label label6;
        private Label label7;
        private Label login_close;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
    }
}
