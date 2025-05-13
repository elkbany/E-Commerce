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
    public partial class SettingsPage: UserControl
    {
        public SettingsPage()
        {
            InitializeComponent();
            Label lbl = new Label();
            lbl.Text = "Settings Page";
            lbl.Location = new Point(10, 10);
            lbl.Size = new Size(200, 20);
            this.Controls.Add(lbl);
        }


    }
}
