using E_Commerce.BL.Contracts.Services;
using E_Commerce.BL.Features.User.DTOs;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Runtime.InteropServices;
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

        private async void signup_btn_Click_1(object sender, EventArgs e)
        {
            var reg = new RegisterUserDto
            {
                FirstName = signup_firstName.Text ?? string.Empty,
                LastName = signup_lastName.Text ?? string.Empty,
                Username = signup_username.Text ?? string.Empty,
                Email = signup_email.Text ?? string.Empty,
                Password = signup_password.Text ?? string.Empty,
                ConfirmPassword = signup_confirmpassword.Text ?? string.Empty
            };

            try
            {
                var success = await accountServices.RegisterUser(reg);
                if (success)
                {
                    MessageBox.Show("Registration successful. Please login.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    var loginForm = ServiceProviderContainer.ServiceProvider.GetRequiredService<Login>();
                    loginForm.StartPosition = FormStartPosition.Manual;
                    loginForm.Location = this.Location;
                    loginForm.Show();
                    this.Hide(); // عدّل من Dispose() لـ Hide()
                }
                else
                {
                    MessageBox.Show("Registration failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (FluentValidation.ValidationException ex)
            {
                var errorMessages = string.Join("\n", ex.Errors.Select(error => error.ErrorMessage));
                MessageBox.Show(errorMessages, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void signup_loginHere_Click_1(object sender, EventArgs e)
        {
            var loginForm = ServiceProviderContainer.ServiceProvider.GetRequiredService<Login>();
            loginForm.StartPosition = FormStartPosition.Manual;
            loginForm.Location = this.Location;
            loginForm.Show();
            this.Hide(); // عدّل من Dispose() لـ Hide()
        }

        private void signup_close_Click_2(object sender, EventArgs e)
        {
            this.Close();
        }

        private void signup_showPassword_CheckedChanged_1(object sender, EventArgs e)
        {
            signup_password.UseSystemPasswordChar = !signup_showPassword.Checked;
            signup_confirmpassword.UseSystemPasswordChar = !signup_showPassword.Checked;
        }

        private void Signup_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void Signup_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!Application.OpenForms.OfType<Start>().Any())
            {
                Application.Exit(); // لو Start مش موجود، اقفل التطبيق
            }
            else
            {
                var startForm = Application.OpenForms.OfType<Start>().First();
                startForm.StartPosition = FormStartPosition.Manual;
                startForm.Location = this.Location;
                startForm.Show();
                this.Dispose();
            }
        }
    }
}