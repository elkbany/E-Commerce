namespace E_Commerce.Presentation
{
    partial class frmCart
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            flowLayoutPanelCart = new FlowLayoutPanel();
            lblTitle = new Label();
            lblNoItems = new Label();
            panelSummary = new Panel();
            lblTotalLabel = new Label();
            lblTotal = new Label();
            btnCheckout = new Guna.UI2.WinForms.Guna2Button();
            panelSummary.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanelCart
            // 
            flowLayoutPanelCart.AutoScroll = true;
            flowLayoutPanelCart.Location = new Point(12, 50);
            flowLayoutPanelCart.Name = "flowLayoutPanelCart";
            flowLayoutPanelCart.Size = new Size(776, 400);
            flowLayoutPanelCart.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.Location = new Point(12, 10);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(110, 30);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Your Cart";
            // 
            // lblNoItems
            // 
            lblNoItems.AutoSize = true;
            lblNoItems.Font = new Font("Segoe UI", 12F);
            lblNoItems.ForeColor = Color.Gray;
            lblNoItems.Location = new Point(12, 80);
            lblNoItems.Name = "lblNoItems";
            lblNoItems.Size = new Size(138, 21);
            lblNoItems.TabIndex = 2;
            lblNoItems.Text = "Your cart is empty.";
            lblNoItems.Visible = false;
            // 
            // panelSummary
            // 
            panelSummary.BackColor = Color.FromArgb(240, 240, 240);
            panelSummary.Controls.Add(lblTotalLabel);
            panelSummary.Controls.Add(lblTotal);
            panelSummary.Controls.Add(btnCheckout);
            panelSummary.Location = new Point(12, 460);
            panelSummary.Name = "panelSummary";
            panelSummary.Size = new Size(776, 80);
            panelSummary.TabIndex = 3;
            // 
            // lblTotalLabel
            // 
            lblTotalLabel.AutoSize = true;
            lblTotalLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTotalLabel.Location = new Point(10, 25);
            lblTotalLabel.Name = "lblTotalLabel";
            lblTotalLabel.Size = new Size(52, 21);
            lblTotalLabel.TabIndex = 0;
            lblTotalLabel.Text = "Total:";
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTotal.Location = new Point(70, 25);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(50, 21);
            lblTotal.TabIndex = 1;
            lblTotal.Text = "$0.00";
            // 
            // btnCheckout
            // 
            btnCheckout.AutoRoundedCorners = true;
            btnCheckout.BorderRadius = 15;
            btnCheckout.CustomizableEdges = customizableEdges1;
            btnCheckout.FillColor = Color.FromArgb(0, 120, 212);
            btnCheckout.Font = new Font("Segoe UI", 12F);
            btnCheckout.ForeColor = Color.White;
            btnCheckout.Location = new Point(576, 15);
            btnCheckout.Name = "btnCheckout";
            btnCheckout.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnCheckout.Size = new Size(180, 45);
            btnCheckout.TabIndex = 2;
            btnCheckout.Text = "Proceed to Checkout";
            btnCheckout.Click += btnCheckout_Click;
            // 
            // frmCart
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(800, 550);
            Controls.Add(panelSummary);
            Controls.Add(lblNoItems);
            Controls.Add(lblTitle);
            Controls.Add(flowLayoutPanelCart);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmCart";
            Text = "Shopping Cart";
            panelSummary.ResumeLayout(false);
            panelSummary.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelCart;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblNoItems;
        private System.Windows.Forms.Panel panelSummary;
        private System.Windows.Forms.Label lblTotalLabel;
        private System.Windows.Forms.Label lblTotal;
        private Guna.UI2.WinForms.Guna2Button btnCheckout;
    }
}