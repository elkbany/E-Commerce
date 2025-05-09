using E_Commerce.BL.Contracts.Services;

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
            Signup sForm = new Signup();
            sForm.Show();
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
    }
}
