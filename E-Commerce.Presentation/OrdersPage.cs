using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace E_Commerce.Presentation
{
    public partial class OrdersPage : UserControl
    {
        public FlowLayoutPanel flowLayoutPanelOrders;

        public OrdersPage()
        {
            InitializeComponent();

            flowLayoutPanelOrders = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                Padding = new Padding(0, 50, 0, 0)
            };
            Controls.Add(flowLayoutPanelOrders);

            LoadOrders();
        }

        public void LoadOrders()
        {
            flowLayoutPanelOrders.Controls.Clear();

            // بيانات وهمية للاختبار
            var orders = new List<Order>
        {
            new Order { Id = 1, OrderName = "Order #1001", Date = DateTime.Now.AddDays(-2), Total = 150.00m, User = "Ahmed Ali" },
            new Order { Id = 2, OrderName = "Order #1002", Date = DateTime.Now.AddDays(-1), Total = 220.50m, User = "Sara Mohamed" },
            new Order { Id = 3, OrderName = "Order #1003", Date = DateTime.Now, Total = 99.99m, User = "Khaled Hassan" },
            new Order { Id = 4, OrderName = "Order #1004", Date = DateTime.Now.AddDays(-3), Total = 300.00m, User = "Omar Khaled" },
            new Order { Id = 5, OrderName = "Order #1005", Date = DateTime.Now.AddDays(-4), Total = 175.25m, User = "Fatima Ali" },
            new Order { Id = 6, OrderName = "Order #1006", Date = DateTime.Now.AddDays(-5), Total = 450.75m, User = "Youssef Mohamed" }
        };

            int index = 1;
            foreach (var order in orders)
            {
                AddOrderToPanel(order, index++);
            }
        }

        private void AddOrderToPanel(Order order, int index)
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

            Label lblOrderName = new Label
            {
                Text = order.OrderName,
                Location = new Point(91, 11),
                Size = new Size(200, 20),
                Font = new Font("Segoe UI", 10)
            };
            orderPanel.Controls.Add(lblOrderName);

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

        private void ShowOrderDetails(Order order)
        {
            // إنشاء Form مع خلفية خفيفة لتأثير الظل
            Form orderViewForm = new Form
            {
                Width = 400,
                Height = 300,
                FormBorderStyle = FormBorderStyle.None,
                StartPosition = FormStartPosition.CenterScreen,
                BackColor = Color.LightGray // خلفية خفيفة لتقليد الظل
            };

            // تطبيق زوايا مستديرة
            int radius = 20; // نصف قطر الزاوية المستديرة
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90); // زاوية علوية يسار
            path.AddArc(orderViewForm.Width - radius, 0, radius, radius, 270, 90); // زاوية علوية يمين
            path.AddArc(orderViewForm.Width - radius, orderViewForm.Height - radius, radius, radius, 0, 90); // زاوية سفلية يمين
            path.AddArc(0, orderViewForm.Height - radius, radius, radius, 90, 90); // زاوية سفلية يسار
            path.CloseFigure();
            orderViewForm.Region = new Region(path);

            // إضافة Panel داخلي بتأثير الظل والخلفية البيضاء
            Panel innerPanel = new Panel
            {
                Location = new Point(5, 5), // مسافة صغيرة لتقليد الظل
                Size = new Size(orderViewForm.Width - 10, orderViewForm.Height - 10),
                BackColor = Color.White,
                Padding = new Padding(10)
            };
            orderViewForm.Controls.Add(innerPanel);

            // زرار X للإلغاء
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

            // عرض التفاصيل
            Label lblOrderName = new Label
            {
                Text = $"Order Name: {order.OrderName}",
                Location = new Point(20, 50),
                Size = new Size(300, 20),
                Font = new Font("Segoe UI", 10)
            };
            innerPanel.Controls.Add(lblOrderName);

            Label lblDate = new Label
            {
                Text = $"Date: {order.Date.ToString("yyyy-MM-dd")}",
                Location = new Point(20, 80),
                Size = new Size(300, 20),
                Font = new Font("Segoe UI", 10)
            };
            innerPanel.Controls.Add(lblDate);

            Label lblTotal = new Label
            {
                Text = $"Total: {order.Total:C}",
                Location = new Point(20, 110),
                Size = new Size(300, 20),
                Font = new Font("Segoe UI", 10)
            };
            innerPanel.Controls.Add(lblTotal);

            Label lblUser = new Label
            {
                Text = $"User: {order.User}",
                Location = new Point(20, 140),
                Size = new Size(300, 20),
                Font = new Font("Segoe UI", 10)
            };
            innerPanel.Controls.Add(lblUser);

            // زرار Approved
            Button btnApproved = new Button
            {
                Text = "Approved",
                Location = new Point(100, 200),
                Size = new Size(80, 30),
                BackColor = Color.Green,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnApproved.Click += (s, e) =>
            {
                orderViewForm.Close();
                LoadOrders();
                MessageBox.Show("Order approved successfully!");
            };
            innerPanel.Controls.Add(btnApproved);

            // زرار Deny
            Button btnDeny = new Button
            {
                Text = "Deny",
                Location = new Point(200, 200),
                Size = new Size(80, 30),
                BackColor = Color.Red,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnDeny.Click += (s, e) =>
            {
                orderViewForm.Close();
                LoadOrders();
                MessageBox.Show("Order denied successfully!");
            };
            innerPanel.Controls.Add(btnDeny);

            orderViewForm.ShowDialog();
        }
    }

    // كلاس وهمي للطلبات
    public class Order
    {
        public int Id { get; set; }
        public string OrderName { get; set; }
        public DateTime Date { get; set; }
        public decimal Total { get; set; }
        public string User { get; set; }
    }

}