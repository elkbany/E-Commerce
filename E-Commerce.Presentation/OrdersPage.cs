using E_Commerce.BL.Contracts.Services;
using E_Commerce.BL.Features.Order.DTOs;
using E_Commerce.Domain.Enums;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace E_Commerce.Presentation
{
    public partial class OrdersPage : UserControl
    {
        private readonly IOrderServices _orderServices;
        private readonly IOrderDetailServices _orderDetailServices;
        private readonly IProductServices _productServices;

        public FlowLayoutPanel flowLayoutPanelOrders;
        private ComboBox comboBoxStatusFilter;

        public OrdersPage()
        {
            InitializeComponent();

            _orderServices = ServiceProviderContainer.ServiceProvider.GetRequiredService<IOrderServices>();
            _orderDetailServices = ServiceProviderContainer.ServiceProvider.GetRequiredService<IOrderDetailServices>();
            _productServices = ServiceProviderContainer.ServiceProvider.GetRequiredService<IProductServices>();

            // إعداد ComboBox للفلتر
            comboBoxStatusFilter = new ComboBox
            {
                Location = new Point(270, 60), // تحت panel1
                Size = new Size(200, 30),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            comboBoxStatusFilter.Items.AddRange(new string[] { "All", "Pending", "Approved", "Denied", "Shipped" });
            comboBoxStatusFilter.SelectedIndex = 0;
            comboBoxStatusFilter.SelectedIndexChanged += ComboBoxStatusFilter_SelectedIndexChanged;
            Controls.Add(comboBoxStatusFilter);

            // إعداد FlowLayoutPanel
            flowLayoutPanelOrders = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                Padding = new Padding(0, 100, 0, 0) // مكان للـ ComboBox
            };
            Controls.Add(flowLayoutPanelOrders);

            LoadOrders();
        }

        private async void LoadOrders(string statusFilter = "All")
        {
            try
            {
                IEnumerable<OrderDTO> orders;

                if (statusFilter == "All")
                {
                    orders = await _orderServices.GetAllOrdersAsync();
                }
                else
                {
                    var status = (OrderStatus)Enum.Parse(typeof(OrderStatus), statusFilter);
                    orders = await _orderServices.FilterOrdersByStatusAsync(status);
                }

                flowLayoutPanelOrders.Controls.Clear();

                if (orders != null && orders.Any())
                {
                    int index = 1;
                    foreach (var order in orders)
                    {
                        AddOrderToPanel(order, index++);
                    }
                }
                else
                {
                    Label lblNoOrders = new Label
                    {
                        Text = "No orders found.",
                        Location = new Point(20, 100),
                        Size = new Size(200, 20),
                        Font = new Font("Segoe UI", 10)
                    };
                    flowLayoutPanelOrders.Controls.Add(lblNoOrders);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading orders: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void ComboBoxStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedStatus = comboBoxStatusFilter.SelectedItem.ToString();
             LoadOrders(selectedStatus);
        }

        private void AddOrderToPanel(OrderDTO order, int index)
        {
            Panel orderPanel = new Panel
            {
                Size = new Size(1586, 50),
                BackColor = Color.White,
                BorderStyle = BorderStyle.None,
                Margin = new Padding(4),
                Tag = order
            };

            Label lblNumber = new Label
            {
                Text = index.ToString(),
                Location = new Point(17, 19),
                Size = new Size(30, 20),
                Font = new Font("Segoe UI", 10)
            };
            orderPanel.Controls.Add(lblNumber);

            //Label lblOrderName = new Label
            //{
            //    Text = $"{order.OrderID}",
            //    Location = new Point(91, 11),
            //    Size = new Size(200, 20),
            //    Font = new Font("Segoe UI", 10)
            //};
            //orderPanel.Controls.Add(lblOrderName);

            Label lblStatus = new Label
            {
                Text = $"Status: {order.Status}",
                Location = new Point(300, 11),
                Size = new Size(200, 20),
                Font = new Font("Segoe UI", 10),
                ForeColor = order.Status == OrderStatus.Approved ? Color.Green :
                            order.Status == OrderStatus.Pending ? Color.Orange :
                            order.Status == OrderStatus.Denied ? Color.Red :
                            order.Status == OrderStatus.Shipped ? Color.Blue : Color.Black
            };
            orderPanel.Controls.Add(lblStatus);

            Button btnView = new Button
            {
                Text = "View",
                Location = new Point(1482, 7),
                Size = new Size(80, 30),
                BackColor = Color.FromArgb(102, 210, 214),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnView.Click += (s, e) => ShowOrderDetails(order);
            orderPanel.Controls.Add(btnView);

            flowLayoutPanelOrders.Controls.Add(orderPanel);
        }

        private async void ShowOrderDetails(OrderDTO order)
        {
            var orderDetails = await _orderDetailServices.GetOrderDetailsByOrderIdAsync(order.OrderID);
            order.OrderDetails = orderDetails?.ToList();

            Form orderViewForm = new Form
            {
                Width = 600,
                Height = 500,
                FormBorderStyle = FormBorderStyle.None,
                StartPosition = FormStartPosition.CenterScreen,
                BackColor = Color.LightGray
            };

            int radius = 20;
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(orderViewForm.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(orderViewForm.Width - radius, orderViewForm.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, orderViewForm.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();
            orderViewForm.Region = new Region(path);

            Panel innerPanel = new Panel
            {
                Location = new Point(5, 5),
                Size = new Size(orderViewForm.Width - 10, orderViewForm.Height - 10),
                BackColor = Color.White,
                Padding = new Padding(10)
            };
            orderViewForm.Controls.Add(innerPanel);

            Button btnClose = new Button
            {
                Text = "X",
                Location = new Point(innerPanel.Width - 40, 10),
                Size = new Size(30, 30),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.Red,
                ForeColor = Color.White
            };
            btnClose.Click += (s, e) => orderViewForm.Close();
            innerPanel.Controls.Add(btnClose);

            Label lblOrderName = new Label
            {
                Text = $"Order Number #{order.OrderID}",
                Location = new Point(20, 20),
                Size = new Size(300, 20),
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };
            innerPanel.Controls.Add(lblOrderName);

            Label lblDate = new Label
            {
                Text = $"Date: {order.OrderDate:yyyy-MM-dd}",
                Location = new Point(20, 50),
                Size = new Size(300, 20),
                Font = new Font("Segoe UI", 10)
            };
            innerPanel.Controls.Add(lblDate);

            Label lblTotal = new Label
            {
                Text = $"Total: {order.TotalAmount:C}",
                Location = new Point(20, 80),
                Size = new Size(300, 20),
                Font = new Font("Segoe UI", 10)
            };
            innerPanel.Controls.Add(lblTotal);

            Label lblStatus = new Label
            {
                Text = $"Status: {order.Status}",
                Location = new Point(20, 110),
                Size = new Size(300, 20),
                Font = new Font("Segoe UI", 10)
            };
            innerPanel.Controls.Add(lblStatus);

            DataGridView dataGridViewDetails = null;
            if (order.OrderDetails != null && order.OrderDetails.Any())
            {
                Label lblDetailsHeader = new Label
                {
                    Text = "Order Items:",
                    Location = new Point(20, 140),
                    Size = new Size(300, 20),
                    Font = new Font("Segoe UI", 10, FontStyle.Bold)
                };
                innerPanel.Controls.Add(lblDetailsHeader);

                dataGridViewDetails = new DataGridView
                {
                    Location = new Point(20, 170),
                    Size = new Size(540, 200),
                    BackgroundColor = Color.White,
                    BorderStyle = BorderStyle.None,
                    RowHeadersVisible = false,
                    AllowUserToAddRows = false,
                    AllowUserToDeleteRows = false,
                    ReadOnly = true
                };
                innerPanel.Controls.Add(dataGridViewDetails);

                dataGridViewDetails.Columns.Add("IndexColumn", "#");
                dataGridViewDetails.Columns["IndexColumn"].Width = 50;
                dataGridViewDetails.Columns.Add("ProductName", "Product Name");
                dataGridViewDetails.Columns["ProductName"].Width = 200;
                dataGridViewDetails.Columns.Add("Quantity", "Quantity");
                dataGridViewDetails.Columns["Quantity"].Width = 100;
                dataGridViewDetails.Columns.Add("Price", "Unit Price");
                dataGridViewDetails.Columns["Price"].Width = 100;
                dataGridViewDetails.Columns.Add("TotalPrice", "Total Price");
                dataGridViewDetails.Columns["TotalPrice"].Width = 100;

                int index = 1;
                foreach (var detail in order.OrderDetails)
                {
                    if (string.IsNullOrEmpty(detail.ProductName))
                    {
                        var product = await _productServices.GetProductByIdAsync(detail.ProductId);
                        detail.ProductName = product?.Name ?? "Unknown Product";
                        detail.Price = product?.Price ?? 0;
                    }
                    decimal totalPrice = detail.Quantity * detail.Price;
                    dataGridViewDetails.Rows.Add(index++, detail.ProductName, detail.Quantity, detail.Price.ToString("C"), totalPrice.ToString("C"));
                }

                if (dataGridViewDetails.Rows.Count * 25 + 250 > orderViewForm.Height)
                {
                    orderViewForm.Height = dataGridViewDetails.Rows.Count * 25 + 300;
                    innerPanel.Height = orderViewForm.Height - 10;
                }
            }
            else
            {
                Label lblNoDetails = new Label
                {
                    Text = "No items found in this order.",
                    Location = new Point(20, 140),
                    Size = new Size(300, 20),
                    Font = new Font("Segoe UI", 10)
                };
                innerPanel.Controls.Add(lblNoDetails);
            }

            // زراري Approve وDeny لو الطلب Pending
            if (order.Status.ToString().Equals("Pending", StringComparison.OrdinalIgnoreCase))
            {
                int yPosition = dataGridViewDetails != null ? dataGridViewDetails.Bottom + 20 : 190;
                Button btnApproved = new Button
                {
                    Text = "Approve",
                    Location = new Point(150, yPosition),
                    Size = new Size(80, 30),
                    BackColor = Color.Green,
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat
                };
                btnApproved.Click += async (s, e) =>
                {
                    try
                    {
                        var result = await _orderServices.ApproveOrderAsync(order.OrderID);
                        if (result.Success)
                        {
                            orderViewForm.Close();
                            LoadOrders(comboBoxStatusFilter.SelectedItem.ToString());
                            MessageBox.Show("Order approved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show(result.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error approving order: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                };
                innerPanel.Controls.Add(btnApproved);

                Button btnDeny = new Button
                {
                    Text = "Deny",
                    Location = new Point(250, yPosition),
                    Size = new Size(80, 30),
                    BackColor = Color.Red,
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat
                };
                btnDeny.Click += async (s, e) =>
                {
                    try
                    {
                        var result = await _orderServices.DenyOrderAsync(order.OrderID);
                        if (result.Success)
                        {
                            orderViewForm.Close();
                            LoadOrders(comboBoxStatusFilter.SelectedItem.ToString());
                            MessageBox.Show("Order denied successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show(result.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error denying order: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                };
                innerPanel.Controls.Add(btnDeny);

                if (yPosition + 50 > orderViewForm.Height)
                {
                    orderViewForm.Height = yPosition + 70;
                    innerPanel.Height = orderViewForm.Height - 10;
                }
            }

            // زر Ship لو الطلب Approved
            if (order.Status.ToString().Equals("Approved", StringComparison.OrdinalIgnoreCase))
            {
                int yPosition = dataGridViewDetails != null ? dataGridViewDetails.Bottom + 20 : 190;
                Button btnShip = new Button
                {
                    Text = "Ship",
                    Location = new Point(350, yPosition),
                    Size = new Size(80, 30),
                    BackColor = Color.Blue,
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat
                };
                btnShip.Click += async (s, e) =>
                {
                    try
                    {
                        var result = await _orderServices.UpdateOrderStatusAsync(order.OrderID, OrderStatus.Shipped);
                        if (result.Success)
                        {
                            orderViewForm.Close();
                            LoadOrders(comboBoxStatusFilter.SelectedItem.ToString());
                            MessageBox.Show("Order shipped successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show(result.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error shipping order: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                };
                innerPanel.Controls.Add(btnShip);

                if (yPosition + 50 > orderViewForm.Height)
                {
                    orderViewForm.Height = yPosition + 70;
                    innerPanel.Height = orderViewForm.Height - 10;
                }
            }

            orderViewForm.ShowDialog();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
        }

        private void OrdersPage_Load(object sender, EventArgs e)
        {
        }
    }
}