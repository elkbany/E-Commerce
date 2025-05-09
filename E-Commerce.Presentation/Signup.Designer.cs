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
            panel2 = new Panel();
            label7 = new Label();
            pictureBox1 = new PictureBox();
            label6 = new Label();
            panel1 = new Panel();
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
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = Color.MidnightBlue;
            panel2.Controls.Add(label7);
            panel2.Controls.Add(pictureBox1);
            panel2.Controls.Add(label6);
            panel2.Location = new Point(0, 0);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(245, 416);
            panel2.TabIndex = 1;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label7.ForeColor = SystemColors.ButtonFace;
            label7.Location = new Point(74, 169);
            label7.Name = "label7";
            label7.Size = new Size(94, 21);
            label7.TabIndex = 9;
            label7.Text = "Image here ";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(57, 130);
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
            label6.Location = new Point(8, 236);
            label6.Name = "label6";
            label6.Size = new Size(219, 33);
            label6.TabIndex = 9;
            label6.Text = "E-Commerce Project";
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(signup_firstName);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(signup_email);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(signup_password);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(signup_close);
            panel1.Controls.Add(signup_loginHere);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(signup_showPassword);
            panel1.Controls.Add(signup_btn);
            panel1.Controls.Add(signup_username);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(signup_lastName);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(569, 416);
            panel1.TabIndex = 2;
            panel1.Paint += panel1_Paint;
            // 
            // signup_firstName
            // 
            signup_firstName.Location = new Point(250, 89);
            signup_firstName.Margin = new Padding(3, 2, 3, 2);
            signup_firstName.Multiline = true;
            signup_firstName.Name = "signup_firstName";
            signup_firstName.Size = new Size(267, 24);
            signup_firstName.TabIndex = 15;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(250, 70);
            label8.Name = "label8";
            label8.Size = new Size(74, 19);
            label8.TabIndex = 14;
            label8.Text = "FirstName:";
            // 
            // signup_email
            // 
            signup_email.Location = new Point(250, 249);
            signup_email.Margin = new Padding(3, 2, 3, 2);
            signup_email.Multiline = true;
            signup_email.Name = "signup_email";
            signup_email.Size = new Size(267, 24);
            signup_email.TabIndex = 13;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(250, 230);
            label5.Name = "label5";
            label5.Size = new Size(44, 19);
            label5.TabIndex = 12;
            label5.Text = "Email:";
            // 
            // signup_password
            // 
            signup_password.Location = new Point(250, 298);
            signup_password.Margin = new Padding(3, 2, 3, 2);
            signup_password.Multiline = true;
            signup_password.Name = "signup_password";
            signup_password.PasswordChar = '*';
            signup_password.Size = new Size(267, 24);
            signup_password.TabIndex = 11;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(250, 279);
            label9.Name = "label9";
            label9.Size = new Size(70, 19);
            label9.TabIndex = 10;
            label9.Text = "Password:";
            // 
            // signup_close
            // 
            signup_close.AutoSize = true;
            signup_close.Cursor = Cursors.Hand;
            signup_close.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            signup_close.Location = new Point(541, 5);
            signup_close.Name = "signup_close";
            signup_close.Size = new Size(18, 20);
            signup_close.TabIndex = 9;
            signup_close.Text = "X";
            signup_close.Click += signup_close_Click_1;
            // 
            // signup_loginHere
            // 
            signup_loginHere.AutoSize = true;
            signup_loginHere.Cursor = Cursors.Hand;
            signup_loginHere.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            signup_loginHere.ForeColor = SystemColors.ControlDarkDark;
            signup_loginHere.Location = new Point(424, 389);
            signup_loginHere.Name = "signup_loginHere";
            signup_loginHere.Size = new Size(66, 15);
            signup_loginHere.TabIndex = 8;
            signup_loginHere.Text = "Login here";
            signup_loginHere.Click += signup_loginHere_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.ControlDarkDark;
            label4.Location = new Point(262, 389);
            label4.Name = "label4";
            label4.Size = new Size(142, 15);
            label4.TabIndex = 7;
            label4.Text = "Already have an account?";
            // 
            // signup_showPassword
            // 
            signup_showPassword.AutoSize = true;
            signup_showPassword.BackColor = Color.Transparent;
            signup_showPassword.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            signup_showPassword.ForeColor = SystemColors.AppWorkspace;
            signup_showPassword.Location = new Point(384, 324);
            signup_showPassword.Margin = new Padding(3, 2, 3, 2);
            signup_showPassword.Name = "signup_showPassword";
            signup_showPassword.Size = new Size(123, 23);
            signup_showPassword.TabIndex = 6;
            signup_showPassword.Text = "Show Password";
            signup_showPassword.UseVisualStyleBackColor = false;
            signup_showPassword.CheckedChanged += signup_showPassword_CheckedChanged;
            // 
            // signup_btn
            // 
            signup_btn.BackColor = Color.MidnightBlue;
            signup_btn.Cursor = Cursors.Hand;
            signup_btn.FlatAppearance.BorderSize = 0;
            signup_btn.ForeColor = Color.White;
            signup_btn.Location = new Point(333, 356);
            signup_btn.Margin = new Padding(3, 2, 3, 2);
            signup_btn.Name = "signup_btn";
            signup_btn.Size = new Size(88, 26);
            signup_btn.TabIndex = 5;
            signup_btn.Text = "SIGNUP";
            signup_btn.UseVisualStyleBackColor = false;
            signup_btn.Click += signup_btn_Click;
            // 
            // signup_username
            // 
            signup_username.Location = new Point(250, 196);
            signup_username.Margin = new Padding(3, 2, 3, 2);
            signup_username.Multiline = true;
            signup_username.Name = "signup_username";
            signup_username.Size = new Size(267, 24);
            signup_username.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(250, 177);
            label3.Name = "label3";
            label3.Size = new Size(76, 19);
            label3.TabIndex = 3;
            label3.Text = "UserName:";
            // 
            // signup_lastName
            // 
            signup_lastName.Location = new Point(250, 142);
            signup_lastName.Margin = new Padding(3, 2, 3, 2);
            signup_lastName.Multiline = true;
            signup_lastName.Name = "signup_lastName";
            signup_lastName.Size = new Size(267, 24);
            signup_lastName.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(250, 123);
            label2.Name = "label2";
            label2.Size = new Size(73, 19);
            label2.TabIndex = 1;
            label2.Text = "LastName:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("MS UI Gothic", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(250, 32);
            label1.Name = "label1";
            label1.Size = new Size(131, 22);
            label1.TabIndex = 0;
            label1.Text = "Get Started";
            // 
            // Signup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(569, 417);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "Signup";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Signup";
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private Label label7;
        private PictureBox pictureBox1;
        private Label label6;
        private Panel panel1;
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
        private TextBox signup_password;
        private Label label9;
        private TextBox signup_email;
        private Label label5;
        private TextBox signup_firstName;
        private Label label8;
    }
}