using E_Commerce.BL.Contracts.Services;
using E_Commerce.BL.Features.User.DTOs;
using Microsoft.AspNetCore.Identity;
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
                lnlOldPassword.PasswordChar = '\0';
            }
            else
            {
                lblNewPassword1.PasswordChar = '*';
                lblNewPassword2.PasswordChar = '*';
                lnlOldPassword.PasswordChar = '*';
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
            try
            {
                // Validate all fields are filled
                if (string.IsNullOrWhiteSpace(lnlOldPassword.Text) ||
                    string.IsNullOrWhiteSpace(lblNewPassword1.Text) ||
                    string.IsNullOrWhiteSpace(lblNewPassword2.Text))
                {
                    MessageBox.Show("Please fill in all password fields.", "Validation Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validate new password length
                if (lblNewPassword1.Text.Length < 6)
                {
                    MessageBox.Show("New password must be at least 6 characters long.", "Validation Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validate password match
                if (lblNewPassword1.Text != lblNewPassword2.Text)
                {
                    MessageBox.Show("New passwords do not match.", "Validation Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Verify old password
                if (!await accountServices.VerifyPasswordAsync(userId, lnlOldPassword.Text))
                {
                    MessageBox.Show("Old password is incorrect.", "Validation Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Confirm password change
                if (MessageBox.Show("Are you sure you want to change your password?", "Confirmation",
                                  MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    return;
                }

                // Update password
                var updateDto = new UpdateUserDto
                {
                    Id = userId,
                    Password = lblNewPassword1.Text
                };

                bool isUpdated = await accountServices.UpdateUserAsync(updateDto);

                if (isUpdated)
                {
                    MessageBox.Show("Password changed successfully!", "Success",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to update password. Please try again.", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Validation Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                string errorMessage = "An error occurred while changing your password.";
                if (ex.InnerException != null)
                {
                    errorMessage += $"\n\nTechnical details: {ex.InnerException.Message}";
                }

                MessageBox.Show(errorMessage, "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}