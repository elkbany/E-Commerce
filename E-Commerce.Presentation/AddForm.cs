using System;
using System.Windows.Forms;
using System.ComponentModel;
using E_Commerce.BL.Contracts.Services;
using E_Commerce.BL.Features.Product.DTOs;
using E_Commerce.BL.Implementations;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using FluentValidation;
using E_Commerce.Domain.Models;

namespace E_Commerce.Presentation
{
    public partial class AddForm : Form
    {
        public event EventHandler<ProductAddedEventArgs> ProductAdded;
        private FlowLayoutPanel _productPanel;
        private FlowLayoutPanel _categoryPanel;
        private FlowLayoutPanel _userPanel;
        private IProductServices _ProductServices;
        private ICategoryServices _CategoryServices;
        private readonly IValidator<AddProductDTO> _validator;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ProductName { get; private set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public decimal ProductPrice { get; private set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int UnitsInStock { get; private set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Category { get; private set; }

        public AddForm(IProductServices ProductServices, ICategoryServices CategoryServices, IValidator<AddProductDTO> validator, string initialCategory = null)
        {
            InitializeComponent();
            _ProductServices = ProductServices;
            _CategoryServices = CategoryServices;
            _validator = validator;

            this.Load += async (s, e) =>
            {
                await LoadCategoriesAsync();
                if (!string.IsNullOrEmpty(initialCategory))
                {
                    SelectCategoryByName(initialCategory);
                }
            };
        }
        public void SetCategoryPanel(FlowLayoutPanel panel)
        {
            _categoryPanel = panel;
        }
        public void SetProductPanel(FlowLayoutPanel panel)
        {
            _productPanel = panel;
        }
        //public void SetUserPanel(FlowLayoutPanel panel)
        //{
        //    _userPanel = panel;
        //}

        

        private async void btnAddSave_Click(object sender, EventArgs e)
        {
            try
            {
                var product = new AddProductDTO
                {
                    Name = txtAddName.Text,
                    Category = txtAddCategory.SelectedItem.ToString(),
                    Price = decimal.Parse(txtAddPrice.Text),
                    UnitsInStock = int.Parse(txtAddUnitsInStock.Text)
                };

                var validationResult = await _validator.ValidateAsync(product);
                if (!validationResult.IsValid)
                {
                    MessageBox.Show(string.Join("\n", validationResult.Errors.Select(x => x.ErrorMessage)),
                        "Validation Errors", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var addedProduct = await _ProductServices.AddProductAsync(product);

                // Raise the event with the new product
                ProductAdded?.Invoke(this, new ProductAddedEventArgs(addedProduct));

                MessageBox.Show("Product added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnAddCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();  // Correct - closes the current form
        }

        private async Task LoadCategoriesAsync()
        {
            var categories = await _CategoryServices.GetAllCategoryAsync();
            if (txtAddCategory is ComboBox combo)
            {
                combo.Items.Clear();
                foreach (var category in categories)
                {
                    combo.Items.Add(category.Name);
                }
            }
        }

        private void SelectCategoryByName(string categoryName)
        {
            if (txtAddCategory is ComboBox combo)
            {
                int index = combo.Items.IndexOf(categoryName);
                if (index >= 0)
                {
                    combo.SelectedIndex = index;
                }
            }
        }



    }


    // Add this class to your project
    public class ProductAddedEventArgs : EventArgs
    {
        public AddProductDTO Product { get; }

        public ProductAddedEventArgs(AddProductDTO product)
        {
            Product = product;
        }
    }


}