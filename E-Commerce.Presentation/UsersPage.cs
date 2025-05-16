using System;
using System.Collections.Generic;
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
        //private FlowLayoutPanel targetPanel;
        public UsersPage()
        {
            InitializeComponent();
        }

        public void AddUserToPanel(string firstName, string lastName, string username, string email, string password, string status, string isActive)
        {
            Panel userPanel = new Panel();
            userPanel.Size = new Size(1586, 50);
            userPanel.BackColor = Color.White;
            userPanel.BorderStyle = BorderStyle.None;
            userPanel.Margin = new Padding(4);

            Label lblNumber = new Label();
            lblNumber.Text = (flowLayoutPanelUsers.Controls.Count + 1).ToString();
            lblNumber.Location = new Point(17, 19);
            lblNumber.Size = new Size(30, 20);
            lblNumber.Font = new Font("Arial", 10);
            userPanel.Controls.Add(lblNumber);

            Label lblFirstName = new Label();
            lblFirstName.Text = firstName;
            lblFirstName.Location = new Point(72, 11);
            lblFirstName.Size = new Size(100, 20);
            lblFirstName.Font = new Font("Arial", 10);
            userPanel.Controls.Add(lblFirstName);

            Label lblLastName = new Label();
            lblLastName.Text = lastName;
            lblLastName.Location = new Point(290, 11);
            lblLastName.Size = new Size(100, 20);
            lblLastName.Font = new Font("Arial", 10);
            userPanel.Controls.Add(lblLastName);

            Label lblUsername = new Label();
            lblUsername.Text = username;
            lblUsername.Location = new Point(475, 11);
            lblUsername.Size = new Size(100, 20);
            lblUsername.Font = new Font("Arial", 10);
            userPanel.Controls.Add(lblUsername);

            Label lblEmail = new Label();
            lblEmail.Text = email;
            lblEmail.Location = new Point(690, 11);
            lblEmail.Size = new Size(200, 20);
            lblEmail.Font = new Font("Arial", 10);
            userPanel.Controls.Add(lblEmail);

            Label lblPassword = new Label();
            lblPassword.Text = password;
            lblPassword.Location = new Point(895, 11);
            lblPassword.Size = new Size(150, 20);
            lblPassword.Font = new Font("Arial", 10);
            userPanel.Controls.Add(lblPassword);

            Label lblStatus = new Label();
            lblStatus.Text = status;
            lblStatus.Location = new Point(1110, 11);
            lblStatus.Size = new Size(100, 20);
            lblStatus.Font = new Font("Arial", 10);
            userPanel.Controls.Add(lblStatus);

            Label lblIsActive = new Label();
            lblIsActive.Text = isActive;
            lblIsActive.Location = new Point(1300, 11);
            lblIsActive.Size = new Size(50, 20);
            lblIsActive.Font = new Font("Arial", 10);
            userPanel.Controls.Add(lblIsActive);

            Button btnEdit = new Button();
            btnEdit.Text = "";
            btnEdit.Size = new Size(25, 25);
            btnEdit.Location = new Point(1482, 7);
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.BackColor = Color.Transparent;
            btnEdit.FlatAppearance.BorderColor = Color.Cyan;
            btnEdit.FlatAppearance.BorderSize = 1;
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

            Button btnDelete = new Button();
            btnDelete.Text = "";
            btnDelete.Size = new Size(25, 25);
            btnDelete.Location = new Point(1537, 7);
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.BackColor = Color.Transparent;
            btnDelete.FlatAppearance.BorderColor = Color.IndianRed;
            btnDelete.FlatAppearance.BorderSize = 2;
            btnDelete.BackgroundImage = Image.FromFile(@"C:\Users\user\Downloads\delete_24dp_FF2768_FILL0_wght400_GRAD0_opsz24.png");
            btnDelete.BackgroundImageLayout = ImageLayout.Zoom;
            btnDelete.Click += (sender, e) => { userPanel.Parent.Controls.Remove(userPanel); };
            userPanel.Controls.Add(btnDelete);

            flowLayoutPanelUsers.Controls.Add(userPanel);
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            // 1. Get AddUser from DI container
            //var addForm = ServiceProviderContainer.ServiceProvider.GetRequiredService<AddUser>();

            // 2. Pass the FlowLayoutPanel manually
            //addForm.SetUserPanel(flowLayoutPanelUsers);


            AddUser addForm = new AddUser(flowLayoutPanelUsers);
            // 3. Show dialog and process result
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
