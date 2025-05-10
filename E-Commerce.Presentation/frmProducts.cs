using E_Commerce.BL.Contracts.Services;
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
    public partial class frmProducts : Form
    {
        private readonly IProductServices productServices;
        private readonly int userId;


        public frmProducts(IProductServices productServices, int userId)
        {
            InitializeComponent();
            this.productServices = productServices;
            this.userId = userId;
        }

        private void homeForm_Load(object sender, EventArgs e)
        {

        }
    }
}
