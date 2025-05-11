namespace E_Commerce.Presentation
{
    partial class Start
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Start));
            pictureBox1 = new PictureBox();
            label4 = new Label();
            label3 = new Label();
            label1 = new Label();
            label2 = new Label();
            login = new Button();
            login_close = new Label();
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
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Bold);
            label4.Location = new Point(144, 219);
            label4.Name = "label4";
            label4.Size = new Size(175, 47);
            label4.TabIndex = 13;
            label4.Text = "TRUSTED";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 25.8000011F);
            label3.Location = new Point(79, 300);
            label3.Name = "label3";
            label3.Size = new Size(190, 47);
            label3.TabIndex = 12;
            label3.Text = "PLATFORM";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 25.8000011F);
            label1.Location = new Point(39, 219);
            label1.Name = "label1";
            label1.Size = new Size(109, 47);
            label1.TabIndex = 10;
            label1.Text = "YOUR";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Bold);
            label2.Location = new Point(49, 255);
            label2.Name = "label2";
            label2.Size = new Size(253, 47);
            label2.TabIndex = 11;
            label2.Text = "E-COMMERCE";
            // 
            // login
            // 
            login.BackColor = Color.FromArgb(0, 120, 212);
            login.Cursor = Cursors.Hand;
            login.FlatAppearance.BorderSize = 0;
            login.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 124, 127);
            login.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 124, 127);
            login.FlatStyle = FlatStyle.Flat;
            login.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            login.ForeColor = Color.White;
            login.Location = new Point(49, 370);
            login.Margin = new Padding(3, 2, 3, 2);
            login.Name = "login";
            login.Size = new Size(234, 50);
            login.TabIndex = 14;
            login.Text = "Get Started";
            login.UseVisualStyleBackColor = false;
            login.Click += login_Click;
            // 
            // login_close
            // 
            login_close.AutoSize = true;
            login_close.Cursor = Cursors.Hand;
            login_close.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            login_close.Location = new Point(1091, 9);
            login_close.Name = "login_close";
            login_close.Size = new Size(18, 20);
            login_close.TabIndex = 15;
            login_close.Text = "X";
            login_close.Click += login_close_Click;
            // 
            // Start
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1121, 593);
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

        #endregion

        private PictureBox pictureBox1;
        private Label label4;
        private Label label3;
        private Label label1;
        private Label label2;
        private Button login;
        private Label login_close;
    }
}