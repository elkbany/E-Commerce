namespace E_Commerce.Presentation
{
    partial class Signup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Signup));
            pictureBox1 = new PictureBox();
            signup_confirmpassword = new TextBox();
            label10 = new Label();
            signup_firstName = new TextBox();
            label8 = new Label();
            signup_email = new TextBox();
            label5 = new Label();
            signup_password = new TextBox();
            label9 = new Label();
            signup_close = new Label();
            signup_loginHere = new Label();
            label4 = new Label();
            signup_showPassword = new CheckBox();
            signup_btn = new Button();
            signup_username = new TextBox();
            label3 = new Label();
            signup_lastName = new TextBox();
            label2 = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(66, 52);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(595, 495);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 36;
            pictureBox1.TabStop = false;
            // 
            // signup_confirmpassword
            // 
            signup_confirmpassword.Location = new Point(694, 399);
            signup_confirmpassword.Margin = new Padding(3, 2, 3, 2);
            signup_confirmpassword.Multiline = true;
            signup_confirmpassword.Name = "signup_confirmpassword";
            signup_confirmpassword.PasswordChar = '*';
            signup_confirmpassword.Size = new Size(267, 24);
            signup_confirmpassword.TabIndex = 26;
            signup_confirmpassword.TextChanged += signup_confirmpassword_TextChanged;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.Location = new Point(694, 380);
            label10.Name = "label10";
            label10.Size = new Size(119, 19);
            label10.TabIndex = 35;
            label10.Text = "ConfirmPassword:";
            // 
            // signup_firstName
            // 
            signup_firstName.Location = new Point(694, 139);
            signup_firstName.Margin = new Padding(3, 2, 3, 2);
            signup_firstName.Multiline = true;
            signup_firstName.Name = "signup_firstName";
            signup_firstName.Size = new Size(267, 22);
            signup_firstName.TabIndex = 19;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(694, 118);
            label8.Name = "label8";
            label8.Size = new Size(74, 19);
            label8.TabIndex = 34;
            label8.Text = "FirstName:";
            // 
            // signup_email
            // 
            signup_email.Location = new Point(694, 297);
            signup_email.Margin = new Padding(3, 2, 3, 2);
            signup_email.Multiline = true;
            signup_email.Name = "signup_email";
            signup_email.Size = new Size(267, 24);
            signup_email.TabIndex = 24;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(694, 278);
            label5.Name = "label5";
            label5.Size = new Size(44, 19);
            label5.TabIndex = 33;
            label5.Text = "Email:";
            // 
            // signup_password
            // 
            signup_password.Location = new Point(694, 346);
            signup_password.Margin = new Padding(3, 2, 3, 2);
            signup_password.Multiline = true;
            signup_password.Name = "signup_password";
            signup_password.PasswordChar = '*';
            signup_password.Size = new Size(267, 24);
            signup_password.TabIndex = 25;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(694, 327);
            label9.Name = "label9";
            label9.Size = new Size(70, 19);
            label9.TabIndex = 32;
            label9.Text = "Password:";
            // 
            // signup_close
            // 
            signup_close.AutoSize = true;
            signup_close.Cursor = Cursors.Hand;
            signup_close.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            signup_close.Location = new Point(1081, 9);
            signup_close.Name = "signup_close";
            signup_close.Size = new Size(18, 20);
            signup_close.TabIndex = 29;
            signup_close.Text = "X";
            signup_close.Click += signup_close_Click_2;
            // 
            // signup_loginHere
            // 
            signup_loginHere.AutoSize = true;
            signup_loginHere.Cursor = Cursors.Hand;
            signup_loginHere.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            signup_loginHere.ForeColor = Color.FromArgb(0, 120, 212);
            signup_loginHere.Location = new Point(860, 532);
            signup_loginHere.Name = "signup_loginHere";
            signup_loginHere.Size = new Size(66, 15);
            signup_loginHere.TabIndex = 31;
            signup_loginHere.Text = "Login here";
            signup_loginHere.Click += signup_loginHere_Click_1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.ControlDarkDark;
            label4.Location = new Point(712, 532);
            label4.Name = "label4";
            label4.Size = new Size(142, 15);
            label4.TabIndex = 30;
            label4.Text = "Already have an account?";
            // 
            // signup_showPassword
            // 
            signup_showPassword.AutoSize = true;
            signup_showPassword.BackColor = Color.Transparent;
            signup_showPassword.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            signup_showPassword.ForeColor = Color.FromArgb(0, 120, 212);
            signup_showPassword.Location = new Point(838, 427);
            signup_showPassword.Margin = new Padding(3, 2, 3, 2);
            signup_showPassword.Name = "signup_showPassword";
            signup_showPassword.Size = new Size(123, 23);
            signup_showPassword.TabIndex = 27;
            signup_showPassword.Text = "Show Password";
            signup_showPassword.UseVisualStyleBackColor = false;
            signup_showPassword.CheckedChanged += signup_showPassword_CheckedChanged_1;
            // 
            // signup_btn
            // 
            signup_btn.BackColor = Color.FromArgb(0, 120, 212);
            signup_btn.Cursor = Cursors.Hand;
            signup_btn.FlatAppearance.BorderSize = 0;
            signup_btn.FlatStyle = FlatStyle.Flat;
            signup_btn.ForeColor = Color.White;
            signup_btn.Location = new Point(752, 467);
            signup_btn.Margin = new Padding(3, 2, 3, 2);
            signup_btn.Name = "signup_btn";
            signup_btn.Size = new Size(138, 46);
            signup_btn.TabIndex = 28;
            signup_btn.Text = "SIGNUP";
            signup_btn.UseVisualStyleBackColor = false;
            signup_btn.Click += signup_btn_Click_1;
            // 
            // signup_username
            // 
            signup_username.Location = new Point(694, 244);
            signup_username.Margin = new Padding(3, 2, 3, 2);
            signup_username.Multiline = true;
            signup_username.Name = "signup_username";
            signup_username.Size = new Size(267, 24);
            signup_username.TabIndex = 23;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(694, 225);
            label3.Name = "label3";
            label3.Size = new Size(76, 19);
            label3.TabIndex = 22;
            label3.Text = "UserName:";
            // 
            // signup_lastName
            // 
            signup_lastName.Location = new Point(694, 190);
            signup_lastName.Margin = new Padding(3, 2, 3, 2);
            signup_lastName.Multiline = true;
            signup_lastName.Name = "signup_lastName";
            signup_lastName.Size = new Size(267, 24);
            signup_lastName.TabIndex = 21;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(694, 171);
            label2.Name = "label2";
            label2.Size = new Size(73, 19);
            label2.TabIndex = 20;
            label2.Text = "LastName:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("MS UI Gothic", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(694, 80);
            label1.Name = "label1";
            label1.Size = new Size(131, 22);
            label1.TabIndex = 18;
            label1.Text = "Get Started";
            // 
            // Signup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1111, 617);
            Controls.Add(pictureBox1);
            Controls.Add(signup_confirmpassword);
            Controls.Add(label10);
            Controls.Add(signup_firstName);
            Controls.Add(label8);
            Controls.Add(signup_email);
            Controls.Add(label5);
            Controls.Add(signup_password);
            Controls.Add(label9);
            Controls.Add(signup_close);
            Controls.Add(signup_loginHere);
            Controls.Add(label4);
            Controls.Add(signup_showPassword);
            Controls.Add(signup_btn);
            Controls.Add(signup_username);
            Controls.Add(label3);
            Controls.Add(signup_lastName);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "Signup";
            Text = "Signup";
            MouseDown += Signup_MouseDown;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private TextBox signup_confirmpassword;
        private Label label10;
        private TextBox signup_firstName;
        private Label label8;
        private TextBox signup_email;
        private Label label5;
        private TextBox signup_password;
        private Label label9;
        private Label signup_close;
        private Label signup_loginHere;
        private Label label4;
        private CheckBox signup_showPassword;
        private Button signup_btn;
        private TextBox signup_username;
        private Label label3;
        private TextBox signup_lastName;
        private Label label2;
        private Label label1;
    }
}