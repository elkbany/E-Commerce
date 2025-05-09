using E_Commerce.BL.Contracts.Services;
using E_Commerce.BL.Features.User.DTOs;
using Microsoft.Extensions.DependencyInjection;

namespace E_Commerce.Presentation
{
    public partial class Login : Form
    {
        private readonly IAccountServices accountServices;

        public Login(IAccountServices accountServices)
        {
            InitializeComponent();
            this.accountServices = accountServices;
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

        private void login_btn_Click(object sender, EventArgs e)
        {
            var loginUserDto = new LoginUserDto
            {
                Username = login_username.Text,
                Password = login_password.Text
            };
            try
            {
                var regSucces = accountServices.LoginUserAsync(loginUserDto);
                if (regSucces.Result)
                {
                    MessageBox.Show("Login Successful");
                    // Navigate to the next form
                    // var nextForm = new NextForm();
                    // nextForm.Show();
                    // this.Hide();
                }
                else
                {
                    MessageBox.Show("Login Failed");
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
    }
}
