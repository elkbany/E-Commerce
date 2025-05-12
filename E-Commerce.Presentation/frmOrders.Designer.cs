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
            flowLayoutPanelOrders = new FlowLayoutPanel();
            lblTitle = new Label();
            lblNoOrders = new Label();
            comboBoxStatusFilter = new ComboBox();
            SuspendLayout();
            // 
            // flowLayoutPanelOrders
            // 
            flowLayoutPanelOrders.AutoScroll = true;
            flowLayoutPanelOrders.Location = new Point(12, 80);
            flowLayoutPanelOrders.Name = "flowLayoutPanelOrders";
            flowLayoutPanelOrders.Size = new Size(776, 470);
            flowLayoutPanelOrders.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.Location = new Point(12, 10);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(80, 30);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Your Orders";
            // 
            // lblNoOrders
            // 
            lblNoOrders.AutoSize = true;
            lblNoOrders.Font = new Font("Segoe UI", 12F);
            lblNoOrders.ForeColor = Color.Gray;
            lblNoOrders.Location = new Point(12, 110);
            lblNoOrders.Name = "lblNoOrders";
            lblNoOrders.Size = new Size(90, 21);
            lblNoOrders.TabIndex = 2;
            lblNoOrders.Text = "No orders found.";
            lblNoOrders.Visible = false;
            // 
            // comboBoxStatusFilter
            // 
            comboBoxStatusFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxStatusFilter.Font = new Font("Segoe UI", 10F);
            comboBoxStatusFilter.Items.AddRange(new object[] { "All", "Pending", "Approved", "Denied", "Shipped" });
            comboBoxStatusFilter.Location = new Point(600, 10);
            comboBoxStatusFilter.Name = "comboBoxStatusFilter";
            comboBoxStatusFilter.Size = new Size(188, 26);
            comboBoxStatusFilter.TabIndex = 3;
            comboBoxStatusFilter.SelectedIndex = 0; // Default: All
            comboBoxStatusFilter.SelectedIndexChanged += comboBoxStatusFilter_SelectedIndexChanged;
            // 
            // frmOrders
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(800, 600);
            Controls.Add(comboBoxStatusFilter);
            Controls.Add(lblNoOrders);
            Controls.Add(lblTitle);
            Controls.Add(flowLayoutPanelOrders);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmOrders";
            Text = "frmOrders";
            ResumeLayout(false);
            PerformLayout();
        }

        private FlowLayoutPanel flowLayoutPanelOrders;
        private Label lblTitle;
        private Label lblNoOrders;
        private ComboBox comboBoxStatusFilter;
    }
}