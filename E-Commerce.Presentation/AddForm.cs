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
        private FlowLayoutPanel _flowLayoutPanel;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ProductName { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public decimal ProductPrice { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int UnitsInStock { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Category { get; set; }
        public AddForm(FlowLayoutPanel flowLayoutPanel)
        {
            InitializeComponent();
            _flowLayoutPanel = flowLayoutPanel;
        }
        #region Old Code

        //[System.ComponentModel.Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //public string ProductName { get; private set; }

        //[System.ComponentModel.Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //public decimal ProductPrice { get; private set; }

        //[System.ComponentModel.Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //public int UnitsInStock { get; private set; }

        //[System.ComponentModel.Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //public string ProductCategory { get; private set; }
        ////public string Category { get; internal set; }

        //private void btnAddSave_Click(object sender, EventArgs e)
        //{
        //    ProductName = txtAddName.Text;
        //    decimal.TryParse(txtAddPrice.Text, out decimal price);
        //    int.TryParse(txtAddUnitsInStock.Text, out int units);

        //    ProductPrice = price;
        //    UnitsInStock = units;
        //    ProductCategory = txtAddCategory.Text;

        //    this.DialogResult = DialogResult.OK;
        //    this.Close();
        //}

        //private void btnAddCancel_Click(object sender, EventArgs e)
        //{
        //    this.DialogResult = DialogResult.Cancel;
        //    this.Close();
        //} 
        #endregion


       

        private void btnAddSave_Click(object sender, EventArgs e)
        {
            ProductName = txtAddName.Text;
            ProductPrice = decimal.Parse(txtAddPrice.Text);
            UnitsInStock = int.Parse(txtAddUnitsInStock.Text);
            Category = txtAddCategory.Text;

            // غلق الفورم بعد الحفظ
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
