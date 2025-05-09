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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        bool settingExpand = false;
        private void settingsTransition_Tick(object sender, EventArgs e)
        {
            if (settingExpand == false)
            {
                settingsContainer.Height += 10;
                if (settingsContainer.Height >= 196)
                {
                    settingsTransition.Stop();
                    settingExpand = true;
                }
            }
            else
            {
                settingsContainer.Height -= 10;
                if (settingsContainer.Height <= 79)
                {
                    settingsTransition.Stop();
                    settingExpand = false;
                }
            }

        }

        private void settings_Click(object sender, EventArgs e)
        {
            settingsTransition.Start();

        }

        bool sideExpand = true;
        private void sidebarTransition_Tick(object sender, EventArgs e)
        {
            if (sideExpand)
            {
                sidebar.Width -= 10;
                if (sidebar.Width <= 61)
                {
                    sideExpand = false;
                    sidebarTransition.Stop();
                }
            }
            else
            {
                sidebar.Width += 10;
                if (sidebar.Width >= 276)
                {
                    sideExpand = true;
                    sidebarTransition.Stop();
                }
            }
        }

        private void btnMenue_Click(object sender, EventArgs e)
        {
            sidebarTransition.Start();
        }

        bool expand = false;
        private void timer1_Tick(object sender, EventArgs e)
        {
            //if(expand == false)
            //{
            //    dropdownContainer.Height += 15;

            //}
        }
    }
}
