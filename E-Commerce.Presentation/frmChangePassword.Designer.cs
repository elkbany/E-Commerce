namespace E_Commerce.Presentation
{
    partial class frmChangePassword
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
            panel1 = new Panel();
            showPassword = new CheckBox();
            button2 = new Button();
            button1 = new Button();
            panel4 = new Panel();
            lblNewPassword2 = new TextBox();
            panel3 = new Panel();
            lblNewPassword1 = new TextBox();
            panel2 = new Panel();
            lnlOldPassword = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            panel1.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(showPassword);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(446, 389);
            panel1.TabIndex = 1;
            panel1.MouseDown += panel1_MouseDown;
            // 
            // showPassword
            // 
            showPassword.AutoSize = true;
            showPassword.Location = new Point(252, 273);
            showPassword.Name = "showPassword";
            showPassword.Size = new Size(108, 19);
            showPassword.TabIndex = 11;
            showPassword.Text = "Show Password";
            showPassword.UseVisualStyleBackColor = true;
            showPassword.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // button2
            // 
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 12F);
            button2.ForeColor = Color.FromArgb(0, 120, 212);
            button2.Location = new Point(239, 298);
            button2.Name = "button2";
            button2.Size = new Size(159, 49);
            button2.TabIndex = 10;
            button2.Text = "Cancel";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(0, 120, 212);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 12F);
            button1.ForeColor = Color.White;
            button1.Location = new Point(54, 298);
            button1.Name = "button1";
            button1.Size = new Size(159, 49);
            button1.TabIndex = 9;
            button1.Text = "Save";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // panel4
            // 
            panel4.BackColor = SystemColors.ControlLightLight;
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Controls.Add(lblNewPassword2);
            panel4.Location = new Point(54, 222);
            panel4.Name = "panel4";
            panel4.Size = new Size(344, 44);
            panel4.TabIndex = 8;
            // 
            // lblNewPassword2
            // 
            lblNewPassword2.BorderStyle = BorderStyle.None;
            lblNewPassword2.Location = new Point(17, 14);
            lblNewPassword2.Name = "lblNewPassword2";
            lblNewPassword2.PasswordChar = '*';
            lblNewPassword2.PlaceholderText = "Confirm New Password";
            lblNewPassword2.Size = new Size(315, 16);
            lblNewPassword2.TabIndex = 5;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ControlLightLight;
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(lblNewPassword1);
            panel3.Location = new Point(54, 133);
            panel3.Name = "panel3";
            panel3.Size = new Size(344, 44);
            panel3.TabIndex = 7;
            // 
            // lblNewPassword1
            // 
            lblNewPassword1.BorderStyle = BorderStyle.None;
            lblNewPassword1.Location = new Point(17, 14);
            lblNewPassword1.Name = "lblNewPassword1";
            lblNewPassword1.PasswordChar = '*';
            lblNewPassword1.PlaceholderText = "Enter New Password";
            lblNewPassword1.Size = new Size(315, 16);
            lblNewPassword1.TabIndex = 5;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ControlLightLight;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(lnlOldPassword);
            panel2.Location = new Point(54, 48);
            panel2.Name = "panel2";
            panel2.Size = new Size(344, 44);
            panel2.TabIndex = 6;
            // 
            // lnlOldPassword
            // 
            lnlOldPassword.BorderStyle = BorderStyle.None;
            lnlOldPassword.Location = new Point(17, 14);
            lnlOldPassword.Name = "lnlOldPassword";
            lnlOldPassword.PasswordChar = '*';
            lnlOldPassword.PlaceholderText = "Enter Old Password";
            lnlOldPassword.Size = new Size(315, 16);
            lnlOldPassword.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F);
            label3.Location = new Point(54, 105);
            label3.Name = "label3";
            label3.Size = new Size(134, 25);
            label3.TabIndex = 4;
            label3.Text = "New Password";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F);
            label2.Location = new Point(54, 194);
            label2.Name = "label2";
            label2.Size = new Size(164, 25);
            label2.TabIndex = 3;
            label2.Text = "Confirm Password";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F);
            label1.Location = new Point(54, 20);
            label1.Name = "label1";
            label1.Size = new Size(126, 25);
            label1.TabIndex = 2;
            label1.Text = "Old Password";
            label1.Click += label1_Click;
            // 
            // frmChangePassword
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(471, 418);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmChangePassword";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmProfile";
            TopMost = true;
            Load += frmChangePassword_Load;
            MouseDown += frmChangePassword_MouseDown;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox lnlOldPassword;
        private Panel panel2;
        private Panel panel4;
        private TextBox lblNewPassword2;
        private Panel panel3;
        private TextBox lblNewPassword1;
        private Button button2;
        private Button button1;
        private CheckBox showPassword;
    }
}