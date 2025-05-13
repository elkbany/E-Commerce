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
    public partial class CategoriesPage : UserControl
    {
        public CategoriesPage()
        {
            InitializeComponent();
        }

        public void AddCategoryToPanel(string categoryName)
        {
            Panel categoryPanel = new Panel();
            categoryPanel.Size = new Size(1586, 50);
            categoryPanel.BackColor = Color.White;
            categoryPanel.BorderStyle = BorderStyle.None;
            categoryPanel.Margin = new Padding(4);

            Label lblNumber = new Label();
            lblNumber.Text = (flowLayoutPanelCategories.Controls.Count + 1).ToString();
            lblNumber.Location = new Point(17, 19);
            lblNumber.Size = new Size(30, 20);
            lblNumber.Font = new Font("Arial", 10);
            categoryPanel.Controls.Add(lblNumber);

            Label lblCategoryName = new Label();
            lblCategoryName.Text = categoryName;
            lblCategoryName.Location = new Point(91, 11);
            lblCategoryName.Size = new Size(150, 20);
            lblCategoryName.Font = new Font("Arial", 10);
            categoryPanel.Controls.Add(lblCategoryName);

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
                AddCategory editForm = new AddCategory(flowLayoutPanelCategories);
                editForm.txtCategoryName.Text = lblCategoryName.Text;

                DialogResult result = editForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    lblCategoryName.Text = editForm.CategoryName;
                    MessageBox.Show("Category updated successfully!");
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
            categoryPanel.Controls.Add(btnEdit);

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
            btnDelete.Click += (sender, e) => { categoryPanel.Parent.Controls.Remove(categoryPanel); };
            categoryPanel.Controls.Add(btnDelete);

            flowLayoutPanelCategories.Controls.Add(categoryPanel);
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            AddCategory addForm = new AddCategory(flowLayoutPanelCategories);
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                string categoryName = addForm.CategoryName;
                AddCategoryToPanel(categoryName);
            }
        }

        //public void AddCategoryToPanel(string name, decimal price, int unitsInStock, string category)
        //{
        //    Panel categoryPanel = new Panel();
        //    categoryPanel.Size = new Size(1586, 50);
        //    categoryPanel.BackColor = Color.White;
        //    categoryPanel.BorderStyle = BorderStyle.None;
        //    categoryPanel.Margin = new Padding(4);

        //    Label lblNumber = new Label();
        //    lblNumber.Text = "1";
        //    lblNumber.Location = new Point(17, 19);
        //    lblNumber.Size = new Size(30, 20);
        //    lblNumber.Font = new Font("Arial", 10);
        //    categoryPanel.Controls.Add(lblNumber);

        //    Label lblName = new Label();
        //    lblName.Text = name;
        //    lblName.Location = new Point(91, 11);
        //    lblName.Size = new Size(100, 20);
        //    lblName.Font = new Font("Arial", 10);
        //    categoryPanel.Controls.Add(lblName);

        //    Label lblPrice = new Label();
        //    lblPrice.Text = price.ToString("C");
        //    lblPrice.Location = new Point(404, 11);
        //    lblPrice.Size = new Size(100, 20);
        //    lblPrice.Font = new Font("Arial", 10);
        //    categoryPanel.Controls.Add(lblPrice);

        //    Label lblUnitsInStock = new Label();
        //    lblUnitsInStock.Text = unitsInStock.ToString();
        //    lblUnitsInStock.Location = new Point(774, 11);
        //    lblUnitsInStock.Size = new Size(100, 20);
        //    lblUnitsInStock.Font = new Font("Arial", 10);
        //    categoryPanel.Controls.Add(lblUnitsInStock);

        //    Label lblCategory = new Label();
        //    lblCategory.Text = category;
        //    lblCategory.Location = new Point(1124, 11);
        //    lblCategory.Size = new Size(100, 20);
        //    lblCategory.Font = new Font("Arial", 10);
        //    categoryPanel.Controls.Add(lblCategory);

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
        //            MessageBox.Show("Category updated successfully!");
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
        //    categoryPanel.Controls.Add(btnEdit);

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
        //    btnDelete.Click += (sender, e) => { categoryPanel.Parent.Controls.Remove(categoryPanel); };
        //    categoryPanel.Controls.Add(btnDelete);

        //    flowLayoutPanelCategories.Controls.Add(categoryPanel);
        //}

        //private void btnAddCategory_Click(object sender, EventArgs e)
        //{
        //    AddForm addForm = new AddForm(flowLayoutPanelCategories);
        //    if (addForm.ShowDialog() == DialogResult.OK)
        //    {
        //        string categoryName = addForm.ProductName;
        //        decimal categoryPrice = addForm.ProductPrice;
        //        int unitsInStock = addForm.UnitsInStock;
        //        string category = addForm.Category;

        //        AddCategoryToPanel(categoryName, categoryPrice, unitsInStock, category);
        //    }
        //}

        //public void AddCategoryToPanel(string name, decimal price, int unitsInStock, string category)
        //{
        //    Panel categoryPanel = new Panel();
        //    categoryPanel.Size = new Size(1586, 50);
        //    categoryPanel.BackColor = Color.White;
        //    categoryPanel.BorderStyle = BorderStyle.None;
        //    categoryPanel.Margin = new Padding(4);

        //    Label lblNumber = new Label();
        //    lblNumber.Text = "1";
        //    lblNumber.Location = new Point(17, 19);
        //    lblNumber.Size = new Size(30, 20);
        //    lblNumber.Font = new Font("Arial", 10);
        //    categoryPanel.Controls.Add(lblNumber);

        //    Label lblName = new Label();
        //    lblName.Text = name;
        //    lblName.Location = new Point(91, 11);
        //    lblName.Size = new Size(100, 20);
        //    lblName.Font = new Font("Arial", 10);
        //    categoryPanel.Controls.Add(lblName);

        //    Label lblPrice = new Label();
        //    lblPrice.Text = price.ToString("C");
        //    lblPrice.Location = new Point(404, 11);
        //    lblPrice.Size = new Size(100, 20);
        //    lblPrice.Font = new Font("Arial", 10);
        //    categoryPanel.Controls.Add(lblPrice);

        //    Label lblUnitsInStock = new Label();
        //    lblUnitsInStock.Text = unitsInStock.ToString();
        //    lblUnitsInStock.Location = new Point(774, 11);
        //    lblUnitsInStock.Size = new Size(100, 20);
        //    lblUnitsInStock.Font = new Font("Arial", 10);
        //    categoryPanel.Controls.Add(lblUnitsInStock);

        //    Label lblCategory = new Label();
        //    lblCategory.Text = category;
        //    lblCategory.Location = new Point(1124, 11);
        //    lblCategory.Size = new Size(100, 20);
        //    lblCategory.Font = new Font("Arial", 10);
        //    categoryPanel.Controls.Add(lblCategory);

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
        //    btnEdit.Click += (sender, e) =>
        //    {
        //        decimal priceValue;
        //        decimal.TryParse(lblPrice.Text.Replace("$", ""), out priceValue);
        //        int unitsValue;
        //        int.TryParse(lblUnitsInStock.Text, out unitsValue);

        //        E_Commerce.Presentation.EditForm editForm = new E_Commerce.Presentation.EditForm(lblName.Text, priceValue, unitsValue, lblCategory.Text);
        //        DialogResult result = editForm.ShowDialog();
        //        if (result == DialogResult.OK)
        //        {
        //            lblName.Text = editForm.ProductName;
        //            lblPrice.Text = editForm.ProductPrice.ToString("C");
        //            lblUnitsInStock.Text = editForm.UnitsInStock.ToString();
        //            lblCategory.Text = editForm.Category;
        //            MessageBox.Show("Category updated successfully!");
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
        //    categoryPanel.Controls.Add(btnEdit);

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
        //    btnDelete.Click += (sender, e) => { categoryPanel.Parent.Controls.Remove(categoryPanel); };
        //    categoryPanel.Controls.Add(btnDelete);

        //    flowLayoutPanelCategories.Controls.Add(categoryPanel);
        //}

    }
}
