using E_Commerce.BL.Contracts.Services;
using E_Commerce.BL.Features.Category.DTOs;
using E_Commerce.BL.Features.Product.DTOs;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace E_Commerce.Presentation
{
    public partial class frmProducts : Form
    {
        private readonly IProductServices productServices;
        private readonly ICartItemServices cartServices;
        private readonly ICategoryServices categoryServices;
        private readonly int userId;
        private List<CategoryDTO> categories;

        public frmProducts(IProductServices productServices, ICartItemServices cartServices, ICategoryServices categoryServices, int userId)
        {
            InitializeComponent();
            this.productServices = productServices;
            this.cartServices = cartServices;
            this.categoryServices = categoryServices;
            this.userId = userId;
            LoadCategories();
            LoadProducts();
        }

        private async void LoadCategories()
        {
            try
            {
                categories = (await categoryServices.GetAllCategoryAsync()).ToList();
                comboBoxCategory.Items.Add(new CategoryDTO { Name = "All" });
                foreach (var category in categories)
                {
                    comboBoxCategory.Items.Add(category);
                }
                comboBoxCategory.DisplayMember = "Name";
                comboBoxCategory.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading categories: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static readonly SemaphoreSlim _lock = new SemaphoreSlim(1, 1);

        private async void LoadProducts()
        {
            try
            {
                await _lock.WaitAsync();
                var products = await productServices.GetAllProductsAsync();
                if (products == null || !products.Any())
                {
                    lblNoProducts.Visible = true;
                    flowLayoutPanelProducts.Controls.Clear();
                    return;
                }

                var selectedCategory = comboBoxCategory.SelectedItem as CategoryDTO;
                string searchTerm = txtSearch.Text.Trim();

                IEnumerable<ProductDTO> filteredProducts = products;
                if (!string.IsNullOrEmpty(searchTerm))
                {
                    filteredProducts = filteredProducts.Where(p =>
                        (p.Name?.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ?? false) ||
                        (p.Description?.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ?? false));
                }
                if (selectedCategory?.Name != "All")
                {
                    filteredProducts = filteredProducts.Where(p => p.Category == selectedCategory.Name); // هنا التحقق
                }

                flowLayoutPanelProducts.Controls.Clear();

                if (filteredProducts.Any())
                {
                    lblNoProducts.Visible = false;
                    foreach (var product in filteredProducts)
                    {
                        var productCard = new ProductCard(cartServices, userId);
                        productCard.SetProductData(product.Id, product.Name, product.Price, product.Category);
                        flowLayoutPanelProducts.Controls.Add(productCard);
                    }
                }
                else
                {
                    lblNoProducts.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading products: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _lock.Release();
            }
        }
        private void comboBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadProducts();
        }
    }
}