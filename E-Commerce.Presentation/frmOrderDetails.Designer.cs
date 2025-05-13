namespace E_Commerce.Presentation
{
    partial class frmOrderDetails
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            dataGridViewOrderDetails = new DataGridView();
            lblOrderId = new Label();
            btnClose = new Guna.UI2.WinForms.Guna2Button();
            login_close = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewOrderDetails).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewOrderDetails
            // 
            dataGridViewOrderDetails.AllowUserToAddRows = false;
            dataGridViewOrderDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewOrderDetails.BackgroundColor = Color.White;
            dataGridViewOrderDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewOrderDetails.Location = new Point(12, 50);
            dataGridViewOrderDetails.Name = "dataGridViewOrderDetails";
            dataGridViewOrderDetails.ReadOnly = true;
            dataGridViewOrderDetails.Size = new Size(776, 400);
            dataGridViewOrderDetails.TabIndex = 0;
            // 
            // lblOrderId
            // 
            lblOrderId.AutoSize = true;
            lblOrderId.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblOrderId.Location = new Point(12, 10);
            lblOrderId.Name = "lblOrderId";
            lblOrderId.Size = new Size(177, 25);
            lblOrderId.TabIndex = 1;
            lblOrderId.Text = "Order #123 Details";
            // 
            // btnClose
            // 
            btnClose.AutoRoundedCorners = true;
            btnClose.BorderRadius = 21;
            btnClose.CustomizableEdges = customizableEdges3;
            btnClose.DisabledState.BorderColor = Color.DarkGray;
            btnClose.DisabledState.CustomBorderColor = Color.DarkGray;
            btnClose.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnClose.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnClose.FillColor = Color.FromArgb(0, 120, 212);
            btnClose.Font = new Font("Segoe UI", 9F);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(293, 472);
            btnClose.Name = "btnClose";
            btnClose.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnClose.Size = new Size(180, 45);
            btnClose.TabIndex = 2;
            btnClose.Text = "Close";
            btnClose.Click += btnClose_Click;
            // 
            // login_close
            // 
            login_close.AutoSize = true;
            login_close.Cursor = Cursors.Hand;
            login_close.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            login_close.Location = new Point(770, 15);
            login_close.Name = "login_close";
            login_close.Size = new Size(18, 20);
            login_close.TabIndex = 16;
            login_close.Text = "X";
            login_close.Click += login_close_Click;
            // 
            // frmOrderDetails
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(800, 529);
            Controls.Add(login_close);
            Controls.Add(btnClose);
            Controls.Add(lblOrderId);
            Controls.Add(dataGridViewOrderDetails);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmOrderDetails";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Order Details";
            Load += frmOrderDetails_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewOrderDetails).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewOrderDetails;
        private Label lblOrderId;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private Label login_close;
    }
}