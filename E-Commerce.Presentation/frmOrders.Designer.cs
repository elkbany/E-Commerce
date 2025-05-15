namespace E_Commerce.Presentation
{
    partial class frmOrders
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
            lblTitle = new Label();
            lblNoOrders = new Label();
            comboBoxStatusFilter = new ComboBox();
            panel1 = new Panel();
            flowLayoutPanelOrders = new FlowLayoutPanel();
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
            lblTitle.Size = new Size(156, 40);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Your Orders";
            // 
            // lblNoOrders
            // 
            lblNoOrders.Anchor = AnchorStyles.None;
            lblNoOrders.AutoSize = true;
            lblNoOrders.Font = new Font("Segoe UI", 12F);
            lblNoOrders.ForeColor = Color.Gray;
            lblNoOrders.Location = new Point(404, 11);
            lblNoOrders.Name = "lblNoOrders";
            lblNoOrders.Size = new Size(128, 21);
            lblNoOrders.TabIndex = 2;
            lblNoOrders.Text = "No orders found.";
            lblNoOrders.Visible = false;
            // 
            // comboBoxStatusFilter
            // 
            comboBoxStatusFilter.Anchor = AnchorStyles.None;
            comboBoxStatusFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxStatusFilter.Font = new Font("Segoe UI", 10F);
            comboBoxStatusFilter.Items.AddRange(new object[] { "All", "Pending", "Approved", "Denied", "Shipped" });
            comboBoxStatusFilter.Location = new Point(828, 11);
            comboBoxStatusFilter.Name = "comboBoxStatusFilter";
            comboBoxStatusFilter.Size = new Size(259, 25);
            comboBoxStatusFilter.TabIndex = 3;
            comboBoxStatusFilter.SelectedIndexChanged += comboBoxStatusFilter_SelectedIndexChanged;
            // 
            // panel1
            // 
            panel1.Controls.Add(lblTitle);
            panel1.Controls.Add(comboBoxStatusFilter);
            panel1.Controls.Add(lblNoOrders);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1214, 47);
            panel1.TabIndex = 4;
            // 
            // flowLayoutPanelOrders
            // 
            flowLayoutPanelOrders.Dock = DockStyle.Fill;
            flowLayoutPanelOrders.Location = new Point(0, 47);
            flowLayoutPanelOrders.Name = "flowLayoutPanelOrders";
            flowLayoutPanelOrders.Padding = new Padding(20, 0, 0, 0);
            flowLayoutPanelOrders.Size = new Size(1214, 634);
            flowLayoutPanelOrders.TabIndex = 5;
            // 
            // frmOrders
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.White;
            ClientSize = new Size(1214, 681);
            Controls.Add(flowLayoutPanelOrders);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmOrders";
            Text = "frmOrders";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        private Label lblTitle;
        private Label lblNoOrders;
        private ComboBox comboBoxStatusFilter;
        private Panel panel1;
        private FlowLayoutPanel flowLayoutPanelOrders;
    }
}