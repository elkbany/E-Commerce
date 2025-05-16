using System;
using System.Configuration;
using System.Windows.Forms;
using E_Commerce.BL.Implementations;
using E_Commerce.Presentation;
using Microsoft.Extensions.DependencyInjection;

namespace E_Commerce.Presentation
{
    public partial class Admin : Form
    {
        private ProductsPage productsPage;
        private CategoriesPage categoriesPage;
        private UsersPage usersPage;
        public ProfilePage profilePage;
        //private AdminChangePassword adminChangePassword;
        //private SettingsPage settingsPage;
        private OurTeam ourTeam;
        private UserControl currentPage;

        public Admin()
        {
            InitializeComponent();

            productsPage = new ProductsPage();
            categoriesPage = ServiceProviderContainer.ServiceProvider.GetRequiredService<CategoriesPage>();
            usersPage = new UsersPage();
            profilePage = new ProfilePage();
            //changePasswordPage = new ChangePasswordPage(this);
            ourTeam = new OurTeam();

            mainContentPanel.Controls.Add(productsPage);
            mainContentPanel.Controls.Add(categoriesPage);
            mainContentPanel.Controls.Add(usersPage);
            mainContentPanel.Controls.Add(profilePage);
            //mainContentPanel.Controls.Add(changePasswordPage);
            mainContentPanel.Controls.Add(ourTeam);

            ShowPage(productsPage);
        }

        public void ShowPage(UserControl page)
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
        private void sidebarTransition_Tick_1(object sender, EventArgs e)
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

        private void btnSide_Click_1(object sender, EventArgs e)
        {
            sidebarTransition.Start();
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            ShowPage(productsPage);
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            ShowPage(categoriesPage);
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            ShowPage(usersPage);
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            ShowPage(profilePage);
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            ShowPage(ourTeam);
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

//            if(addForm.ShowDialog() == DialogResult.OK)
//            {
//                string categoryName = addForm.ProductName;
//        decimal categoryPrice = addForm.ProductPrice;
//        int unitsInStock = addForm.UnitsInStock;
//        string category = addForm.Category;

//            if(addForm.ShowDialog() == DialogResult.OK)
//            {
//                string categoryName = addForm.ProductName;
//        categoriesPage.AddCategoryToPanel(categoryName);
//            }
//}
    


//            if (addUser.ShowDialog() == DialogResult.OK)
//            {
//                string firstName = addUser.FirstName;
//                string lastName = addUser.LastName;
//                string userName = addUser.UserName;
//                string userEmail = addUser.UserEmail;
//                string userPassword = addUser.UserPassword;
//                string userRole = addUser.UserStatus;
//                string isActive = addUser.IsActive;

//                usersPage.AddUserToPanel(firstName, lastName, userName, userEmail, userPassword, userRole, isActive);
//            }
//        }
//    }