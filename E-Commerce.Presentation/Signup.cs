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
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E_Commerce.Presentation
{
    public partial class Signup : Form
    {
        private readonly IAccountServices accountServices;

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

        public Signup(IAccountServices accountServices)
        {
            InitializeComponent();
            this.accountServices = accountServices;
        }

        private void signup_loginHere_Click(object sender, EventArgs e)
        {

        }

        private void signup_close_Click(object sender, EventArgs e)
        {
        }

        private void signup_showPassword_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void signup_close_Click_1(object sender, EventArgs e)
        {
        }

        private async void signup_btn_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void signup_showPassword_CheckedChanged_1(object sender, EventArgs e)
        {
            if (signup_showPassword.Checked)
            {
                signup_password.PasswordChar = '\0';
                signup_confirmpassword.PasswordChar = '\0';
            }
            else
            {
                signup_password.PasswordChar = '*';
                signup_confirmpassword.PasswordChar = '*';
            }
        }

        private async void signup_btn_Click_1(object sender, EventArgs e)
        {
            var reg = new RegisterUserDto
            {
                FirstName = signup_firstName?.Text ?? string.Empty, // استخدم Null-conditional operator
                LastName = signup_lastName?.Text ?? string.Empty,
                Username = signup_username?.Text ?? string.Empty,
                Email = signup_email?.Text ?? string.Empty,
                Password = signup_password?.Text ?? string.Empty,
                ConfirmPassword = signup_confirmpassword?.Text ?? string.Empty

            };

            try
            {
                var success = await accountServices.RegisterUser(reg); // استخدم await
                if (success)
                {
                    MessageBox.Show("Registration successful.");
                    var loginForm = ServiceProviderContainer.ServiceProvider.GetRequiredService<Login>();
                    loginForm.Show();
                    this.Hide();
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

        private void signup_loginHere_Click_1(object sender, EventArgs e)
        {
            // new login(new AccountServices())
            var loginForm = ServiceProviderContainer.ServiceProvider.GetRequiredService<Login>();
            loginForm.Show();
            this.Hide();
        }

        private void signup_close_Click_2(object sender, EventArgs e)
        {
            this.Close();

        }

        private void Signup_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }

}
