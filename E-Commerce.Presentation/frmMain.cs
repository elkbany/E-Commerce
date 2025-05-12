using E_Commerce.BL.Contracts.Services;
using E_Commerce.Domain.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;

namespace E_Commerce.Presentation
{
    public partial class frmMain : Form
    {
        private readonly IAccountServices accountServices;
        private int userId;
        frmProducts products;
        frmProfile profile;
        frmOrders orders;

        public frmMain(IAccountServices accountServices, int userId)
        {
            InitializeComponent();
            this.accountServices = accountServices;
            this.userId = userId;
            LoadUserInfo();
        }

        private void LoadHomeForm()
        {
            foreach (Form child in this.MdiChildren)
            {
                child.Close();
            }

            var homeForm = new frmProducts(
                ServiceProviderContainer.ServiceProvider.GetRequiredService<IProductServices>(),
                userId)
            {
                MdiParent = this,
                WindowState = FormWindowState.Maximized
            };
            homeForm.Show();
        }

        private async void LoadUserInfo()
        {
            var userInfo = await accountServices.ViewProfile(userId);
            if (userInfo != null)
            {
                labelUsername.Text = userInfo.Username;
            }
        }

        bool sidebarExpand = true;
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

        private void frmMain_Load(object sender, EventArgs e)
        {
        }

        private void nightControlBox1_Click(object sender, EventArgs e)
        {
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            if (products == null)
            {
                products = new frmProducts(ServiceProviderContainer.ServiceProvider.GetRequiredService<IProductServices>(), userId);
                products.FormClosed += home_FormClosed;
                products.MdiParent = this;
                products.Dock = DockStyle.Fill;
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

        private void btnProfile_Click(object sender, EventArgs e)
        {
            if (profile == null)
            {
                profile = new frmProfile(ServiceProviderContainer.ServiceProvider.GetRequiredService<IAccountServices>(), userId);
                profile.FormClosed += profile_FormClosed;
                profile.MdiParent = this;
                profile.Dock = DockStyle.Fill;
                profile.Show();
            }
            else
            {
                profile.Activate();
            }
        }

        private void profile_FormClosed(object? sender, FormClosedEventArgs e)
        {
            profile = null;
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            if (orders == null || orders.IsDisposed)
            {
                orders = new frmOrders(ServiceProviderContainer.ServiceProvider.GetRequiredService<IOrderServices>(), userId);
                orders.FormClosed += orders_FormClosed;
                orders.MdiParent = this;
                orders.Dock = DockStyle.Fill;
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

            var userInfo = await accountServices.ViewProfile(userId);  
            await accountServices.LogoutUserAsync(userInfo.Username);
            Application.Exit();

        }

        private void labelUsername_Click(object sender, EventArgs e)
        {
        }

        private void nightControlBox1_Click_1(object sender, EventArgs e)
        {
        }
    }
}