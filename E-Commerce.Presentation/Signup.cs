using E_Commerce.BL.Contracts.Services;
using E_Commerce.BL.Features.User.DTOs;
using E_Commerce.BL.Implementations;
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
    public partial class Signup : Form
    {
        private readonly IAccountServices accountServices;

        public Signup(IAccountServices accountServices)
        {
            InitializeComponent();
            this.accountServices = accountServices;
        }

        private void signup_loginHere_Click(object sender, EventArgs e)
        {
            // new login(new AccountServices())
            var loginForm = ServiceProviderContainer.ServiceProvider.GetRequiredService<Login>();
            loginForm.Show();
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

        private void signup_btn_Click(object sender, EventArgs e)
        {
            var reg = new RegisterUserDto();
            reg.Username = signup_username.Text;
            reg.Email = signup_lastName.Text;
            //reg.FirstName = signup_firstName.Text;
            //reg.LastName = signup_lastName.Text;
            reg.Password = signup_password.Text;
            try
            {
                var success = accountServices.RegisterUser(reg);
                if (success.Result)
                {
                    MessageBox.Show("Registration successful.");
                }
                else
                {
                    MessageBox.Show("Registration failed.");
                }
            }
            catch (FluentValidation.ValidationException ex)
            {
                var errorMessages = string.Join("\n", ex.Errors.Select(e => e.ErrorMessage));
                MessageBox.Show(errorMessages, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
