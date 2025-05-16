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
using E_Commerce.BL.Features.Product.DTOs;
using FluentValidation;

namespace E_Commerce.Presentation
{
    public partial class EditForm : Form
    {
        private IProductServices _ProductServices;
        private readonly IValidator<AddProductDTO> _validator;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)] public string ProductName { get; private set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)] public decimal ProductPrice { get; private set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)] public int UnitsInStock { get; private set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)] public string Category { get; private set; }

        public EditForm(string name, decimal price, int stock, string category , IProductServices ProductServices, IValidator<AddProductDTO> validator)
        {
            InitializeComponent();
            _ProductServices = ProductServices;
            _validator = validator;

            txtName.Text = name;
            txtPrice.Text = price.ToString();
            txtUnitsInStock.Text = stock.ToString();
            txtCategory.Text = category;
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
        //    //var productId =
        //    //var updateProduct = new AddProductDTO
        //    //{
        //    //    Name = txtName.Text,
        //    //    Price = decimal.Parse(txtPrice.Text),
        //    //    Category = txtCategory.Text,
        //    //    UnitsInStock = int.Parse(txtUnitsInStock.Text)
        //    //};

        //    //var validationResult = _validator.Validate(updateProduct);
        //    //if (!validationResult.IsValid)
        //    //{
        //    //    MessageBox.Show(string.Join("\n", validationResult.Errors.Select(x => x.ErrorMessage)),
        //    //        "Validation Errors", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    //    return;
        //    //}

        //    //var addedProduct = _ProductServices.UpdateProductAsync(updateProduct);
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }

}