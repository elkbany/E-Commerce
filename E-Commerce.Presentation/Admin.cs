using System;
using System.Windows.Forms;
using E_Commerce.Presentation;
using Microsoft.Extensions.DependencyInjection;

namespace AdminTest
{
    public partial class Admin : Form
    {
        private ProductsPage productsPage;
        private CategoriesPage categoriesPage;
        private UsersPage usersPage;
        private ProfilePage profilePage; 
        private SettingsPage settingsPage;
        private UserControl currentPage;

        public Admin()
        {
            InitializeComponent();

            // ????? ???????
            productsPage = new ProductsPage();
            categoriesPage = new CategoriesPage();
            usersPage = new UsersPage();
            profilePage = new ProfilePage();
            settingsPage = new SettingsPage();

            // ????? ??????? ??? mainContentPanel
            mainContentPanel.Controls.Add(productsPage);
            mainContentPanel.Controls.Add(categoriesPage);
            mainContentPanel.Controls.Add(usersPage);
            mainContentPanel.Controls.Add(profilePage);
            mainContentPanel.Controls.Add(settingsPage);

            // ??? ???? Products ?????????
            ShowPage(productsPage);
        }

        private void ShowPage(UserControl page)
        {
            if (currentPage != null)
            {
                currentPage.Visible = false;
            }
            currentPage = page;
            currentPage.Visible = true;
            currentPage.Dock = DockStyle.Fill;
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

        // ????? ????? ??? Sidebar
        //private void btnProducts_Click(object sender, EventArgs e)
        //{
        //    ShowPage(productsPage);
        //}
        private void btnProducts_Click_1(object sender, EventArgs e)
        {
            ShowPage(productsPage);
        }

        //private void btnCategories_Click(object sender, EventArgs e)
        //{
        //    ShowPage(categoriesPage);
        //}
        private void btnCategories_Click_1(object sender, EventArgs e)
        {
            ShowPage(categoriesPage);
        }

        //private void btnUsers_Click(object sender, EventArgs e)
        //{
        //    ShowPage(usersPage);
        //}
        private void btnUsers_Click_1(object sender, EventArgs e)
        {
            ShowPage(usersPage);
        }

        //private void btnProfile_Click(object sender, EventArgs e)
        //{
        //    ShowPage(profilePage);
        //}
        private void btnProfile_Click_1(object sender, EventArgs e)
        {
            ShowPage(profilePage);
        }

        //private void btnSettings_Click(object sender, EventArgs e)
        //{
        //    ShowPage(settingsPage);
        //}

        private void btnSettings_Click_1(object sender, EventArgs e)
        {
            ShowPage(settingsPage);
        }
        private void addNewItem_Click(object sender, EventArgs e)
        {
            var addForm = ServiceProviderContainer.ServiceProvider.GetRequiredService<AddForm>();

            if (addForm.ShowDialog() == DialogResult.OK)
            {
                string productName = addForm.ProductName;
                decimal productPrice = addForm.ProductPrice;
                int unitsInStock = addForm.UnitsInStock;
                string category = addForm.Category;

                productsPage.AddProductToPanel(productName, productPrice, unitsInStock, category);
            }
        }

        //private void btnAddCategory_Click(object sender, EventArgs e)
        //{
        //    AddForm addForm = new AddForm(categoriesPage.flowLayoutPanelCategories);
        //    if (addForm.ShowDialog() == DialogResult.OK)
        //    {
        //        string categoryName = addForm.ProductName; // ???????? ProductName ???? ?????
        //        decimal categoryPrice = addForm.ProductPrice;
        //        int unitsInStock = addForm.UnitsInStock;
        //        string category = addForm.Category;

        //        categoriesPage.AddCategoryToPanel(categoryName);
        //    }
        //}

        //private void btnAddCategory_Click(object sender, EventArgs e) //this i fix it
        //{
        //    // Get form from DI
        //    var addForm = ServiceProviderContainer.ServiceProvider.GetRequiredService<AddForm>();

        //    // Pass UI dependency
        //    addForm.SetCategoryPanel(categoriesPage.flowLayoutPanelCategories);

        //    if (addForm.ShowDialog() == DialogResult.OK)
        //    {
        //        string categoryName = addForm.ProductName;
        //        categoriesPage.AddCategoryToPanel(categoryName);
        //    }
        //}



        //private void btnAddUser_Click(object sender, EventArgs e)
        //{
        //    AddUser addUser = new AddUser(usersPage.flowLayoutPanelUsers);

        //    if (addUser.ShowDialog() == DialogResult.OK)
        //    {
        //        string userName = addUser.UserName; 
        //        string userEmail = addUser.UserEmail;
        //        string userPassword = addUser.UserPassword;
        //        string userRole = addUser.UserStatus;

        //        usersPage.AddUserToPanel(userName, userEmail, userPassword, userRole);
        //    }
        //}

        
    }

}