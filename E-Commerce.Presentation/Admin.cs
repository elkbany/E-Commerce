using System.Windows.Forms;
using E_Commerce.Presentation;

namespace AdminTest
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        bool sidebarExpand = true;
        private void sidebarTransition_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                sidebar.Width -= 10;
                if (sidebar.Width <= 60)
                {
                    sidebarExpand = false;
                    sidebarTransition.Stop();
                }
            }
            else
            {
                sidebar.Width += 10;
                if (sidebar.Width >= 287)
                {
                    sidebarExpand = true;
                    sidebarTransition.Stop();
                }
            }
        }

        private void btnSide_Click(object sender, EventArgs e)
        {
            sidebarTransition.Start();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            Control button = (Control)sender;
            Panel parentPanel = (Panel)button.Parent;

            flowPanel1.Controls.Remove(parentPanel);
            parentPanel.Dispose();

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // ????? ????? ??????? ?? ???????
            string name = lblName.Text;
            decimal price = 0;
            int unitsInStock = 0;
            string category = lblCategory.Text;
            decimal.TryParse(lblPrice.Text, out price);
            int.TryParse(lblUnitsInStock.Text, out unitsInStock);

            // ????? ???? ??????? ?????? ????? ???????
            EditForm editForm = new EditForm(name, price, unitsInStock, category);

            if (editForm.ShowDialog() == DialogResult.OK)
            {
                // ????? ???????? ????? ??? ?????????
                lblName.Text = editForm.EditedName;
                lblPrice.Text = editForm.EditedPrice.ToString();
                lblUnitsInStock.Text = editForm.EditedUnitsInStock.ToString();
                lblCategory.Text = editForm.EditedCategory;
            }
        }

        private Panel CreateProductPanel(string name, decimal price, int stock, string category)
        {
            Panel newPanel = new Panel();
            newPanel.Size = panelTemplate.Size;
            newPanel.BackColor = panelTemplate.BackColor;
            newPanel.BorderStyle = panelTemplate.BorderStyle;

            foreach (Control ctrl in panelTemplate.Controls)
            {
                Control newCtrl = (Control)Activator.CreateInstance(ctrl.GetType());
                newCtrl.Size = ctrl.Size;
                newCtrl.Location = ctrl.Location;
                newCtrl.Font = ctrl.Font;
                newCtrl.BackColor = ctrl.BackColor;
                newCtrl.ForeColor = ctrl.ForeColor;

                if (ctrl is Label label)
                {
                    if (label.Name == "lblName") newCtrl.Text = name;
                    else if (label.Name == "lblPrice") newCtrl.Text = price.ToString();
                    else if (label.Name == "lblUnitsInStock") newCtrl.Text = stock.ToString();
                    else if (label.Name == "lblCategory") newCtrl.Text = category;
                    label.AutoSize = true;
                }

                if (ctrl is Button btn)
                {
                    newCtrl.Text = btn.Text;

                    if (btn.Name == "btnDelete")
                        newCtrl.Click += (s, e) => flowPanel1.Controls.Remove(newPanel);

                    if (ctrl is Button btnSrc)
                    {
                        Button btnNew = new Button();
                        btnNew.Size = btnSrc.Size;
                        btnNew.Location = btnSrc.Location;
                        btnNew.Name = btnSrc.Name;
                        btnNew.BackColor = btnSrc.BackColor;
                        btnNew.FlatStyle = btnSrc.FlatStyle;
                        btnNew.Image = btnSrc.Image;
                        btnNew.ImageAlign = btnSrc.ImageAlign;
                        btnNew.Text = btnSrc.Text;
                        btnNew.Font = btnSrc.Font;

                        // ??? ???????
                        if (btnNew.Name == "btnEdit")
                            btnNew.Click += btnEdit_Click;

                        if (btnNew.Name == "btnDelete")
                            btnNew.Click += DeleteButton_Click;

                        newPanel.Controls.Add(btnNew);
                        continue;
                    }

                }

                newPanel.Controls.Add(newCtrl);
            }

            return newPanel;
        }

        private void addNewItem_Click(object sender, EventArgs e)
        {
            AddForm addForm = new AddForm();

            if (addForm.ShowDialog() == DialogResult.OK)
            {
                string name = addForm.ProductName;
                decimal price = addForm.ProductPrice;
                int stock = addForm.UnitsInStock;
                string category = addForm.ProductCategory;

                Panel productPanel = CreateProductPanel(name, price, stock, category);
                flowPanel1.Controls.Add(productPanel);
            }
        }
    }
}

