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
using E_Commerce.BL.Contracts.Services;
using E_Commerce.BL.Features.Product.DTOs;
using FluentValidation;

namespace E_Commerce.Presentation
{
    public partial class ProductsPage : UserControl
    {
        private readonly IProductServices _productServices; public ProductsPage(IProductServices productServices)
        {
            _productServices = productServices; 
            InitializeComponent();
            LoadProducts(); 
        }

    public async void LoadProducts()
        {
            flowLayoutPanelProducts.Controls.Clear();
            var products = await _productServices.GetAllProductsAsync();

            foreach (var product in products)
            {
                AddProductToPanel(product.Name, product.Price, product.UnitsInStock, product.Category);
            }
        }

        public void AddProductToPanel(string name, decimal price, int unitsInStock, string category)
        {
            Panel productPanel = new Panel();
            productPanel.Size = new Size(1586, 50);
            productPanel.BackColor = Color.White;
            productPanel.BorderStyle = BorderStyle.None;
            productPanel.Margin = new Padding(4);

            Label lblNumber = new Label();
            lblNumber.Text = "1";
            lblNumber.Location = new Point(17, 19);
            lblNumber.Size = new Size(30, 20);
            lblNumber.Font = new Font("Arial", 10);
            productPanel.Controls.Add(lblNumber);

            Label lblName = new Label();
            lblName.Text = name;
            lblName.Location = new Point(91, 11);
            lblName.Size = new Size(100, 20);
            lblName.Font = new Font("Arial", 10);
            productPanel.Controls.Add(lblName);

            Label lblPrice = new Label();
            lblPrice.Text = price.ToString("C");
            lblPrice.Location = new Point(404, 11);
            lblPrice.Size = new Size(100, 20);
            lblPrice.Font = new Font("Arial", 10);
            productPanel.Controls.Add(lblPrice);

            Label lblUnitsInStock = new Label();
            lblUnitsInStock.Text = unitsInStock.ToString();
            lblUnitsInStock.Location = new Point(774, 11);
            lblUnitsInStock.Size = new Size(100, 20);
            lblUnitsInStock.Font = new Font("Arial", 10);
            productPanel.Controls.Add(lblUnitsInStock);

            Label lblCategory = new Label();
            lblCategory.Text = category;
            lblCategory.Location = new Point(1124, 11);
            lblCategory.Size = new Size(100, 20);
            lblCategory.Font = new Font("Arial", 10);
            productPanel.Controls.Add(lblCategory);

            // زرار Edit (باستخدام Guna2Button)
            Guna.UI2.WinForms.Guna2Button btnEdit = new Guna.UI2.WinForms.Guna2Button
            {
                Text = "Edit",
                Location = new Point(1452, 10),
                Size = new Size(80, 30),
                FillColor = Color.FromArgb(0, 174, 239), // لون مشابه لـ Color.Cyan
                ForeColor = Color.White,
                BorderRadius = 5,
                
            }; 
            btnEdit.Click += (sender, e) => {
                decimal priceValue;
                decimal.TryParse(lblPrice.Text.Replace("$", ""), out priceValue);
                int unitsValue;
                int.TryParse(lblUnitsInStock.Text, out unitsValue);

                // Pass the required dependencies to the EditForm constructor
                EditForm editForm = new EditForm(
                    lblName.Text,
                    priceValue,
                    unitsValue,
                    lblCategory.Text,
                    _productServices,
                    ServiceProviderContainer.ServiceProvider.GetRequiredService<IValidator<AddProductDTO>>(),
                    ServiceProviderContainer.ServiceProvider.GetRequiredService<ICategoryServices>()
                );

                DialogResult result = editForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    lblName.Text = editForm.ProductName;
                    lblPrice.Text = editForm.ProductPrice.ToString("C");
                    lblUnitsInStock.Text = editForm.UnitsInStock.ToString();
                    lblCategory.Text = editForm.Category;
                    MessageBox.Show("Product updated successfully!");
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
            productPanel.Controls.Add(btnEdit);

            // زرار Delete (باستخدام Guna2Button)
            Guna.UI2.WinForms.Guna2Button btnDelete = new Guna.UI2.WinForms.Guna2Button
            {
                Text = "Delete",
                Location = new Point(1537, 10),
                Size = new Size(80, 30),
                FillColor = Color.FromArgb(229, 105, 151),
                ForeColor = Color.White,
                BorderRadius = 5
            };
            btnDelete.Click += (s, e) => DeleteProduct(productPanel, name);
            productPanel.Controls.Add(btnDelete);

            flowLayoutPanelProducts.Controls.Add(productPanel);
        }

        //private void DeleteProduct(Panel productPanel, string productName)
        //{
        //    DialogResult result = MessageBox.Show(
        //        $"Are you sure you want to delete the product '{productName}'?",
        //        "Confirm Delete",
        //        MessageBoxButtons.YesNo,
        //        MessageBoxIcon.Warning
        //    );

        //    if (result == DialogResult.Yes)
        //    {
        //        // هنا هيحصل الحذف من قاعدة البيانات في المستقبل
        //        // مثلاً: await _productServices.DeleteProductAsync(productId);
        //        productPanel.Parent.Controls.Remove(productPanel); // حذف المنتج من الواجهة
        //        MessageBox.Show("Product deleted successfully!");
        //    }
        //}
        private async void DeleteProduct(Panel productPanel, string productName)
        {
            var product = await _productServices.GetProductByName(productName);
            var productId = product.Id; 
            DialogResult result = MessageBox.Show(
                $"Are you sure you want to delete the product '{productName}'?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    // First delete from database
                    await _productServices.DeleteProductAsync(productId);

                    // Then remove from UI
                    productPanel.Parent.Controls.Remove(productPanel);
                    MessageBox.Show("Product deleted successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting product: {ex.Message}",
                                   "Error",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Error);
                }
            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            var addForm = ServiceProviderContainer.ServiceProvider.GetRequiredService<AddForm>();

            // Subscribe to the ProductAdded event
            addForm.ProductAdded += (s, args) =>
            {
                // Add the new product to the panel
                AddProductToPanel(
                    args.Product.Name,
                    args.Product.Price,
                    args.Product.UnitsInStock,
                    args.Product.Category
                );
            };
            addForm.ShowDialog();
            // Clean up the event handler
            addForm.ProductAdded -= (s, args) => { };
        }
    }

}