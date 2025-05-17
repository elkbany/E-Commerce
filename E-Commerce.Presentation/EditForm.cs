using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using E_Commerce.BL.Contracts.Services;
using E_Commerce.BL.Features.Category.DTOs;
using E_Commerce.BL.Features.Product.DTOs;
using E_Commerce.BL.Implementations;
using E_Commerce.Domain.Models;
using FluentValidation;

namespace E_Commerce.Presentation
{
    public partial class EditForm : Form
    {
        private IProductServices _ProductServices;
        private ICategoryServices _categoryServices;
        private readonly IValidator<AddProductDTO> _validator;
        private readonly string _oldProductName;


        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)] public string ProductName { get; private set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)] public decimal ProductPrice { get; private set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)] public int UnitsInStock { get; private set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)] public string Category { get; private set; }

        public EditForm(string name, decimal price, int stock, string category, IProductServices ProductServices, IValidator<AddProductDTO> validator, ICategoryServices categoryServices)
        {
            InitializeComponent();
            _ProductServices = ProductServices;
            _categoryServices = categoryServices;
            _validator = validator;

            _oldProductName = name;
            txtName.Text = name;
            txtPrice.Text = price.ToString();
            txtUnitsInStock.Text = stock.ToString();
            LoadCategoriesAsync().Wait(); // Wait for categories to load
            SelectCategoryByName(category); // Set initial selection
        }

        private async void btnSave_Click_1(object sender, EventArgs e)
        {
            var selectedCategory = txtCategory.SelectedItem as string;
            var product =await _ProductServices.GetProductByName(_oldProductName);
            var productId = product.Id;

            var updateProduct = new AddProductDTO
            {
                Name = txtName.Text,
                Price = decimal.Parse(txtPrice.Text),
                Category = selectedCategory,
                UnitsInStock = int.Parse(txtUnitsInStock.Text)
            };

            var validationResult = _validator.Validate(updateProduct);
            if (!validationResult.IsValid)
            {
                MessageBox.Show(string.Join("\n", validationResult.Errors.Select(x => x.ErrorMessage)),
                    "Validation Errors", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var addedProduct =  await _ProductServices.UpdateProductByAdminAsync(productId, updateProduct);
           // MessageBox.Show("Product added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private async Task LoadCategoriesAsync()
        {
            var categories = await _categoryServices.GetAllCategoryAsync();
            txtCategory.Items.Clear();
            foreach (var category in categories)
            {
                txtCategory.Items.Add(category.Name);
            }
        }

        private void SelectCategoryByName(string categoryName)
        {
            for (int i = 0; i < txtCategory.Items.Count; i++)
            {
                if (txtCategory.Items[i].ToString() == categoryName)
                {
                    txtCategory.SelectedIndex = i;
                    break;
                }
            }
        }
    }

}