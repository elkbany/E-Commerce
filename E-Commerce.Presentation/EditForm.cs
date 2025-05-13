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

namespace E_Commerce.Presentation
{
    public partial class EditForm : Form
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)] public string ProductName { get; private set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)] public decimal ProductPrice { get; private set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)] public int UnitsInStock { get; private set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)] public string Category { get; private set; }

        public EditForm(string name, decimal price, int stock, string category)
        {
            InitializeComponent();

            txtName.Text = name;
            txtPrice.Text = price.ToString();
            txtUnitsInStock.Text = stock.ToString();
            txtCategory.Text = category;
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            ProductName = txtName.Text;

            decimal price;
            if (!decimal.TryParse(txtPrice.Text, out price))
            {
                MessageBox.Show("Please enter a valid price.");
                return;
            }
            ProductPrice = price;

            int units;
            if (!int.TryParse(txtUnitsInStock.Text, out units))
            {
                MessageBox.Show("Please enter a valid number for units in stock.");
                return;
            }
            UnitsInStock = units;

            Category = txtCategory.Text;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }

}