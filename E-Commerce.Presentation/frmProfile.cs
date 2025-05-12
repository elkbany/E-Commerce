using E_Commerce.BL.Contracts.Services;
using E_Commerce.BL.Features.User.DTOs;
using System;
using System.Windows.Forms;

namespace E_Commerce.Presentation
{
    public partial class frmProfile : Form
    {
        private readonly IAccountServices accountServices;
        private int userId;
        private bool isEditing = false;

        public frmProfile(IAccountServices accountServices, int userId)
        {
            InitializeComponent();
            this.accountServices = accountServices;
            this.userId = userId;
            LoadUserInfo();
            //SetReadOnly(true);
        }

        private async void LoadUserInfo()
        {
            try
            {
                var userInfo = await accountServices.ViewProfile(userId);
                if (userInfo != null)
                {
                    txtProfileFirstName.Text = userInfo.FirstName ?? "";
                    txtProfileLastName.Text = userInfo.LastName ?? "";
                    txtProfileEmail.Text = userInfo.Email ?? "";
                    txtProfileHiddenPassword.Text = "********";
                }
                else
                {
                    MessageBox.Show("User not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading profile: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void button1_Click(object sender, EventArgs e) // Save
        {

            MessageBox.Show("Save functionality will be added later.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e) // Cancel
        {

        }
        private void button3_Click(object sender, EventArgs e) // Change Password
        {
            var changePasswordForm = new frmChangePassword(accountServices, userId);
            changePasswordForm.ShowDialog();
        }



        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}