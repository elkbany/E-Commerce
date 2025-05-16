using System;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace E_Commerce.Presentation
{
    public partial class UsersPage : UserControl
    {
        public UsersPage() { InitializeComponent(); }

        public void AddUserToPanel(string firstName, string lastName, string username, string email, string password, string status, string isActive)
        {
            Panel userPanel = new Panel
            {
                Size = new Size(1586, 50),
                BackColor = Color.White,
                BorderStyle = BorderStyle.None,
                Margin = new Padding(4)
            };

            Label lblNumber = new Label
            {
                Text = (flowLayoutPanelUsers.Controls.Count + 1).ToString(),
                Location = new Point(17, 19),
                Size = new Size(30, 20),
                Font = new Font("Arial", 10)
            };
            userPanel.Controls.Add(lblNumber);

            Label lblFirstName = new Label
            {
                Text = firstName,
                Location = new Point(72, 11),
                Size = new Size(100, 20),
                Font = new Font("Arial", 10)
            };
            userPanel.Controls.Add(lblFirstName);

            Label lblLastName = new Label
            {
                Text = lastName,
                Location = new Point(290, 11),
                Size = new Size(100, 20),
                Font = new Font("Arial", 10)
            };
            userPanel.Controls.Add(lblLastName);

            Label lblUsername = new Label
            {
                Text = username,
                Location = new Point(475, 11),
                Size = new Size(100, 20),
                Font = new Font("Arial", 10)
            };
            userPanel.Controls.Add(lblUsername);

            Label lblEmail = new Label
            {
                Text = email,
                Location = new Point(690, 11),
                Size = new Size(200, 20),
                Font = new Font("Arial", 10)
            };
            userPanel.Controls.Add(lblEmail);

            Label lblPassword = new Label
            {
                Text = password,
                Location = new Point(895, 11),
                Size = new Size(150, 20),
                Font = new Font("Arial", 10)
            };
            userPanel.Controls.Add(lblPassword);

            Label lblStatus = new Label
            {
                Text = status,
                Location = new Point(1110, 11),
                Size = new Size(100, 20),
                Font = new Font("Arial", 10)
            };
            userPanel.Controls.Add(lblStatus);

            Label lblIsActive = new Label
            {
                Text = isActive,
                Location = new Point(1300, 11),
                Size = new Size(50, 20),
                Font = new Font("Arial", 10)
            };
            userPanel.Controls.Add(lblIsActive);

            // زر Edit
            Button btnEdit = new Button
            {
                Text = "",
                Size = new Size(25, 25),
                Location = new Point(1482, 7),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.Transparent,
                FlatAppearance = { BorderColor = Color.Cyan, BorderSize = 1 }
            };
            btnEdit.BackgroundImage = Image.FromFile(@"C:\Users\user\Downloads\edit_24dp_05E0E9_FILL0_wght400_GRAD0_opsz24.png");
            btnEdit.BackgroundImageLayout = ImageLayout.Zoom;
            btnEdit.Click += (sender, e) => {
                AddUser editForm = new AddUser(flowLayoutPanelUsers);
                editForm.txtFirstName.Text = lblFirstName.Text;
                editForm.txtLastName.Text = lblLastName.Text;
                editForm.txtUserName.Text = lblUsername.Text;
                editForm.txtUserEmail.Text = lblEmail.Text;
                editForm.txtUserPassword.Text = lblPassword.Text;
                editForm.txtUserStatus.Text = lblStatus.Text;
                if (lblIsActive.Text == "Yes")
                    editForm.btnActive1.Checked = true;
                else
                    editForm.btnActive2.Checked = true;

                DialogResult result = editForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    lblFirstName.Text = editForm.FirstName;
                    lblLastName.Text = editForm.LastName;
                    lblUsername.Text = editForm.UserName;
                    lblEmail.Text = editForm.UserEmail;
                    lblPassword.Text = editForm.UserPassword;
                    lblStatus.Text = editForm.UserStatus;
                    lblIsActive.Text = editForm.IsActive;
                    MessageBox.Show("User updated successfully!");
                }
                else if (result == DialogResult.Cancel)
                {
                    MessageBox.Show("Edit canceled.");
                }
                else
                {
                    MessageBox.Show("Unexpected dialog result: " + result.ToString());
                }
            };
            userPanel.Controls.Add(btnEdit);

            // زر Delete
            Guna.UI2.WinForms.Guna2Button btnDelete = new Guna.UI2.WinForms.Guna2Button
            {
                Text = "Delete",
                Location = new Point(1537, 10),
                Size = new Size(80, 30),
                FillColor = Color.FromArgb(229, 105, 151),
                ForeColor = Color.White,
                BorderRadius = 5
            };
            btnDelete.Click += (s, e) => DeleteItem(userPanel, username);
            userPanel.Controls.Add(btnDelete);

            flowLayoutPanelUsers.Controls.Add(userPanel);
        }

        private void DeleteItem(Panel panel, string username)
        {
            DialogResult result = MessageBox.Show($"Are you sure you want to delete the user '{username}'?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                // هنا هيحصل الحذف من قاعدة البيانات في المستقبل
                // مثلاً: DeleteFromDatabase(username);
                panel.Parent.Controls.Remove(panel); // حذف الصف من الواجهة
                MessageBox.Show("User deleted successfully!");
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            AddUser addForm = new AddUser(flowLayoutPanelUsers);
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                string firstName = addForm.FirstName;
                string lastName = addForm.LastName;
                string username = addForm.UserName;
                string email = addForm.UserEmail;
                string password = addForm.UserPassword;
                string status = addForm.UserStatus;
                string isActive = addForm.IsActive;

                AddUserToPanel(firstName, lastName, username, email, password, status, isActive);
            }
        }
    }

}