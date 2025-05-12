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

        public void AddProductToPanel(string name, decimal price, int unitsInStock, string category)
        {
            Panel productPanel = new Panel();
            productPanel.Size = new Size(1586, 50);
            productPanel.BackColor = Color.White;
            productPanel.BorderStyle = BorderStyle.None;
            productPanel.Margin = new Padding(4);

            Label lblNumber = new Label();
            lblNumber.Text = "1";
            lblNumber.Location = new Point(17, 19);
            lblNumber.Size = new Size(30, 20);
            lblNumber.Font = new Font("Arial", 10);
            productPanel.Controls.Add(lblNumber);

            Label lblName = new Label();
            lblName.Text = name;
            lblName.Location = new Point(91, 11);
            lblName.Size = new Size(100, 20);
            lblName.Font = new Font("Arial", 10);
            productPanel.Controls.Add(lblName);

            Label lblPrice = new Label();
            lblPrice.Text = price.ToString("C");
            lblPrice.Location = new Point(404, 11);
            lblPrice.Size = new Size(100, 20);
            lblPrice.Font = new Font("Arial", 10);
            productPanel.Controls.Add(lblPrice);

            Label lblUnitsInStock = new Label();
            lblUnitsInStock.Text = unitsInStock.ToString();
            lblUnitsInStock.Location = new Point(774, 11);
            lblUnitsInStock.Size = new Size(100, 20);
            lblUnitsInStock.Font = new Font("Arial", 10);
            productPanel.Controls.Add(lblUnitsInStock);

            Label lblCategory = new Label();
            lblCategory.Text = category;
            lblCategory.Location = new Point(1124, 11);
            lblCategory.Size = new Size(100, 20);
            lblCategory.Font = new Font("Arial", 10);
            productPanel.Controls.Add(lblCategory);

            Button btnEdit = new Button();
            btnEdit.Text = "";
            btnEdit.Size = new Size(25, 25);
            btnEdit.Location = new Point(1482, 7);
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.BackColor = Color.Transparent;
            btnEdit.FlatAppearance.BorderColor = Color.Cyan;
            btnEdit.FlatAppearance.BorderSize = 1;
            btnEdit.BackgroundImage = Image.FromFile(@"C:\Users\user\Downloads\edit_24dp_05E0E9_FILL0_wght400_GRAD0_opsz24.png");
            btnEdit.BackgroundImageLayout = ImageLayout.Zoom;
            btnEdit.Click += (sender, e) => {
                decimal priceValue;
                decimal.TryParse(lblPrice.Text.Replace("$", ""), out priceValue);
                int unitsValue;
                int.TryParse(lblUnitsInStock.Text, out unitsValue);

                EditForm editForm = new EditForm(lblName.Text, priceValue, unitsValue, lblCategory.Text);
                DialogResult result = editForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    // ????? ???????? ?? ??????? ????? EditForm
                    lblName.Text = editForm.ProductName;
                    lblPrice.Text = editForm.ProductPrice.ToString("C");
                    lblUnitsInStock.Text = editForm.UnitsInStock.ToString();
                    lblCategory.Text = editForm.Category;
                    MessageBox.Show("Product updated successfully!"); // ???
                }
                else if (result == DialogResult.Cancel)
                {
                    MessageBox.Show("Edit canceled."); // ???
                }
                else
                {
                    MessageBox.Show("Unexpected dialog result: " + result.ToString()); // ??? ??? ??? ??? ???
                }
            };
            productPanel.Controls.Add(btnEdit);

            Button btnDelete = new Button();
            btnDelete.Text = "";
            btnDelete.Size = new Size(25, 25);
            btnDelete.Location = new Point(1537, 7);
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.BackColor = Color.Transparent;
            btnDelete.FlatAppearance.BorderColor = Color.IndianRed;
            btnDelete.FlatAppearance.BorderSize = 2;
            btnDelete.BackgroundImage = Image.FromFile(@"C:\Users\user\Downloads\delete_24dp_FF2768_FILL0_wght400_GRAD0_opsz24.png");
            btnDelete.BackgroundImageLayout = ImageLayout.Zoom;
            btnDelete.Click += (sender, e) => { productPanel.Parent.Controls.Remove(productPanel); };
            productPanel.Controls.Add(btnDelete);

            // ????? ??? Panel ??? ??? FlowLayoutPanel
            flowLayoutPanelProducts.Controls.Add(productPanel);
        }

        private void addNewItem_Click(object sender, EventArgs e)
        {
            AddForm addForm = new AddForm(flowLayoutPanelProducts);

            // ?? ???? ????? ??? ???? ??? ?? AddForm
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                // ?????? ??? ???????? ?? AddForm
                string productName = addForm.ProductName;
                decimal productPrice = addForm.ProductPrice;
                int unitsInStock = addForm.UnitsInStock;
                string category = addForm.Category;

                // ????? ?????? ??? ??? FlowLayoutPanel
                AddProductToPanel(productName, productPrice, unitsInStock, category);
            }
        }
    }

    #region Old Code

    //bool sidebarExpand = true;
    //private void sidebarTransition_Tick(object sender, EventArgs e)
    //{
    //    if (sidebarExpand)
    //    {
    //        sidebar.Width -= 10;
    //        if (sidebar.Width <= 60)
    //        {
    //            sidebarExpand = false;
    //            sidebarTransition.Stop();
    //        }
    //    }
    //    else
    //    {
    //        sidebar.Width += 10;
    //        if (sidebar.Width >= 287)
    //        {
    //            sidebarExpand = true;
    //            sidebarTransition.Stop();
    //        }
    //    }
    //}

    //private void btnSide_Click(object sender, EventArgs e)
    //{
    //    sidebarTransition.Start();
    //}

    //private void DeleteButton_Click(object sender, EventArgs e)
    //{
    //    Control button = (Control)sender;
    //    Panel parentPanel = (Panel)button.Parent;

    //    flowPanel1.Controls.Remove(parentPanel);
    //    parentPanel.Dispose();

    //}

    //private void btnEdit_Click(object sender, EventArgs e)
    //{
    //    // ????? ????? ??????? ?? ???????
    //    string name = lblName.Text;
    //    decimal price = 0;
    //    int unitsInStock = 0;
    //    string category = lblCategory.Text;
    //    decimal.TryParse(lblPrice.Text, out price);
    //    int.TryParse(lblUnitsInStock.Text, out unitsInStock);

    //    // ????? ???? ??????? ?????? ????? ???????
    //    EditForm editForm = new EditForm(name, price, unitsInStock, category);

    //    if (editForm.ShowDialog() == DialogResult.OK)
    //    {
    //        // ????? ???????? ????? ??? ?????????
    //        lblName.Text = editForm.EditedName;
    //        lblPrice.Text = editForm.EditedPrice.ToString();
    //        lblUnitsInStock.Text = editForm.EditedUnitsInStock.ToString();
    //        lblCategory.Text = editForm.EditedCategory;
    //    }
    //}

    //private Panel CreateProductPanel(string name, decimal price, int stock, string category)
    //{
    //    Panel newPanel = new Panel();
    //    newPanel.Size = panelTemplate.Size;
    //    newPanel.BackColor = panelTemplate.BackColor;
    //    newPanel.BorderStyle = panelTemplate.BorderStyle;

    //    foreach (Control ctrl in panelTemplate.Controls)
    //    {
    //        Control newCtrl = (Control)Activator.CreateInstance(ctrl.GetType());
    //        newCtrl.Size = ctrl.Size;
    //        newCtrl.Location = ctrl.Location;
    //        newCtrl.Font = ctrl.Font;
    //        newCtrl.BackColor = ctrl.BackColor;
    //        newCtrl.ForeColor = ctrl.ForeColor;

    //        if (ctrl is Label label)
    //        {
    //            if (label.Name == "lblName") newCtrl.Text = name;
    //            else if (label.Name == "lblPrice") newCtrl.Text = price.ToString();
    //            else if (label.Name == "lblUnitsInStock") newCtrl.Text = stock.ToString();
    //            else if (label.Name == "lblCategory") newCtrl.Text = category;
    //            label.AutoSize = true;
    //        }

    //        if (ctrl is Button btn)
    //        {
    //            newCtrl.Text = btn.Text;

    //            if (btn.Name == "DeleteButton")
    //                newCtrl.Click += (s, e) => flowPanel1.Controls.Remove(newPanel);

    //            if (ctrl is Button btnSrc)
    //            {
    //                Button btnNew = new Button();
    //                btnNew.Size = btnSrc.Size;
    //                btnNew.Location = btnSrc.Location;
    //                btnNew.Name = btnSrc.Name;
    //                btnNew.BackColor = btnSrc.BackColor;
    //                btnNew.FlatStyle = btnSrc.FlatStyle;
    //                btnNew.Image = btnSrc.Image;
    //                btnNew.ImageAlign = btnSrc.ImageAlign;
    //                btnNew.Text = btnSrc.Text;
    //                btnNew.Font = btnSrc.Font;

    //                // ??? ???????
    //                if (btnNew.Name == "btnEdit")
    //                    btnNew.Click += btnEdit_Click;

    //                if (btnNew.Name == "btnDelete")
    //                    btnNew.Click += DeleteButton_Click;

    //                newPanel.Controls.Add(btnNew);
    //                continue;
    //            }

    //        }

    //        newPanel.Controls.Add(newCtrl);
    //    }

    //    return newPanel;
    //}

    //private void addNewItem_Click(object sender, EventArgs e)
    //{
    //    AddForm addForm = new AddForm();

    //    if (addForm.ShowDialog() == DialogResult.OK)
    //    {
    //        string name = addForm.ProductName;
    //        decimal price = addForm.ProductPrice;
    //        int stock = addForm.UnitsInStock;
    //        string category = addForm.ProductCategory;

    //        Panel productPanel = CreateProductPanel(name, price, stock, category);
    //        flowPanel1.Controls.Add(productPanel);
    //    }
    //} 
    #endregion

}

