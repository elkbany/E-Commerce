using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E_Commerce.Presentation
{
    public partial class ProfilePage : UserControl
    {
        private Admin adminForm;
        
        public ProfilePage()
        {
            InitializeComponent();
            Label lbl = new Label();
            lbl.Text = "Profile Page";
            lbl.Location = new Point(10, 10);
            lbl.Size = new Size(200, 20);
            this.Controls.Add(lbl);
        }

        //private void button3_Click(object sender, EventArgs e)
        //{
        //    AdminChangePassword changePasswordPage = new AdminChangePassword(adminForm);
        //    adminForm.ShowPage(changePasswordPage);
        //}
    }
}

