using E_Commerce.BL.Contracts.Services;
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
            var regSucces = accountServices.LoginUserAsync(login_username.Text, login_password.Text);
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
    }
}
