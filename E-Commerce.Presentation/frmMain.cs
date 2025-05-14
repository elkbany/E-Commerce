using E_Commerce.BL.Contracts.Services;
using E_Commerce.BL.Features.User.DTOs;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace E_Commerce.Presentation
{
    public partial class frmMain : Form
    {
        private readonly IAccountServices accountServices;
        private int userId;
        private UserIformationDTO userInfo;
        private readonly Lazy<frmProducts> products;
        private readonly Lazy<frmCart> cart;
        private readonly Lazy<frmOrders> orders;
        private readonly Lazy<frmProfile> profile;

        private bool sidebarExpand = true;
        private Button activeButton;

        private Form currentForm;

        private bool isDragging = false;
        private Point lastLocation;

        public frmMain(IAccountServices accountServices)
        {
            InitializeComponent();
            this.accountServices = accountServices;

            products = new Lazy<frmProducts>(() => new frmProducts(
                ServiceProviderContainer.ServiceProvider.GetRequiredService<IProductServices>(),
                ServiceProviderContainer.ServiceProvider.GetRequiredService<ICartItemServices>(),
                ServiceProviderContainer.ServiceProvider.GetRequiredService<ICategoryServices>(),
                userId)
            {
                MdiParent = this,
                Dock = DockStyle.Fill
            });

            cart = new Lazy<frmCart>(() => new frmCart(
                ServiceProviderContainer.ServiceProvider.GetRequiredService<ICartItemServices>(),
                userId)
            {
                MdiParent = this,
                Dock = DockStyle.Fill
            });

            orders = new Lazy<frmOrders>(() => new frmOrders(
                ServiceProviderContainer.ServiceProvider.GetRequiredService<IOrderServices>(),
                userId)
            {
                MdiParent = this,
                Dock = DockStyle.Fill
            });

            profile = new Lazy<frmProfile>(() => new frmProfile(
                ServiceProviderContainer.ServiceProvider.GetRequiredService<IAccountServices>(),
                userId)
            {
                MdiParent = this,
                Dock = DockStyle.Fill
            });

            AddButtonEvents(btnProducts);
            AddButtonEvents(btnCart);
            AddButtonEvents(btnOrders);
            AddButtonEvents(btnProfile);
            AddButtonEvents(btnLogout);

            panel1.MouseDown += Panel1_MouseDown;
            panel1.MouseMove += Panel1_MouseMove;
            panel1.MouseUp += Panel1_MouseUp;


        }

        public void SetUserId(int userId)
        {
            this.userId = userId;
            LoadUserInfo();
            // إعادة تهيئة الـ Lazy مع الـ userId الجديد
            var products = new Lazy<frmProducts>(() => new frmProducts(
                ServiceProviderContainer.ServiceProvider.GetRequiredService<IProductServices>(),
                ServiceProviderContainer.ServiceProvider.GetRequiredService<ICartItemServices>(),
                ServiceProviderContainer.ServiceProvider.GetRequiredService<ICategoryServices>(),
                this.userId)
            { MdiParent = this, Dock = DockStyle.Fill });
            LoadHomeForm();
        }

        private void LoadHomeForm()
        {
            ShowSingleForm(new Lazy<Form>(() => products.Value), btnProducts);
        }

        private void ShowSingleForm(Lazy<Form> formToShow, Button button)
        {
            if (currentForm != null && currentForm.IsHandleCreated && !currentForm.IsDisposed)
            {
                currentForm.Hide();
            }

            var form = formToShow.Value;
            if (!form.IsHandleCreated || form.IsDisposed)
            {
                form.FormClosed += (s, e) => currentForm = null;
                form.Show();
            }
            else
            {
                form.Activate();
            }

            currentForm = form;

            // ضبط الـ Active Button
            if (activeButton != null)
                activeButton.BackColor = Color.FromArgb(0, 120, 212);
            activeButton = button;
            activeButton.BackColor = Color.FromArgb(50, 160, 252);
        }
        private async void LoadUserInfo()
        {
            try
            {
                if (userInfo == null)
                {
                    userInfo = await accountServices.ViewProfile(userId);
                }

                if (userInfo != null)
                {
                    labelUsername.Text = userInfo.Username;
                }
                else
                {
                    MessageBox.Show("Failed to load user info.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading user info: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void sidebarTransition_Tick(object sender, EventArgs e)
        {
            int minWidth = 66;
            int maxWidth = 254;

            if (sidebarExpand)
            {
                sidebar.Width -= 10;
                if (sidebar.Width <= minWidth)
                {
                    sidebarExpand = false;
                    sidebarTransition.Stop();
                    //btnDrag.Image = Properties.Resources.expand_icon;
                }
            }
            else
            {
                sidebar.Width += 10;
                if (sidebar.Width >= maxWidth)
                {
                    sidebarExpand = true;
                    sidebarTransition.Stop();
                    //btnDrag.Image = Properties.Resources.collapse_icon;
                }
            }
        }

        private void btnDrag_Click(object sender, EventArgs e)
        {
            sidebarTransition.Start();
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            ShowSingleForm(new Lazy<Form>(() => products.Value), btnProducts);
        }

        private void home_FormClosed(object sender, FormClosedEventArgs e)
        {
            // مافيش حاجة هنا دلوقتي لأن Lazy بيحتفظ بالـ Instance
        }

        private void btnCart_Click(object sender, EventArgs e)
        {
            ShowSingleForm(new Lazy<Form>(() => cart.Value), btnCart);
        }

        private void cart_FormClosed(object sender, FormClosedEventArgs e)
        {
            // مافيش حاجة هنا دلوقتي
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            ShowSingleForm(new Lazy<Form>(() => profile.Value), btnProfile);
        }

        private void profile_FormClosed(object sender, FormClosedEventArgs e)
        {
            // مافيش حاجة هنا دلوقتي
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            ShowSingleForm(new Lazy<Form>(() => orders.Value), btnOrders);


        }

        private void orders_FormClosed(object sender, FormClosedEventArgs e)
        {
            // مافيش حاجة هنا دلوقتي
        }

        private async void btnLogout_Click(object sender, EventArgs e)
        {
            try
            {
                var userInfo = await accountServices.ViewProfile(userId);
                if (userInfo != null)
                {
                    bool loggedOut = await accountServices.LogoutUserAsync(userInfo.Username);
                    if (loggedOut)
                    {
                        if (products.Value.IsHandleCreated && !products.Value.IsDisposed) products.Value.Close();
                        if (cart.Value.IsHandleCreated && !cart.Value.IsDisposed) cart.Value.Close();
                        if (orders.Value.IsHandleCreated && !orders.Value.IsDisposed) orders.Value.Close();
                        if (profile.Value.IsHandleCreated && !profile.Value.IsDisposed) profile.Value.Close();

                        var loginForm = ServiceProviderContainer.ServiceProvider.GetRequiredService<Login>();
                        loginForm.StartPosition = FormStartPosition.Manual;
                        loginForm.Location = this.Location;
                        loginForm.Show();

                        this.Close();
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine($"Failed to logout user with userId: {userId}");
                        MessageBox.Show("Failed to logout.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error logging out user with userId: {userId}. Message: {ex.Message}");
                if (ex.InnerException != null)
                {
                    System.Diagnostics.Debug.WriteLine($"Inner Exception: {ex.InnerException.Message}");
                }
                MessageBox.Show($"Error logging out: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddButtonEvents(Button button)
        {
            button.MouseEnter += (s, e) =>
            {
                if (button != activeButton)
                    button.BackColor = Color.FromArgb(30, 140, 232);
            };
            button.MouseLeave += (s, e) =>
            {
                if (button != activeButton)
                    button.BackColor = Color.FromArgb(0, 120, 212);
            };
            button.Click += (s, e) =>
            {
                if (activeButton != null)
                    activeButton.BackColor = Color.FromArgb(0, 120, 212);
                activeButton = button;
                activeButton.BackColor = Color.FromArgb(50, 160, 252);
            };
        }

        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            using (var pen = new Pen(Color.FromArgb(0, 120, 212), 3)) // Border باللون الأزرق بتاع الـ Sidebar
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                e.Graphics.DrawEllipse(pen, 1, 1, pictureBox1.Width - 4, pictureBox1.Height - 4);
            }
        }
        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                lastLocation = e.Location;
            }
        }

        private void Panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X,
                    (this.Location.Y - lastLocation.Y) + e.Y);
                this.Update();
            }
        }

        private void Panel1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
            }
        }

    }

    
}