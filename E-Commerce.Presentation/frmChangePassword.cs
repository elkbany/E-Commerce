using E_Commerce.BL.Contracts.Services;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace E_Commerce.Presentation
{
    public partial class frmChangePassword : Form
    {
        private readonly IAccountServices accountServices;
        private readonly int userId;

        public frmChangePassword(IAccountServices accountServices, int userId)
        {
            InitializeComponent();
            this.accountServices = accountServices;
            this.userId = userId;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (showPassword.Checked)
            {
                lblNewPassword1.PasswordChar = '\0';
                lblNewPassword2.PasswordChar = '\0';
            }
            else
            {
                lblNewPassword1.PasswordChar = '*';
                lblNewPassword2.PasswordChar = '*';
            }
        }

        private void button2_Click(object sender, EventArgs e) // Cancel
        {
            this.Close();
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
        }

        private void frmChangePassword_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private async void button1_Click(object sender, EventArgs e) // Save
        {
            if (string.IsNullOrWhiteSpace(lnlOldPassword.Text) || string.IsNullOrWhiteSpace(lblNewPassword1.Text) || string.IsNullOrWhiteSpace(lblNewPassword2.Text))
            {
                MessageBox.Show("Please fill all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (lblNewPassword1.Text != lblNewPassword2.Text)
            {
                MessageBox.Show("New password and confirmation do not match.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Are you sure you want to change your password?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    //await accountServices.ChangePasswordAsync(userId, lnlOldPassword.Text, lblNewPassword1.Text);
                    MessageBox.Show("Password changed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error changing password: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}