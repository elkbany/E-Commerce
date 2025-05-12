using E_Commerce.BL.Contracts.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;

namespace E_Commerce.Presentation
{
    public partial class frmOrderDetails : Form
    {
        private readonly int orderId;
        private readonly IOrderDetailServices _orderDetailServices;

        public frmOrderDetails(int orderId)
        {
            InitializeComponent();
            this.orderId = orderId;
            _orderDetailServices = ServiceProviderContainer.ServiceProvider.GetRequiredService<IOrderDetailServices>();
            LoadOrderDetails();
        }

        private async void LoadOrderDetails()
        {
            
                // Fetch order details using the new method
                var orderDetails = await _orderDetailServices.GetOrderDetailsByOrderIdAsync(orderId);

                if (orderDetails != null && orderDetails.Any())
                {
                    lblOrderId.Text = $"Order #{orderId} Details";
                    dataGridViewOrderDetails.DataSource = orderDetails.ToList();

                    // Customize column headers
                    dataGridViewOrderDetails.Columns["Id"].Visible = false; // Hide Id column
                    dataGridViewOrderDetails.Columns["OrderId"].Visible = false; // Hide OrderId column
                    dataGridViewOrderDetails.Columns["ProductId"].Visible = false; // Hide ProductId column
                    dataGridViewOrderDetails.Columns["ProductName"].HeaderText = "Product Name";
                    dataGridViewOrderDetails.Columns["Quantity"].HeaderText = "Quantity";
                    dataGridViewOrderDetails.Columns["Price"].HeaderText = "Unit Price";
                    dataGridViewOrderDetails.Columns["TotalPrice"].HeaderText = "Total Price";
                }
                else
                {
                    MessageBox.Show("No order details found for this order.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridViewOrderDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}