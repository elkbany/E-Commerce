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
        public string UserName { get; private set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string UserEmail { get; private set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string UserPassword { get; private set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string UserStatus { get; private set; }
        public AddUser(FlowLayoutPanel panel)
        {
            InitializeComponent();
            targetPanel = panel;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUserName.Text) ||
                string.IsNullOrWhiteSpace(txtUserEmail.Text) ||
                string.IsNullOrWhiteSpace(txtUserPassword.Text) ||
                string.IsNullOrWhiteSpace(txtUserStatus.Text))
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            UserName = txtUserName.Text;
            UserEmail = txtUserEmail.Text;
            UserPassword = txtUserPassword.Text;
            UserStatus = txtUserStatus.Text;

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


//using System; using System.Windows.Forms;

//namespace AdminTest
//{
//    public partial class AddNewUser : Form
//    {
//        private FlowLayoutPanel targetPanel;

//        public string UserName { get; private set; }
//        public string UserEmail { get; private set; }
//        public string UserPassword { get; private set; }
//        public string UserStatus { get; private set; }

//        public AddNewUser(FlowLayoutPanel panel)
//        {
//            InitializeComponent();
//            targetPanel = panel;
//        }

//        private void btnSave_Click(object sender, EventArgs e)
//        {
//            if (string.IsNullOrWhiteSpace(txtUserName.Text) ||
//                string.IsNullOrWhiteSpace(txtUserEmail.Text) ||
//                string.IsNullOrWhiteSpace(txtUserPassword.Text) ||
//                string.IsNullOrWhiteSpace(txtUserStatus.Text))
//            {
//                MessageBox.Show("Please fill all fields.");
//                return;
//            }

//            UserName = txtUserName.Text;
//            UserEmail = txtUserEmail.Text;
//            UserPassword = txtUserPassword.Text;
//            UserStatus = txtUserStatus.Text;

//            this.DialogResult = DialogResult.OK;
//            this.Close();
//        }

//        private void btnCancel_Click(object sender, EventArgs e)
//        {
//            this.DialogResult = DialogResult.Cancel;
//            this.Close();
//        }
//    }

//}