using System;
using System.Windows.Forms;
using System.ComponentModel;
using E_Commerce.BL.Contracts.Services;
using E_Commerce.BL.Features.Product.DTOs;
using E_Commerce.BL.Implementations;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using FluentValidation;

namespace E_Commerce.Presentation
{
    public partial class AddForm : Form
    {
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

        public AddForm( IProductServices ProductServices, ICategoryServices CategoryServices, IValidator<AddProductDTO> validator)
        {
            InitializeComponent();
            _ProductServices = ProductServices;
            _CategoryServices = CategoryServices;
            _validator = validator;
        }
        public void SetCategoryPanel(FlowLayoutPanel panel)
        {
            _categoryPanel = panel;
        }
        public void SetProductPanel(FlowLayoutPanel panel)
        {
            _productPanel = panel;
        }
        public void SetUserPanel(FlowLayoutPanel panel)
        {
            _userPanel = panel;
        }

        //private void btnSave_Click(object sender, EventArgs e)
        //{
        //    if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtPrice.Text) ||
        //        string.IsNullOrWhiteSpace(txtUnitsInStock.Text) || string.IsNullOrWhiteSpace(txtCategory.Text))
        //    {
        //        MessageBox.Show("Please fill all fields.");
        //        return;
        //    }

        //    ProductName = txtName.Text;

        //    if (!decimal.TryParse(txtPrice.Text, out decimal price))
        //    {
        //        MessageBox.Show("Please enter a valid price.");
        //        return;
        //    }
        //    ProductPrice = price;

        //    if (!int.TryParse(txtUnitsInStock.Text, out int units))
        //    {
        //        MessageBox.Show("Please enter a valid number for units in stock.");
        //        return;
        //    }
        //    UnitsInStock = units;

        //    Category = txtCategory.Text;

        //    this.DialogResult = DialogResult.OK;
        //    this.Close();
        //}

        //private void btnCancel_Click(object sender, EventArgs e)
        //{
        //    this.DialogResult = DialogResult.Cancel;
        //    this.Close();
        //}

        private async void btnAddSave_Click(object sender, EventArgs e)
        {
           // var category =await _CategoryServices.getCategoryIDByName(txtAddCategory.Text);
            var product = new AddProductDTO
            {

                Name = txtAddName.Text,
                Category = txtAddCategory.Text,
                Price = decimal.Parse(txtAddPrice.Text),
                UnitsInStock = int.Parse(txtAddUnitsInStock.Text)

            };
            // var validator = await validator.ValidateAsync(product);
            var validationResult = await _validator.ValidateAsync(product);
            if (!validationResult.IsValid)
            {
                MessageBox.Show(string.Join("\n", validationResult.Errors.Select(x => x.ErrorMessage)),
                              "Validation Errors",
                MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
                return;
            }
           var show= await _ProductServices.AddProductAsync(product);
           
            MessageBox.Show("Product added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // Assuming you have a method to add the product to the panel
            if (_productPanel != null && show != null)
            {
                // Assuming you have access to the panel
                ////////AddProductToPanel(
                ////////    show.Name,
                ////////    show.Price,
                ////////    show.UnitsInStock,
                ////////    show.Category
                ////////);
            }

            this.Close();
            
            //if (string.IsNullOrWhiteSpace(txtAddName.Text) || string.IsNullOrWhiteSpace(txtAddPrice.Text) ||
            //    string.IsNullOrWhiteSpace(txtAddUnitsInStock.Text) || string.IsNullOrWhiteSpace(txtAddCategory.Text))
            //{
            //    MessageBox.Show("Please fill all fields.");
            //    return;
            //}

            //ProductName = txtAddName.Text;

            //if (!decimal.TryParse(txtAddPrice.Text, out decimal price))
            //{
            //    MessageBox.Show("Please enter a valid price.");
            //    return;
            //}
            //ProductPrice = price;

            //if (!int.TryParse(txtAddUnitsInStock.Text, out int units))
            //{
            //    MessageBox.Show("Please enter a valid number for units in stock.");
            //    return;
            //}
            //UnitsInStock = units;

            //Category = txtAddCategory.Text;

            //this.DialogResult = DialogResult.OK;
            //this.Close();
        }

        private void btnAddCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }

}