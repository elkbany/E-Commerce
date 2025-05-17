using E_Commerce.BL.Contracts.Services;
using E_Commerce.BL.Features.Order.DTOs;
using E_Commerce.Domain.Enums;
using System;
using System.Linq;
using System.Windows.Forms;

namespace E_Commerce.Presentation
{
    public partial class frmOrders : Form
    {
        private readonly IOrderServices _orderServices;
        private readonly int _userId;

        public frmOrders(IOrderServices orderServices, int userId)
        {
            InitializeComponent();
            _orderServices = orderServices;
            _userId = userId;
            LoadOrders();
        }

        private async void LoadOrders(string statusFilter = "All")
        {
            try
            {
                IEnumerable<OrderDTO> orders;

                if (statusFilter == "All")
                {
                    orders = await _orderServices.GetOrdersByUserId(_userId);
                }
                else
                {
                    var status = (OrderStatus)Enum.Parse(typeof(OrderStatus), statusFilter);
                    orders = await _orderServices.GetOrdersByUserId(_userId);
                    orders = orders.Where(o => o.Status == status);
                }

                flowLayoutPanelOrders.Controls.Clear();

                if (orders != null && orders.Any())
                {
                    lblNoOrders.Visible = false;
                    foreach (var order in orders)
                    {
                        var orderCard = new OrderCard();
                        orderCard.SetOrderData(order.OrderID, order.OrderDate, order.TotalAmount, order.Status.ToString());
                        flowLayoutPanelOrders.Controls.Add(orderCard);
                    }
                }
                else
                {
                    lblNoOrders.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading orders: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBoxStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedStatus = comboBoxStatusFilter.SelectedItem.ToString();
            LoadOrders(selectedStatus);
        }

        private void flowLayoutPanelOrders_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanelOrders_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}