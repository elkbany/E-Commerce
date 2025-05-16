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

            // تهيئة الصفحات باستخدام ServiceProvider
            productsPage = ServiceProviderContainer.ServiceProvider.GetRequiredService<ProductsPage>();//new ProductsPage();
            categoriesPage = ServiceProviderContainer.ServiceProvider.GetRequiredService<CategoriesPage>();
            usersPage = new UsersPage();
            profilePage = new ProfilePage();
            settingsPage = new SettingsPage();

            // إضافة الصفحات لـ mainContentPanel
            mainContentPanel.Controls.Add(productsPage);
            mainContentPanel.Controls.Add(categoriesPage);
            mainContentPanel.Controls.Add(usersPage);
            mainContentPanel.Controls.Add(profilePage);
            mainContentPanel.Controls.Add(settingsPage);

            // عرض صفحة Products افتراضيًا
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

        private void btnProducts_Click_1(object sender, EventArgs e)
        {
            ShowPage(productsPage);
        }

        private void btnCategories_Click_1(object sender, EventArgs e)
        {
            ShowPage(categoriesPage);
        }

        private void btnUsers_Click_1(object sender, EventArgs e)
        {
            ShowPage(usersPage);
        }

        private void btnProfile_Click_1(object sender, EventArgs e)
        {
            ShowPage(profilePage);
        }

        private void btnSettings_Click_1(object sender, EventArgs e)
        {
            ShowPage(settingsPage);
        }

        private void addNewItem_Click(object sender, EventArgs e)
        {
            var addForm = ServiceProviderContainer.ServiceProvider.GetRequiredService<AddForm>();

            // Subscribe to the ProductAdded event
            addForm.ProductAdded += (s, args) =>
            {
                // This will trigger the ProductsPage to refresh
                productsPage.LoadProducts();
            };

            addForm.ShowDialog();
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