using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E_Commerce.Presentation
{
    public partial class UsersPage : UserControl
    {
        public UsersPage()
        {
            InitializeComponent();
        }

        public void AddUserToPanel(string username, string email, string password, string status)
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

            Label lblUsername = new Label();
            lblUsername.Text = username;
            lblUsername.Location = new Point(91, 11);
            lblUsername.Size = new Size(150, 20);
            lblUsername.Font = new Font("Arial", 10);
            userPanel.Controls.Add(lblUsername);

            Label lblEmail = new Label();
            lblEmail.Text = email;
            lblEmail.Location = new Point(404, 11);
            lblEmail.Size = new Size(200, 20);
            lblEmail.Font = new Font("Arial", 10);
            userPanel.Controls.Add(lblEmail);

            Label lblPassword = new Label();
            lblPassword.Text = password;
            lblPassword.Location = new Point(774, 11);
            lblPassword.Size = new Size(150, 20);
            lblPassword.Font = new Font("Arial", 10);
            userPanel.Controls.Add(lblPassword);

            Label lblStatus = new Label();
            lblStatus.Text = status;
            lblStatus.Location = new Point(1124, 11);
            lblStatus.Size = new Size(100, 20);
            lblStatus.Font = new Font("Arial", 10);
            userPanel.Controls.Add(lblStatus);

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
                editForm.txtUserName.Text = lblUsername.Text;
                editForm.txtUserEmail.Text = lblEmail.Text;
                editForm.txtUserPassword.Text = lblPassword.Text;
                editForm.txtUserStatus.Text = lblStatus.Text;

                DialogResult result = editForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    lblUsername.Text = editForm.UserName;
                    lblEmail.Text = editForm.UserEmail;
                    lblPassword.Text = editForm.UserPassword;
                    lblStatus.Text = editForm.UserStatus;
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
            AddUser addForm = new AddUser(flowLayoutPanelUsers);
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                string username = addForm.UserName;
                string email = addForm.UserEmail;
                string password = addForm.UserPassword;
                string status = addForm.UserStatus;

                AddUserToPanel(username, email, password, status);
            }
        }

        //public void AddUserToPanel(string name, decimal price, int unitsInStock, string category)
        //{
        //    Panel userPanel = new Panel();
        //    userPanel.Size = new Size(1586, 50);
        //    userPanel.BackColor = Color.White;
        //    userPanel.BorderStyle = BorderStyle.None;
        //    userPanel.Margin = new Padding(4);

        //    Label lblNumber = new Label();
        //    lblNumber.Text = "1";
        //    lblNumber.Location = new Point(17, 19);
        //    lblNumber.Size = new Size(30, 20);
        //    lblNumber.Font = new Font("Arial", 10);
        //    userPanel.Controls.Add(lblNumber);

        //    Label lblName = new Label();
        //    lblName.Text = name;
        //    lblName.Location = new Point(91, 11);
        //    lblName.Size = new Size(100, 20);
        //    lblName.Font = new Font("Arial", 10);
        //    userPanel.Controls.Add(lblName);

        //    Label lblPrice = new Label();
        //    lblPrice.Text = price.ToString("C");
        //    lblPrice.Location = new Point(404, 11);
        //    lblPrice.Size = new Size(100, 20);
        //    lblPrice.Font = new Font("Arial", 10);
        //    userPanel.Controls.Add(lblPrice);

        //    Label lblUnitsInStock = new Label();
        //    lblUnitsInStock.Text = unitsInStock.ToString();
        //    lblUnitsInStock.Location = new Point(774, 11);
        //    lblUnitsInStock.Size = new Size(100, 20);
        //    lblUnitsInStock.Font = new Font("Arial", 10);
        //    userPanel.Controls.Add(lblUnitsInStock);

        //    Label lblCategory = new Label();
        //    lblCategory.Text = category;
        //    lblCategory.Location = new Point(1124, 11);
        //    lblCategory.Size = new Size(100, 20);
        //    lblCategory.Font = new Font("Arial", 10);
        //    userPanel.Controls.Add(lblCategory);

        //    Button btnEdit = new Button();
        //    btnEdit.Text = "";
        //    btnEdit.Size = new Size(25, 25);
        //    btnEdit.Location = new Point(1482, 7);
        //    btnEdit.FlatStyle = FlatStyle.Flat;
        //    btnEdit.BackColor = Color.Transparent;
        //    btnEdit.FlatAppearance.BorderColor = Color.Cyan;
        //    btnEdit.FlatAppearance.BorderSize = 1;
        //    btnEdit.BackgroundImage = Image.FromFile(@"C:\Users\user\Downloads\edit_24dp_05E0E9_FILL0_wght400_GRAD0_opsz24.png");
        //    btnEdit.BackgroundImageLayout = ImageLayout.Zoom;
        //    btnEdit.Click += (sender, e) => {
        //        decimal priceValue;
        //        decimal.TryParse(lblPrice.Text.Replace("$", ""), out priceValue);
        //        int unitsValue;
        //        int.TryParse(lblUnitsInStock.Text, out unitsValue);

        //        EditForm editForm = new EditForm(lblName.Text, priceValue, unitsValue, lblCategory.Text);
        //        DialogResult result = editForm.ShowDialog();
        //        if (result == DialogResult.OK)
        //        {
        //            lblName.Text = editForm.ProductName;
        //            lblPrice.Text = editForm.ProductPrice.ToString("C");
        //            lblUnitsInStock.Text = editForm.UnitsInStock.ToString();
        //            lblCategory.Text = editForm.Category;
        //            MessageBox.Show("User updated successfully!");
        //        }
        //        else if (result == DialogResult.Cancel)
        //        {
        //            MessageBox.Show("Edit canceled.");
        //        }
        //        else
        //        {
        //            MessageBox.Show("Unexpected dialog result: " + result.ToString());
        //        }
        //    };
        //    userPanel.Controls.Add(btnEdit);

        //    Button btnDelete = new Button();
        //    btnDelete.Text = "";
        //    btnDelete.Size = new Size(25, 25);
        //    btnDelete.Location = new Point(1537, 7);
        //    btnDelete.FlatStyle = FlatStyle.Flat;
        //    btnDelete.BackColor = Color.Transparent;
        //    btnDelete.FlatAppearance.BorderColor = Color.IndianRed;
        //    btnDelete.FlatAppearance.BorderSize = 2;
        //    btnDelete.BackgroundImage = Image.FromFile(@"C:\Users\user\Downloads\delete_24dp_FF2768_FILL0_wght400_GRAD0_opsz24.png");
        //    btnDelete.BackgroundImageLayout = ImageLayout.Zoom;
        //    btnDelete.Click += (sender, e) => { userPanel.Parent.Controls.Remove(userPanel); };
        //    userPanel.Controls.Add(btnDelete);

        //    flowLayoutPanelUsers.Controls.Add(userPanel);
        //}

        //private void btnAddUser_Click(object sender, EventArgs e)
        //{
        //    AddForm addForm = new AddForm(flowLayoutPanelUsers);
        //    if (addForm.ShowDialog() == DialogResult.OK)
        //    {
        //        string userName = addForm.ProductName;
        //        decimal userPrice = addForm.ProductPrice;
        //        int unitsInStock = addForm.UnitsInStock;
        //        string category = addForm.Category;

        //        AddUserToPanel(userName, userPrice, unitsInStock, category);
        //    }
        //}


    }
}
