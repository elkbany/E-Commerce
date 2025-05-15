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
    

    public partial class AddUser : Form
    {
        private FlowLayoutPanel targetPanel;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string FirstName { get; private set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string LastName { get; private set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string UserName { get; private set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string UserEmail { get; private set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string UserPassword { get; private set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string UserStatus { get; private set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string IsActive { get; private set; }

        public AddUser(FlowLayoutPanel panel)
        {
            InitializeComponent();
            targetPanel = panel ?? throw new ArgumentNullException(nameof(panel));
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtLastName.Text) ||
                string.IsNullOrWhiteSpace(txtUserName.Text) ||
                string.IsNullOrWhiteSpace(txtUserEmail.Text) ||
                string.IsNullOrWhiteSpace(txtUserPassword.Text) ||
                string.IsNullOrWhiteSpace(txtUserStatus.Text) ||
                (!btnActive1.Checked && !btnActive2.Checked))
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            FirstName = txtFirstName.Text;
            LastName = txtLastName.Text;
            UserName = txtUserName.Text;
            UserEmail = txtUserEmail.Text;
            UserPassword = txtUserPassword.Text;
            UserStatus = txtUserStatus.Text;
            IsActive = btnActive1.Checked ? "Yes" : "No";

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
