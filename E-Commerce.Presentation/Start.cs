using E_Commerce.BL.Contracts.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace E_Commerce.Presentation
{
    public partial class Start : Form
    {
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

        private readonly IAccountServices accountServices;
        private readonly Lazy<Login> _loginForm;
        private readonly Lazy<Signup> _signupForm;

        public Start(IAccountServices accountServices)
        {
            InitializeComponent();
            this.accountServices = accountServices;
            _loginForm = new Lazy<Login>(() => ServiceProviderContainer.ServiceProvider.GetRequiredService<Login>());
            _signupForm = new Lazy<Signup>(() => ServiceProviderContainer.ServiceProvider.GetRequiredService<Signup>());
            this.FormClosed += Start_FormClosed; // أضف Event Handler
        }

        private void login_Click(object sender, EventArgs e)
        {

            var loginForm = _loginForm.Value;
            loginForm.StartPosition = FormStartPosition.Manual;
            loginForm.Location = this.Location;
            loginForm.Show();
            this.Hide();

        }

        private void signupHere_Click(object sender, EventArgs e)
        {

            var signupForm = _signupForm.Value;
            signupForm.StartPosition = FormStartPosition.Manual;
            signupForm.Location = this.Location;
            signupForm.Show();
            this.Hide();

        }

        private void login_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Start_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void Start_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit(); // لما Start يتقفل، التطبيق كله يتقفل
        }


    }
}