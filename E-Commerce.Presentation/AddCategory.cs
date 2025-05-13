using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ReaLTaiizor.Controls;

namespace E_Commerce.Presentation
{
    public partial class AddCategory : Form
    {
        private FlowLayoutPanel targetPanel;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string CategoryName { get; private set; }
        public AddCategory(FlowLayoutPanel panel)
        {
            InitializeComponent();
            targetPanel = panel;
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCategoryName.Text))
            {
                MessageBox.Show("Please enter a category name.");
                return;
            }

            CategoryName = txtCategoryName.Text;

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
