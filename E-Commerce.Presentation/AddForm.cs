using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E_Commerce.Presentation
{
    public partial class AddForm : Form
    {

        public AddForm()
        {
            InitializeComponent();
        }

        [System.ComponentModel.Browsable(false)]
        public string ProductName { get; private set; }

        [System.ComponentModel.Browsable(false)]
        public decimal ProductPrice { get; private set; }

        [System.ComponentModel.Browsable(false)]
        public int UnitsInStock { get; private set; }

        [System.ComponentModel.Browsable(false)]
        public string ProductCategory { get; private set; }
        //public string Category { get; internal set; }

        private void btnAddSave_Click(object sender, EventArgs e)
        {
            ProductName = txtAddName.Text;
            decimal.TryParse(txtAddPrice.Text, out decimal price);
            int.TryParse(txtAddUnitsInStock.Text, out int units);

            ProductPrice = price;
            UnitsInStock = units;
            ProductCategory = txtAddCategory.Text;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnAddCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
