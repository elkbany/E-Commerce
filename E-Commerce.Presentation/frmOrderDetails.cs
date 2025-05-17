using E_Commerce.BL.Contracts.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Windows.Forms;

namespace E_Commerce.Presentation
{
    public partial class frmOrderDetails : Form
    {
        private readonly int _orderId;
        private readonly IOrderDetailServices _orderDetailServices;

        public frmOrderDetails(int orderId)
        {
            InitializeComponent();
            _orderId = orderId;
            _orderDetailServices = ServiceProviderContainer.ServiceProvider.GetRequiredService<IOrderDetailServices>();
            LoadOrderDetails();
        }

        private async void LoadOrderDetails()
        {
            try
            {
                var orderDetails = await _orderDetailServices.GetOrderDetailsByOrderIdAsync(_orderId);

                if (orderDetails != null && orderDetails.Any())
                {
                    lblOrderId.Text = $"Order #{_orderId} Details";

                    
                    dataGridViewOrderDetails.Columns.Clear(); 
                    dataGridViewOrderDetails.Columns.Add("IndexColumn", "#");
                    dataGridViewOrderDetails.Columns["IndexColumn"].Width = 50;

                   
                    dataGridViewOrderDetails.Columns.Add("ProductName", "Product Name");
                    dataGridViewOrderDetails.Columns.Add("Quantity", "Quantity");
                    dataGridViewOrderDetails.Columns.Add("Price", "Unit Price");
                    dataGridViewOrderDetails.Columns.Add("TotalPrice", "Total Price");

                    int index = 1;
                    foreach (var detail in orderDetails)
                    {
                        dataGridViewOrderDetails.Rows.Add(index++, detail.ProductName, detail.Quantity, detail.Price, detail.TotalPrice);
                    }

                   
                    if (dataGridViewOrderDetails.Columns.Contains("Id"))
                        dataGridViewOrderDetails.Columns["Id"].Visible = false;
                    if (dataGridViewOrderDetails.Columns.Contains("OrderId"))
                        dataGridViewOrderDetails.Columns["OrderId"].Visible = false;
                    if (dataGridViewOrderDetails.Columns.Contains("ProductId"))
                        dataGridViewOrderDetails.Columns["ProductId"].Visible = false;

                    
                    decimal totalOrderPrice = orderDetails.Sum(od => od.TotalPrice);
                    Label totalLabel = new Label
                    {
                        Text = $"Total Order Price: ${totalOrderPrice:F2}",
                        Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                        Location = new Point(12, 460),
                        AutoSize = true
                    };
                    Controls.Add(totalLabel);
                }
                else
                {
                    lblOrderId.Text = $"Order #{_orderId} Details";
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
          
        }

        private void login_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridViewOrderDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }
    }
}