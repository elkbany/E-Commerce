namespace E_Commerce.Presentation
{
    partial class frmProfile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProfile));
            pictureBox1 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            panel2 = new Panel();
            lnlOldPassword = new TextBox();
            panel3 = new Panel();
            lblNewPassword1 = new TextBox();
            panel4 = new Panel();
            lblNewPassword2 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            panel1 = new Panel();
            button3 = new Button();
            panel5 = new Panel();
            textBox1 = new TextBox();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel1.SuspendLayout();
            panel5.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(58, 156);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(254, 252);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(54, 20);
            label1.Name = "label1";
            label1.Size = new Size(102, 25);
            label1.TabIndex = 2;
            label1.Text = "First Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(54, 190);
            label2.Name = "label2";
            label2.Size = new Size(58, 25);
            label2.TabIndex = 3;
            label2.Text = "Email";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(54, 105);
            label3.Name = "label3";
            label3.Size = new Size(100, 25);
            label3.TabIndex = 4;
            label3.Text = "Last Name";
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
            // panel4
            // 
            panel4.BackColor = SystemColors.ControlLightLight;
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Controls.Add(lblNewPassword2);
            panel4.Location = new Point(54, 218);
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
            // button1
            // 
            button1.BackColor = Color.FromArgb(0, 120, 212);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 12F);
            button1.ForeColor = Color.White;
            button1.Location = new Point(54, 399);
            button1.Name = "button1";
            button1.Size = new Size(159, 49);
            button1.TabIndex = 9;
            button1.Text = "Save";
            button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 12F);
            button2.ForeColor = Color.FromArgb(0, 120, 212);
            button2.Location = new Point(239, 399);
            button2.Name = "button2";
            button2.Size = new Size(159, 49);
            button2.TabIndex = 10;
            button2.Text = "Cancel";
            button2.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(button3);
            panel1.Controls.Add(panel5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(350, 58);
            panel1.Name = "panel1";
            panel1.Size = new Size(735, 474);
            panel1.TabIndex = 1;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(0, 120, 212);
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Segoe UI", 12F);
            button3.ForeColor = Color.White;
            button3.Location = new Point(404, 311);
            button3.Name = "button3";
            button3.Size = new Size(170, 44);
            button3.TabIndex = 11;
            button3.Text = "Change Password";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // panel5
            // 
            panel5.BackColor = SystemColors.ControlLightLight;
            panel5.BorderStyle = BorderStyle.FixedSingle;
            panel5.Controls.Add(textBox1);
            panel5.Location = new Point(54, 311);
            panel5.Name = "panel5";
            panel5.Size = new Size(344, 44);
            panel5.TabIndex = 10;
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Location = new Point(17, 14);
            textBox1.Name = "textBox1";
            textBox1.PasswordChar = '*';
            textBox1.PlaceholderText = "******************";
            textBox1.Size = new Size(315, 16);
            textBox1.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(54, 283);
            label4.Name = "label4";
            label4.Size = new Size(91, 25);
            label4.TabIndex = 9;
            label4.Text = "Password";
            // 
            // frmProfile
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1229, 618);
            Controls.Add(panel1);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmProfile";
            Text = "frmProfile";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Panel panel2;
        private TextBox lnlOldPassword;
        private Panel panel3;
        private TextBox lblNewPassword1;
        private Panel panel4;
        private TextBox lblNewPassword2;
        private Button button1;
        private Button button2;
        private Panel panel1;
        private Button button3;
        private Panel panel5;
        private TextBox textBox1;
        private Label label4;
    }
}