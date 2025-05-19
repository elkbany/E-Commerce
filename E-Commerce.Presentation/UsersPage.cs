using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using E_Commerce.BL.Contracts.Services;
using E_Commerce.BL.Features.User.DTOs;
using E_Commerce.Domain.Enums;

namespace E_Commerce.Presentation
{
    public partial class UsersPage : UserControl
    {
        private readonly IUserServices userServices;

        public UsersPage(IUserServices userServices)
        {
            InitializeComponent();
            this.userServices = userServices;
            if (!DesignMode)
            {
                LoadUsersAsync();
                btnAddUser.Click += btnAddUser_Click;
            }
            this.Resize += (s, e) => RefreshPanels();
        }

        private void RefreshPanels()
        {
            foreach (Control control in flowLayoutPanelUsers.Controls)
            {
                if (control is Panel userPanel)
                {
                    int availableWidth = flowLayoutPanelUsers.ClientSize.Width -
                        (flowLayoutPanelUsers.Padding.Left + flowLayoutPanelUsers.Padding.Right +
                         userPanel.Margin.Left + userPanel.Margin.Right);
                    userPanel.Width = availableWidth;

                    foreach (Control child in userPanel.Controls)
                    {
                        if (child is Label lblNumber && lblNumber.Text == userPanel.Controls[0].Text)
                            lblNumber.Location = new Point(17, 19);
                        else if (child is Label lblFirstName && lblFirstName.Text == userPanel.Controls[1].Text)
                        {
                            lblFirstName.Location = new Point((int)(userPanel.Width * 0.045), 11);
                            lblFirstName.Size = new Size((int)(userPanel.Width * 0.063), 20);
                        }
                        else if (child is Label lblLastName && lblLastName.Text == userPanel.Controls[2].Text)
                        {
                            lblLastName.Location = new Point((int)(userPanel.Width * 0.183), 11);
                            lblLastName.Size = new Size((int)(userPanel.Width * 0.063), 20);
                        }
                        else if (child is Label lblUsername && lblUsername.Text == userPanel.Controls[3].Text)
                        {
                            lblUsername.Location = new Point((int)(userPanel.Width * 0.299), 11);
                            lblUsername.Size = new Size((int)(userPanel.Width * 0.063), 20);
                        }
                        else if (child is Label lblEmail && lblEmail.Text == userPanel.Controls[4].Text)
                        {
                            lblEmail.Location = new Point((int)(userPanel.Width * 0.435), 11);
                            lblEmail.Size = new Size((int)(userPanel.Width * 0.126), 20);
                        }
                        else if (child is Label lblPassword && lblPassword.Text == userPanel.Controls[5].Text)
                        {
                            lblPassword.Location = new Point((int)(userPanel.Width * 0.565), 11);
                            lblPassword.Size = new Size((int)(userPanel.Width * 0.095), 20);
                        }
                        else if (child is Label lblStatus && lblStatus.Text == userPanel.Controls[6].Text)
                        {
                            lblStatus.Location = new Point((int)(userPanel.Width * 0.699), 11);
                            lblStatus.Size = new Size((int)(userPanel.Width * 0.063), 20);
                        }
                        else if (child is Label lblIsActive && lblIsActive.Text == userPanel.Controls[7].Text)
                        {
                            lblIsActive.Location = new Point((int)(userPanel.Width * 0.819), 11);
                            lblIsActive.Size = new Size((int)(userPanel.Width * 0.032), 20);
                        }
                        else if (child is Guna.UI2.WinForms.Guna2Button btnEdit && btnEdit.Text == "Edit")
                            btnEdit.Location = new Point(userPanel.Width - 170, 10);
                        else if (child is Guna.UI2.WinForms.Guna2Button btnDelete && btnDelete.Text == "Delete")
                            btnDelete.Location = new Point(userPanel.Width - 90, 10);
                    }
                }
            }
        }

        public void AddUserToPanel(string firstName, string lastName, string username, string email, string password, string status, string isActive, int index)
        {
            Panel userPanel = new Panel
            {
                Height = 50,
                BackColor = Color.White,
                BorderStyle = BorderStyle.None,
                Margin = new Padding(4)
            };

            int availableWidth = flowLayoutPanelUsers.ClientSize.Width -
                (flowLayoutPanelUsers.Padding.Left + flowLayoutPanelUsers.Padding.Right +
                 userPanel.Margin.Left + userPanel.Margin.Right);
            userPanel.Width = availableWidth;

            userPanel.Controls.Add(new Label
            {
                Text = index.ToString(),
                Location = new Point(17, 19),
                Size = new Size(30, 20),
                Font = new Font("Arial", 10)
            });

            userPanel.Controls.Add(new Label
            {
                Text = firstName,
                Location = new Point((int)(userPanel.Width * 0.045), 11),
                Size = new Size((int)(userPanel.Width * 0.063), 20),
                Font = new Font("Arial", 10)
            });

            userPanel.Controls.Add(new Label
            {
                Text = lastName,
                Location = new Point((int)(userPanel.Width * 0.180), 11),
                Size = new Size((int)(userPanel.Width * 0.063), 20),
                Font = new Font("Arial", 10)
            });

            userPanel.Controls.Add(new Label
            {
                Text = username,
                Location = new Point((int)(userPanel.Width * 0.299), 11),
                Size = new Size((int)(userPanel.Width * 0.063), 20),
                Font = new Font("Arial", 10)
            });

            userPanel.Controls.Add(new Label
            {
                Text = email,
                Location = new Point((int)(userPanel.Width * 0.435), 11),
                Size = new Size((int)(userPanel.Width * 0.126), 20),
                Font = new Font("Arial", 10)
            });

            userPanel.Controls.Add(new Label
            {
                Text = password,
                Location = new Point((int)(userPanel.Width * 0.565), 11),
                Size = new Size((int)(userPanel.Width * 0.095), 20),
                Font = new Font("Arial", 10)
            });

            userPanel.Controls.Add(new Label
            {
                Text = status,
                Location = new Point((int)(userPanel.Width * 0.699), 11),
                Size = new Size((int)(userPanel.Width * 0.063), 20),
                Font = new Font("Arial", 10)
            });

            userPanel.Controls.Add(new Label
            {
                Text = isActive,
                Location = new Point((int)(userPanel.Width * 0.819), 11),
                Size = new Size((int)(userPanel.Width * 0.032), 20),
                Font = new Font("Arial", 10)
            });

            Guna.UI2.WinForms.Guna2Button btnEdit = new Guna.UI2.WinForms.Guna2Button
            {
                Text = "Edit",
                Location = new Point(userPanel.Width - 170, 10),
                Size = new Size(75, 30),
                FillColor = Color.FromArgb(102, 210, 214),
                ForeColor = Color.White,
                BorderRadius = 5
            };
            btnEdit.Click += async (sender, e) =>
            {
                AddUser editForm = new AddUser(flowLayoutPanelUsers);
                editForm.txtFirstName.Text = firstName;
                editForm.txtLastName.Text = lastName;
                editForm.txtUserName.Text = username;
                editForm.txtUserEmail.Text = email;
                editForm.txtUserPassword.Text = password;
                editForm.txtUserStatus.Text = status;
                if (isActive == "Yes")
                    editForm.btnActive1.Checked = true;
                else
                    editForm.btnActive2.Checked = true;

                DialogResult result = editForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    try
                    {
                        var userId = userServices.GetUserByNameAsync(username).Result.Id;
                        var updateDto = new UpdateUserAccountDTO
                        {
                            Email = editForm.txtUserEmail.Text,
                            FirstName = editForm.txtFirstName.Text,
                            LastName = editForm.txtLastName.Text,
                            Role = editForm.txtUserStatus.Text=="User"? UserStatus.Client : UserStatus.Admin,
                            ActiveOrNot = isActive=="Yes" ? true : false,


                        };
                        var updatedUser= userServices.Update(userId, updateDto).Result;
                        email = updatedUser.Email;
                        firstName = updatedUser.FirstName;
                        lastName = updatedUser.LastName;
                        isActive = updatedUser.ActiveOrNot==true?"Yes":"No";
                        status = updatedUser.Role == UserStatus.Client ? "User" : "Admin";


                        MessageBox.Show("User updated successfully!");
                    }
                    catch(Exception ex)
                    { 
                    MessageBox.Show(ex.Message);
                    }
                }
                else if (result == DialogResult.Cancel)
                    MessageBox.Show("Edit canceled.");
                else
                    MessageBox.Show("Unexpected dialog result: " + result.ToString());

                await LoadUsersAsync();
            };
            userPanel.Controls.Add(btnEdit);

            Guna.UI2.WinForms.Guna2Button btnDelete = new Guna.UI2.WinForms.Guna2Button
            {
                Text = "Delete",
                Location = new Point(userPanel.Width - 90, 10),
                Size = new Size(75, 30),
                FillColor = Color.FromArgb(229, 105, 151),
                ForeColor = Color.White,
                BorderRadius = 5
            };
            btnDelete.Click += (s, e) => DeleteItem(userPanel, username);
            userPanel.Controls.Add(btnDelete); 

            flowLayoutPanelUsers.Controls.Add(userPanel); 
        }

        private async void DeleteItem(Panel panel, string username)
        {
            DialogResult result = MessageBox.Show($"Are you sure you want to delete the user '{username}'?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                try
                {
                    await userServices.Delete(username);
                    panel.Parent.Controls.Remove(panel);
                    MessageBox.Show("User deleted successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting user: {ex.Message}");
                }
            }
            await LoadUsersAsync();
        }

        private async Task LoadUsersAsync()
        {
            try
            {
                this.RefreshPanels();
                var users = await userServices.getAllClient();
                if (flowLayoutPanelUsers.InvokeRequired)
                {
                    flowLayoutPanelUsers.Invoke(new Action(() =>
                    {
                        flowLayoutPanelUsers.Controls.Clear();
                        int index = 1;
                        foreach (var u in users)
                            AddUserToPanel(u.FirstName, u.LastName, u.Username, u.Email, u.Password, u.Status, u.IsActive, index++);
                    }));
                }
                else
                {
                    flowLayoutPanelUsers.Controls.Clear();
                    int index = 1;
                    foreach (var u in users)
                        AddUserToPanel(u.FirstName, u.LastName, u.Username, u.Email, u.Password, u.Status, u.IsActive, index++);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading users: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnAddUser_Click(object sender, EventArgs e)
        {
            AddUser addForm = new AddUser(flowLayoutPanelUsers);
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string firstName = addForm.FirstName;
                    string lastName = addForm.LastName;
                    string username = addForm.UserName;
                    string email = addForm.UserEmail;
                    string password = addForm.UserPassword;
                    string status = addForm.UserStatus == "User" ? "Client" : "Admin";
                    string isActive = addForm.IsActive;

                    var (user, ActiveStatus) = await userServices.AddUserAsync(new UserDTO
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        Username = username,
                        Email = email,
                        Password = password,
                        status = (UserStatus)Enum.Parse(typeof(UserStatus), status)
                    });
                    var count = userServices.getAllClient().Result.Count;
                    AddUserToPanel(user.FirstName, user.LastName, user.Username, user.Email, user.Password, user.status.ToString(), ActiveStatus.ToString(), count++);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error adding user: {ex.Message}");
                }
            }
            await LoadUsersAsync();
        }
    }
}