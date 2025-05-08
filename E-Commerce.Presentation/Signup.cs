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
    public partial class Signup : Form
    {
        public Signup()
        {
            InitializeComponent();
        }

        private void signup_loginHere_Click(object sender, EventArgs e)
        {
            Login lForm = new Login();
            lForm.Show();
            this.Hide();
        }

        private void signup_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void signup_showPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (signup_showPassword.Checked)
            {
                signup_password.PasswordChar = '\0';
            }
            else
            {
                signup_password.PasswordChar = '*';
            }
        }

        private void signup_close_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
