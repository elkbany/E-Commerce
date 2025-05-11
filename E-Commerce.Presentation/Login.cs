using E_Commerce.BL.Contracts.Services;
using E_Commerce.BL.Features.User.DTOs;
using E_Commerce.BL.Features.User.Validators;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;
using FluentValidation;
using E_Commerce.Domain.Enums;


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

        }

        private void login_close_Click(object sender, EventArgs e)
        {
        }

        private void login_showPassword_CheckedChanged(object sender, EventArgs e)
        {

        }

        private async void login_btn_Click(object sender, EventArgs e)
        {
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private async void login_btn_Click_1(object sender, EventArgs e)
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
                    MessageBox.Show("Login Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //var userForm = ServiceProviderContainer.ServiceProvider.GetRequiredService<UserForm>();

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
                        this.Close();
                    }
                    else
                    {
                        var clientForm = ActivatorUtilities.CreateInstance<frmMain>(ServiceProviderContainer.ServiceProvider, accountServices, userId);                        // تمرير userId باستخدام Reflection (لو عايز تستخدمه في frmMain)
                        //var clientForm = ServiceProviderContainer.ServiceProvider.GetRequiredService<frmMain>(); // if no userId
                        clientForm.Show();
                        this.Close();
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

        private void login_showPassword_CheckedChanged_1(object sender, EventArgs e)
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

        private void login_registerHere_Click_1(object sender, EventArgs e)
        {
            var signUpForm = ServiceProviderContainer.ServiceProvider.GetRequiredService<Signup>();
            signUpForm.ShowDialog(); // استخدم ShowDialog عشان يرجع لـ Login بعد الإغلاق
        }

        private void login_close_Click_1(object sender, EventArgs e)
        {
            Application.Exit();

        }
    }
}