using E_Commerce.BL.Contracts.Services;
using E_Commerce.BL.Features.User.DTOs;
using E_Commerce.BL.Features.User.Validators;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;
using FluentValidation;


namespace E_Commerce.Presentation
{
    public partial class Login : Form
    {
        private readonly IAccountServices accountServices;
        private readonly IValidator<LoginUserDto> validator;

        public Login(IAccountServices accountServices, IValidator<LoginUserDto> validator)
        {
            InitializeComponent();
            this.accountServices = accountServices;
            this.validator = validator;
        }

        private void login_registerHere_Click(object sender, EventArgs e)
        {
            var signUpForm = ServiceProviderContainer.ServiceProvider.GetRequiredService<Signup>();
            signUpForm.Show();
            this.Hide();
        }

        private void login_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void login_showPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (login_showPassword.Checked)
            {
                login_password.PasswordChar = '\0';
            }
            else
            {
                login_password.PasswordChar = '*';
            }
        }

        private async void login_btn_Click(object sender, EventArgs e)
        {
            var loginUserDto = new LoginUserDto
            {
                UsernameOrEmail = login_username.Text.Trim(),
                Password = login_password.Text
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
                var success = await accountServices.LoginUserAsync(loginUserDto); // استخدام LoginUserDto كما في AccountServices
                if (success)
                {
                    MessageBox.Show("Login Successful");
                    //var userForm = ServiceProviderContainer.ServiceProvider.GetRequiredService<UserForm>();

                    //userForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid username/email or password.", "Login Failed",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}