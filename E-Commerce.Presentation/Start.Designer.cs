namespace E_Commerce.Presentation
{
    partial class Start
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

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Start));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pictureBox1 = new PictureBox();
            label1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            label2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            label3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            label4 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            login = new Guna.UI2.WinForms.Guna2Button();
            login_close = new Guna.UI2.WinForms.Guna2HtmlLabel();
            label5 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            signupHere = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(399, 29);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(627, 534);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 25.8000011F);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(39, 219);
            label1.Name = "label1";
            label1.Size = new Size(91, 48);
            label1.TabIndex = 10;
            label1.Text = "YOUR";
            // 
            // label2
            // 
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Bold);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(49, 255);
            label2.Name = "label2";
            label2.Size = new Size(227, 48);
            label2.TabIndex = 11;
            label2.Text = "E-COMMERCE";
            // 
            // label3
            // 
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 25.8000011F);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(79, 300);
            label3.Name = "label3";
            label3.Size = new Size(172, 48);
            label3.TabIndex = 12;
            label3.Text = "PLATFORM";
            // 
            // label4
            // 
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Bold);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(144, 219);
            label4.Name = "label4";
            label4.Size = new Size(152, 48);
            label4.TabIndex = 13;
            label4.Text = "TRUSTED";
            // 
            // login
            // 
            login.AutoRoundedCorners = true;
            login.BorderRadius = 24;
            login.CustomizableEdges = customizableEdges1;
            login.FillColor = Color.FromArgb(0, 120, 212);
            login.Font = new Font("Segoe UI", 12F);
            login.ForeColor = Color.White;
            login.Location = new Point(49, 370);
            login.Name = "login";
            login.ShadowDecoration.CustomizableEdges = customizableEdges2;
            login.Size = new Size(234, 50);
            login.TabIndex = 14;
            login.Text = "Get Started";
            login.Click += login_Click;
            // 
            // login_close
            // 
            login_close.BackColor = Color.Transparent;
            login_close.Cursor = Cursors.Hand;
            login_close.Font = new Font("Segoe UI", 10.8F);
            login_close.ForeColor = Color.Black;
            login_close.Location = new Point(1091, 9);
            login_close.Name = "login_close";
            login_close.Size = new Size(11, 21);
            login_close.TabIndex = 15;
            login_close.Text = "X";
            login_close.Click += login_close_Click;
            // 
            // label5
            // 
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI", 9F);
            label5.ForeColor = SystemColors.ControlDarkDark;
            label5.Location = new Point(49, 430);
            label5.Name = "label5";
            label5.Size = new Size(127, 17);
            label5.TabIndex = 16;
            label5.Text = "Don't have an account?";
            // 
            // signupHere
            // 
            signupHere.BackColor = Color.Transparent;
            signupHere.Cursor = Cursors.Hand;
            signupHere.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            signupHere.ForeColor = Color.FromArgb(0, 120, 212);
            signupHere.IsSelectionEnabled = false;
            signupHere.Location = new Point(197, 430);
            signupHere.Name = "signupHere";
            signupHere.Size = new Size(73, 17);
            signupHere.TabIndex = 17;
            signupHere.Text = "Sign up here";
            signupHere.Click += signupHere_Click;
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
            // Start
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1121, 593);
            Controls.Add(signupHere);
            Controls.Add(label5);
            Controls.Add(login_close);
            Controls.Add(login);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Start";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Start";
            MouseDown += Start_MouseDown;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2HtmlLabel label1;
        private Guna.UI2.WinForms.Guna2HtmlLabel label2;
        private Guna.UI2.WinForms.Guna2HtmlLabel label3;
        private Guna.UI2.WinForms.Guna2HtmlLabel label4;
        private Guna.UI2.WinForms.Guna2Button login;
        private Guna.UI2.WinForms.Guna2HtmlLabel login_close;
        private Guna.UI2.WinForms.Guna2HtmlLabel label5;
        private Guna.UI2.WinForms.Guna2HtmlLabel signupHere;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
    }
}