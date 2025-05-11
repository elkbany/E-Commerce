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
        [System.ComponentModel.Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string EditedName { get; private set; }

        [System.ComponentModel.Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public decimal EditedPrice { get; private set; }

        [System.ComponentModel.Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int EditedUnitsInStock { get; private set; }

        [System.ComponentModel.Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string EditedCategory { get; private set; }


        public EditForm(string name, decimal price, int unitsInStock, string category)
        {
            InitializeComponent();

            txtName.Text = name;
            txtPrice.Text = price.ToString();
            txtUnitsInStock.Text = unitsInStock.ToString();
            txtCategory.Text = category;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            EditedName = txtName.Text;
            EditedPrice = decimal.Parse(txtPrice.Text);
            EditedUnitsInStock = int.Parse(txtUnitsInStock.Text);
            EditedCategory = txtCategory.Text;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
