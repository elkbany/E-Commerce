using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E_Commerce.Presentation
{
    public partial class Start : Form
    {
        public Start()
        {
            InitializeComponent();
        }

        private void login_Click(object sender, EventArgs e)
        {
            Login loginForm = ServiceProviderContainer.ServiceProvider.GetRequiredService<Login>();
            loginForm.StartPosition = FormStartPosition.Manual;
            loginForm.Location = this.Location;
            loginForm.Show();
            this.Hide();
        }

        private void login_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }

}
