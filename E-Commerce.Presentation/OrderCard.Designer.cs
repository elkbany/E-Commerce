namespace E_Commerce.Presentation
{
    partial class OrderCard
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblOrderId = new Label();
            lblOrderDate = new Label();
            lblTotalAmount = new Label();
            lblStatus = new Label();
            btnDetails = new Button();
            panelCard = new Panel();
            panelCard.SuspendLayout();
            SuspendLayout();
            // 
            // lblOrderId
            // 
            lblOrderId.AutoSize = true;
            lblOrderId.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblOrderId.Location = new Point(10, 10);
            lblOrderId.Name = "lblOrderId";
            lblOrderId.Size = new Size(80, 21);
            lblOrderId.TabIndex = 0;
            lblOrderId.Text = "Order #123";
            // 
            // lblOrderDate
            // 
            lblOrderDate.AutoSize = true;
            lblOrderDate.Font = new Font("Segoe UI", 10F);
            lblOrderDate.Location = new Point(10, 40);
            lblOrderDate.Name = "lblOrderDate";
            lblOrderDate.Size = new Size(90, 19);
            lblOrderDate.TabIndex = 1;
            lblOrderDate.Text = "Date: 01/01/2025";
            // 
            // lblTotalAmount
            // 
            lblTotalAmount.AutoSize = true;
            lblTotalAmount.Font = new Font("Segoe UI", 10F);
            lblTotalAmount.Location = new Point(10, 65);
            lblTotalAmount.Name = "lblTotalAmount";
            lblTotalAmount.Size = new Size(90, 19);
            lblTotalAmount.TabIndex = 2;
            lblTotalAmount.Text = "Total: $100.00";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 10F);
            lblStatus.ForeColor = Color.Green;
            lblStatus.Location = new Point(10, 90);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(90, 19);
            lblStatus.TabIndex = 3;
            lblStatus.Text = "Status: Delivered";
            // 
            // btnDetails
            // 
            btnDetails.BackColor = Color.FromArgb(0, 120, 212);
            btnDetails.FlatStyle = FlatStyle.Flat;
            btnDetails.Font = new Font("Segoe UI", 10F);
            btnDetails.ForeColor = Color.White;
            btnDetails.Location = new Point(200, 90);
            btnDetails.Name = "btnDetails";
            btnDetails.Size = new Size(100, 30);
            btnDetails.TabIndex = 4;
            btnDetails.Text = "Details";
            btnDetails.UseVisualStyleBackColor = false;
            btnDetails.Click += btnDetails_Click;
            // 
            // panelCard
            // 
            panelCard.BackColor = Color.FromArgb(245, 245, 245);
            panelCard.BorderStyle = BorderStyle.FixedSingle;
            panelCard.Controls.Add(btnDetails);
            panelCard.Controls.Add(lblStatus);
            panelCard.Controls.Add(lblTotalAmount);
            panelCard.Controls.Add(lblOrderDate);
            panelCard.Controls.Add(lblOrderId);
            panelCard.Location = new Point(0, 0);
            panelCard.Name = "panelCard";
            panelCard.Size = new Size(310, 130);
            panelCard.TabIndex = 5;
            panelCard.Padding = new Padding(10); // أضف Padding
            // 
            // OrderCard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panelCard);
            Name = "OrderCard";
            Size = new Size(310, 130);
            panelCard.ResumeLayout(false);
            panelCard.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblOrderId;
        private Label lblOrderDate;
        private Label lblTotalAmount;
        private Label lblStatus;
        private Button btnDetails;
        private Panel panelCard;
    }
}