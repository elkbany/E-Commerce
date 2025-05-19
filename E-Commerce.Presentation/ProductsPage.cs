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
        private readonly IProductServices _productServices;

        public ProductsPage(IProductServices productServices)
        {
            _productServices = productServices;
            InitializeComponent();
            LoadProducts();

            this.MinimumSize = new Size(800, 0);

            this.Resize += (s, e) => RefreshPanels();
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

        private void RefreshPanels()
        {
            foreach (Control control in flowLayoutPanelProducts.Controls)
            {
                if (control is Panel productPanel)
                {
                    productPanel.Width = flowLayoutPanelProducts.ClientSize.Width -
                        (flowLayoutPanelProducts.Padding.Left + flowLayoutPanelProducts.Padding.Right +
                         productPanel.Margin.Left + productPanel.Margin.Right);
                }
            }
        }

        public void AddProductToPanel(string name, decimal price, int unitsInStock, string category)
        {
            Panel productPanel = new Panel
            {
                Height = 50,
                BackColor = Color.White,
                BorderStyle = BorderStyle.None,
                Margin = new Padding(4)
            };

            // ضبط العرض بناءً على عرض الـ FlowLayoutPanel
            productPanel.Width = flowLayoutPanelProducts.ClientSize.Width -
                (flowLayoutPanelProducts.Padding.Left + flowLayoutPanelProducts.Padding.Right +
                 productPanel.Margin.Left + productPanel.Margin.Right);

            Label lblNumber = new Label
            {
                Name = "lblNumber",
                Text = (flowLayoutPanelProducts.Controls.Count + 1).ToString(),
                Location = new Point(10, 19),
                Size = new Size(30, 20),
                Font = new Font("Arial", 10)
            };
            productPanel.Controls.Add(lblNumber);

            Label lblName = new Label
            {
                Name = "lblName",
                Text = name,
                Location = new Point(75, 11),
                Size = new Size((int)(productPanel.Width * 0.15), 20),
                Font = new Font("Arial", 10)
            };
            productPanel.Controls.Add(lblName);

            Label lblPrice = new Label
            {
                Name = "lblPrice",
                Text = price.ToString("C"),
                Location = new Point((int)(productPanel.Width * 0.24), 11),
                Size = new Size((int)(productPanel.Width * 0.15), 20),
                Font = new Font("Arial", 10)
            };
            productPanel.Controls.Add(lblPrice);

            Label lblUnitsInStock = new Label
            {
                Name = "lblUnitsInStock",
                Text = unitsInStock.ToString(),
                Location = new Point((int)(productPanel.Width * 0.48), 11),
                Size = new Size((int)(productPanel.Width * 0.15), 20),
                Font = new Font("Arial", 10)
            };
            productPanel.Controls.Add(lblUnitsInStock);

            Label lblCategory = new Label
            {
                Name = "lblCategory",
                Text = category,
                Location = new Point((int)(productPanel.Width * 0.68), 11),
                Size = new Size((int)(productPanel.Width * 0.15), 20),
                Font = new Font("Arial", 10)
            };
            productPanel.Controls.Add(lblCategory);

            // زرار Edit (باستخدام Guna2Button)
            Guna.UI2.WinForms.Guna2Button btnEdit = new Guna.UI2.WinForms.Guna2Button
            {
                Text = "Edit",
                Location = new Point(productPanel.Width - 240, 10),
                Size = new Size(80, 30),
                FillColor = Color.FromArgb(102, 210, 214),
                ForeColor = Color.White,
                BorderRadius = 5
            };
            btnEdit.Click += (sender, e) =>
            {
                decimal priceValue;
                decimal.TryParse(lblPrice.Text.Replace("$", ""), out priceValue);
                int unitsValue;
                int.TryParse(lblUnitsInStock.Text, out unitsValue);

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
                Location = new Point(productPanel.Width - 140, 10),
                Size = new Size(80, 30),
                FillColor = Color.FromArgb(229, 105, 151),
                ForeColor = Color.White,
                BorderRadius = 5
            };
            btnDelete.Click += (s, e) => DeleteProduct(productPanel, name);
            productPanel.Controls.Add(btnDelete);

            flowLayoutPanelProducts.Controls.Add(productPanel);
        }

        private void DeleteProduct(Panel productPanel, string productName)
        {
            DialogResult result = MessageBox.Show(
                $"Are you sure you want to delete the product '{productName}'?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                // هنا هيحصل الحذف من قاعدة البيانات في المستقبل
                // مثلاً: await _productServices.DeleteProductAsync(productId);
                productPanel.Parent.Controls.Remove(productPanel);
                MessageBox.Show("Product deleted successfully!");
            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            var addForm = ServiceProviderContainer.ServiceProvider.GetRequiredService<AddForm>();

            addForm.ProductAdded += (s, args) =>
            {
                AddProductToPanel(
                    args.Product.Name,
                    args.Product.Price,
                    args.Product.UnitsInStock,
                    args.Product.Category
                );
            };
            addForm.ShowDialog();
            addForm.ProductAdded -= (s, args) => { };
        }
    }
}