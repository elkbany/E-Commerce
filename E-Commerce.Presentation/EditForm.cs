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

        // خصائص عامة نستخدمها بعد الحفظ
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]

        // خصائص عامة نستخدمها بعد الحفظ
        public string ProductName { get; private set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public decimal ProductPrice { get; private set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int UnitsInStock { get; private set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Category { get; private set; }

        // Constructor يستقبل القيم القديمة
        // Constructor يستقبل القيم القديمة
        public EditForm(string name, decimal price, int stock, string category)
        {
            InitializeComponent();

            // عرض البيانات القديمة في الـ TextBoxes
            txtName.Text = name;
            txtPrice.Text = price.ToString();
            txtUnitsInStock.Text = stock.ToString();
            txtCategory.Text = category;
        }


        private void btnSave_Click_1(object sender, EventArgs e)
        {
            // قراءة البيانات الجديدة من TextBoxes
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

            // قفل الفورم وإرسال OK
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
    #region Old Code
    //[System.ComponentModel.Browsable(false)]
    //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    //public string EditedName { get; private set; }

    //[System.ComponentModel.Browsable(false)]
    //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    //public decimal EditedPrice { get; private set; }

    //[System.ComponentModel.Browsable(false)]
    //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    //public int EditedUnitsInStock { get; private set; }

    //[System.ComponentModel.Browsable(false)]
    //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    //public string EditedCategory { get; private set; }


    //public EditForm(string name, decimal price, int unitsInStock, string category)
    //{
    //    InitializeComponent();

    //    txtName.Text = name;
    //    txtPrice.Text = price.ToString();
    //    txtUnitsInStock.Text = unitsInStock.ToString();
    //    txtCategory.Text = category;
    //}

    //private void btnSave_Click(object sender, EventArgs e)
    //{
    //    EditedName = txtName.Text;
    //    EditedPrice = decimal.Parse(txtPrice.Text);
    //    EditedUnitsInStock = int.Parse(txtUnitsInStock.Text);
    //    EditedCategory = txtCategory.Text;

    //    this.DialogResult = DialogResult.OK;
    //    this.Close();
    //}

    //private void btnCancel_Click(object sender, EventArgs e)
    //{
    //    this.DialogResult = DialogResult.Cancel;
    //    this.Close();
    //}
    #endregion


}
