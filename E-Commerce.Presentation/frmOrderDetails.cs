using E_Commerce.BL.Contracts.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;

namespace E_Commerce.Presentation
{
    public partial class frmOrderDetails : Form
    {
        private readonly int orderId;

        public frmOrderDetails(int orderId)
        {
            InitializeComponent();
            this.orderId = orderId;
            LoadOrderDetails();
        }

        private async void LoadOrderDetails()
        {
            try
            {
                var orderService = ServiceProviderContainer.ServiceProvider.GetRequiredService<IOrderDetailServices>();
                var order = await orderService.GetOrderDetailByIdAsync(orderId);

                if (order != null)
                {
                    lblOrderId.Text = $"Order #{order.OrderId} Details";
                    dataGridViewOrderDetails.DataSource = order;
                    //dataGridViewOrderDetails.DataSource = order.; // تعرض OrderDetails
                }
                else
                {
                    MessageBox.Show("Order not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading order details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }

        private void frmOrderDetails_Load(object sender, EventArgs e)
        {

        }

        private void login_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}