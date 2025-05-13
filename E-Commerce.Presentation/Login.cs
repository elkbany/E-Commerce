using AdminTest;
using E_Commerce.BL.Contracts.Services;
using E_Commerce.BL.Features.User.DTOs;
using E_Commerce.Domain.Enums;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.ComponentModel.DataAnnotations;
using System.Windows.Forms;

namespace E_Commerce.Presentation
{
    public partial class Login : Form
    {
        private readonly IAccountServices accountServices;
        private readonly IValidator<LoginUserDto> validator;
        private readonly Start _startForm; // أضف الـ Reference

        public Login(IAccountServices accountServices, IValidator<LoginUserDto> validator, Start startForm)
        {
            InitializeComponent();
            this.accountServices = accountServices;
            this.validator = validator;
            _startForm = startForm; // خزّن الـ Start Form
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            var loginUserDto = new LoginUserDto
            {
                UsernameOrEmail = txtUsername.Text.Trim(),
                Password = txtPassword.Text
            };

            var validationResult = await validator.ValidateAsync(loginUserDto);
            if (!validationResult.IsValid)
            {
                MessageBox.Show(string.Join("\n", validationResult.Errors.Select(e => e.ErrorMessage)),
                                "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var success = await accountServices.LoginUserAsync(loginUserDto);
                if (success)
                {
                    MessageBox.Show("Login Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    int userId = await accountServices.GetUserIdByUsernameOrEmailAsync(loginUserDto.UsernameOrEmail);
                    if (userId == -1)
                    {
                        MessageBox.Show("User not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    UserStatus userStatus = await accountServices.GetUserStatusAsync(userId);
                    if (userStatus == UserStatus.Admin)
                    {
                        var adminForm = ServiceProviderContainer.ServiceProvider.GetRequiredService<Admin>();
                        adminForm.Show();
                        this.Hide(); // عدّل من Close() لـ Hide()
                    }
                    else
                    {
                        var clientForm = ServiceProviderContainer.ServiceProvider.GetRequiredService<frmMain>();
                        clientForm.SetUserId(userId);
                        clientForm.Show();
                        this.Hide(); // عدّل من Close() لـ Hide()
                    }
                }
                else
                {
                    MessageBox.Show("Invalid username/email or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide(); // عدّل من Close() لـ Hide()
        }

        private void showPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !showPassword.Checked;
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_startForm != null && !_startForm.IsDisposed)
            {
                _startForm.StartPosition = FormStartPosition.Manual;
                _startForm.Location = this.Location;
                _startForm.Show();
            }
            else
            {
                Application.Exit();
            }
        }
        private void lblSignUpHere_Click(object sender, EventArgs e)
        {
            var signupForm = ServiceProviderContainer.ServiceProvider.GetRequiredService<Signup>();
            signupForm.StartPosition = FormStartPosition.Manual;
            signupForm.Location = this.Location;
            signupForm.Show();
            this.Hide(); // أو this.Close() لو عايز تقفل Login بدل ما تخبيه
        }

        private void login_username_TextChanged(object sender, EventArgs e)
        {

        }
    }
}