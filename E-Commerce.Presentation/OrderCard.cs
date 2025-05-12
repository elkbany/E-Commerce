using System;
using System.Windows.Forms;
using System.ComponentModel;

namespace E_Commerce.Presentation
{
    public partial class OrderCard : UserControl
    {
        private int orderId;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int OrderId
        {
            get => orderId;
            set => orderId = value;
        }

        public OrderCard()
        {
            InitializeComponent();
        }

        public void SetOrderData(int orderId, DateTime orderDate, decimal totalAmount, string status)
        {
            OrderId = orderId;
            lblOrderId.Text = $"Order #{orderId}";
            lblOrderDate.Text = $"Date: {orderDate:dd/MM/yyyy}";
            lblTotalAmount.Text = $"Total: ${totalAmount:F2}";
            lblStatus.Text = $"Status: {status}";
            lblStatus.ForeColor = status.ToLower() == "delivered" ? Color.Green :
                                 status.ToLower() == "pending" ? Color.Orange :
                                 status.ToLower() == "approved" ? Color.Blue : Color.Red;
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            var orderDetailsForm = new frmOrderDetails(OrderId);
            orderDetailsForm.ShowDialog();
        }
    }
}