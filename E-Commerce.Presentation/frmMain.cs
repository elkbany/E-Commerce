using E_Commerce.BL.Contracts.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;

namespace E_Commerce.Presentation
{
    public partial class frmMain : Form
    {
        private readonly IAccountServices accountServices;
        private int userId;
        private frmProducts products;
        private frmProfile profile;
        private frmOrders orders;
        private frmCart cart;
        private bool sidebarExpand = true; // أضفت المتغيّر ده عشان sidebarTransition_Tick

        public frmMain(IAccountServices accountServices)
        {
            InitializeComponent();
            this.accountServices = accountServices;
        }

        public void SetUserId(int userId)
        {
            this.userId = userId;
            LoadUserInfo();
            LoadHomeForm(); // هنضيف استدعاء LoadHomeForm هنا عشان المنتجات تظهر أول ما تفتح frmMain
        }

        private void LoadHomeForm()
        {
            foreach (Form child in this.MdiChildren)
            {
                child.Close();
            }

            products = new frmProducts(
                ServiceProviderContainer.ServiceProvider.GetRequiredService<IProductServices>(),
                ServiceProviderContainer.ServiceProvider.GetRequiredService<ICartItemServices>(),
                ServiceProviderContainer.ServiceProvider.GetRequiredService<ICategoryServices>(),
                userId)
            {
                MdiParent = this,
                WindowState = FormWindowState.Maximized
            };
            products.Show();
        }

        private async void LoadUserInfo()
        {
            try
            {
                var userInfo = await accountServices.ViewProfile(userId);
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
            if (sidebarExpand)
            {
                sidebar.Width -= 10;
                if (sidebar.Width <= 66)
                {
                    sidebarExpand = false;
                    sidebarTransition.Stop();
                }
            }
            else
            {
                sidebar.Width += 10;
                if (sidebar.Width >= 254)
                {
                    sidebarExpand = true;
                    sidebarTransition.Stop();
                }
            }
        }

        private void btnDrag_Click(object sender, EventArgs e)
        {
            sidebarTransition.Start();
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            if (products == null || products.IsDisposed)
            {
                products = new frmProducts(
                    ServiceProviderContainer.ServiceProvider.GetRequiredService<IProductServices>(),
                    ServiceProviderContainer.ServiceProvider.GetRequiredService<ICartItemServices>(),
                    ServiceProviderContainer.ServiceProvider.GetRequiredService<ICategoryServices>(),
                    userId)
                {
                    MdiParent = this,
                    Dock = DockStyle.Fill
                };
                products.FormClosed += home_FormClosed;
                products.Show();
            }
            else
            {
                products.Activate();
            }
        }

        private void home_FormClosed(object sender, FormClosedEventArgs e)
        {
            products = null;
        }

        private void btnCart_Click(object sender, EventArgs e)
        {
            if (cart == null || cart.IsDisposed)
            {
                cart = new frmCart(
                    ServiceProviderContainer.ServiceProvider.GetRequiredService<ICartItemServices>(),
                    userId)
                {
                    MdiParent = this,
                    Dock = DockStyle.Fill
                };
                cart.FormClosed += cart_FormClosed;
                cart.Show();
            }
            else
            {
                cart.Activate();
            }
        }

        private void cart_FormClosed(object sender, FormClosedEventArgs e)
        {
            cart = null;
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            if (profile == null || profile.IsDisposed)
            {
                profile = new frmProfile(
                    ServiceProviderContainer.ServiceProvider.GetRequiredService<IAccountServices>(),
                    userId)
                {
                    MdiParent = this,
                    Dock = DockStyle.Fill
                };
                profile.FormClosed += profile_FormClosed;
                profile.Show();
            }
            else
            {
                profile.Activate();
            }
        }

        private void profile_FormClosed(object sender, FormClosedEventArgs e)
        {
            profile = null;
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            if (orders == null || orders.IsDisposed)
            {
                orders = new frmOrders(
                    ServiceProviderContainer.ServiceProvider.GetRequiredService<IOrderServices>(),
                    userId)
                {
                    MdiParent = this,
                    Dock = DockStyle.Fill
                };
                orders.FormClosed += orders_FormClosed;
                orders.Show();
            }
            else
            {
                orders.Activate();
            }
        }

        private void orders_FormClosed(object sender, FormClosedEventArgs e)
        {
            orders = null;
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
                        Application.Exit();
                    }
                    else
                    {
                        MessageBox.Show("Failed to logout.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error logging out: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void labelUsername_Click(object sender, EventArgs e)
        {
        }

        private void nightControlBox1_Click(object sender, EventArgs e)
        {
        }
    }
}