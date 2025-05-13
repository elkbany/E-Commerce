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
            try
            {
                // Fetch order details using GetOrderDetailsByOrderIdAsync
                var orderDetails = await _orderDetailServices.GetOrderDetailsByOrderIdAsync(orderId);

                if (orderDetails != null && orderDetails.Any())
                {
                    lblOrderId.Text = $"Order #{orderId} Details";
                    dataGridViewOrderDetails.DataSource = orderDetails;

                    // Customize column headers
                    dataGridViewOrderDetails.Columns["OrderId"].Visible = false; // Hide OrderId column
                    dataGridViewOrderDetails.Columns["ProductId"].Visible = false; // Hide ProductId column
                    dataGridViewOrderDetails.Columns["ProductName"].HeaderText = "Product Name";
                    dataGridViewOrderDetails.Columns["Quantity"].HeaderText = "Quantity";
                    dataGridViewOrderDetails.Columns["Price"].HeaderText = "Unit Price";
                    dataGridViewOrderDetails.Columns["TotalPrice"].HeaderText = "Total Price";

                    // Calculate and display total price for the order
                    decimal totalOrderPrice = orderDetails.Sum(od => od.TotalPrice);
                    Label totalLabel = new Label
                    {
                        Text = $"Total Order Price: ${totalOrderPrice:F2}",
                        Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                        Location = new Point(12, 460), // Adjust location below the DataGridView
                        AutoSize = true
                    };
                    Controls.Add(totalLabel);
                }
                else
                {
                    lblOrderId.Text = $"Order #{orderId} Details";
                    dataGridViewOrderDetails.DataSource = null;
                    MessageBox.Show("No order details found for this order.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading order details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmOrderDetails_Load(object sender, EventArgs e)
        {
            // No additional logic needed here
        }

        private void login_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridViewOrderDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // No additional logic needed here unless you want to add functionality
        }
    }
}