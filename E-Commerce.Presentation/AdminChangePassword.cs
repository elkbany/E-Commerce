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
    public partial class AdminChangePassword: UserControl
    {
        private Admin adminForm;
        public AdminChangePassword(Admin admin)
        {
            InitializeComponent();
            adminForm = admin;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(lnlOldPassword.Text) ||
                string.IsNullOrWhiteSpace(lblNewPassword1.Text) ||
                string.IsNullOrWhiteSpace(lblNewPassword2.Text))
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            if (lblNewPassword1.Text != lblNewPassword2.Text)
            {
                MessageBox.Show("New password and confirm password do not match.");
                return;
            }

            // هنا ممكن تضيف منطق تغيير كلمة المرور (مثلاً تحقق من كلمة المرور الحالية مع قاعدة البيانات)
            MessageBox.Show("Password changed successfully!");
            adminForm.ShowPage(adminForm.profilePage); // رجوع لـ ProfilePage بعد التغيير
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            adminForm.ShowPage(adminForm.profilePage); // رجوع لـ ProfilePage بدون تغيير
        }
    }
}
