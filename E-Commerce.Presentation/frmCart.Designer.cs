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
            lblTitle = new Label();
            lblNoItems = new Label();
            panelSummary = new Panel();
            btnCheckout = new Guna.UI2.WinForms.Guna2Button();
            panel2 = new Panel();
            lblTotalLabel = new Label();
            lblTotal = new Label();
            panel1 = new Panel();
            flowLayoutPanelCart = new FlowLayoutPanel();
            panelSummary.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Dock = DockStyle.Left;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.Location = new Point(0, 0);
            lblTitle.Margin = new Padding(0);
            lblTitle.Name = "lblTitle";
            lblTitle.Padding = new Padding(20, 10, 0, 0);
            lblTitle.Size = new Size(130, 40);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Your Cart";
            // 
            // lblNoItems
            // 
            lblNoItems.AutoSize = true;
            lblNoItems.Font = new Font("Segoe UI", 12F);
            lblNoItems.ForeColor = Color.Gray;
            lblNoItems.Location = new Point(442, 14);
            lblNoItems.Name = "lblNoItems";
            lblNoItems.Size = new Size(138, 21);
            lblNoItems.TabIndex = 2;
            lblNoItems.Text = "Your cart is empty.";
            lblNoItems.Visible = false;
            // 
            // panelSummary
            // 
            panelSummary.BackColor = Color.White;
            panelSummary.Controls.Add(btnCheckout);
            panelSummary.Controls.Add(panel2);
            panelSummary.Dock = DockStyle.Bottom;
            panelSummary.Location = new Point(0, 535);
            panelSummary.Name = "panelSummary";
            panelSummary.Padding = new Padding(0, 0, 0, 50);
            panelSummary.Size = new Size(1071, 69);
            panelSummary.TabIndex = 3;
            // 
            // btnCheckout
            // 
            btnCheckout.Anchor = AnchorStyles.None;
            btnCheckout.AutoRoundedCorners = true;
            btnCheckout.BorderRadius = 15;
            btnCheckout.CustomizableEdges = customizableEdges1;
            btnCheckout.FillColor = Color.FromArgb(0, 120, 212);
            btnCheckout.Font = new Font("Segoe UI", 12F);
            btnCheckout.ForeColor = Color.White;
            btnCheckout.Location = new Point(809, 12);
            btnCheckout.Name = "btnCheckout";
            btnCheckout.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnCheckout.Size = new Size(180, 45);
            btnCheckout.TabIndex = 2;
            btnCheckout.Text = "Proceed to Checkout";
            btnCheckout.Click += btnCheckout_Click;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.None;
            panel2.Controls.Add(lblTotalLabel);
            panel2.Controls.Add(lblTotal);
            panel2.Location = new Point(40, 23);
            panel2.Name = "panel2";
            panel2.Size = new Size(156, 24);
            panel2.TabIndex = 3;
            // 
            // lblTotalLabel
            // 
            lblTotalLabel.AutoSize = true;
            lblTotalLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTotalLabel.Location = new Point(13, 1);
            lblTotalLabel.Name = "lblTotalLabel";
            lblTotalLabel.Size = new Size(52, 21);
            lblTotalLabel.TabIndex = 0;
            lblTotalLabel.Text = "Total:";
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTotal.Location = new Point(71, 1);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(50, 21);
            lblTotal.TabIndex = 1;
            lblTotal.Text = "$0.00";
            // 
            // panel1
            // 
            panel1.Controls.Add(lblNoItems);
            panel1.Controls.Add(lblTitle);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1071, 47);
            panel1.TabIndex = 4;
            // 
            // flowLayoutPanelCart
            // 
            flowLayoutPanelCart.AutoScroll = true;
            flowLayoutPanelCart.Dock = DockStyle.Fill;
            flowLayoutPanelCart.Location = new Point(0, 47);
            flowLayoutPanelCart.Name = "flowLayoutPanelCart";
            flowLayoutPanelCart.Padding = new Padding(20, 0, 0, 0);
            flowLayoutPanelCart.Size = new Size(1071, 488);
            flowLayoutPanelCart.TabIndex = 5;
            // 
            // frmCart
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1071, 604);
            Controls.Add(flowLayoutPanelCart);
            Controls.Add(panel1);
            Controls.Add(panelSummary);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmCart";
            Text = "Shopping Cart";
            panelSummary.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblNoItems;
        private System.Windows.Forms.Panel panelSummary;
        private System.Windows.Forms.Label lblTotalLabel;
        private System.Windows.Forms.Label lblTotal;
        private Guna.UI2.WinForms.Guna2Button btnCheckout;
        private Panel panel1;
        private FlowLayoutPanel flowLayoutPanelCart;
        private Panel panel2;
    }
}