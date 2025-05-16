using System;
using System.Configuration;
using System.Windows.Forms;
using E_Commerce.BL.Contracts.Services;
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
        private OurTeam ourTeam;
        private UserControl currentPage;

        public Admin()
        {
            InitializeComponent();

            productsPage = new ProductsPage(ServiceProviderContainer.ServiceProvider.GetRequiredService<IProductServices>());
            categoriesPage = ServiceProviderContainer.ServiceProvider.GetRequiredService<CategoriesPage>();
            usersPage = new UsersPage();
            profilePage = new ProfilePage();
            ourTeam = new OurTeam();

            mainContentPanel.Controls.Add(productsPage);
            mainContentPanel.Controls.Add(categoriesPage);
            mainContentPanel.Controls.Add(usersPage);
            mainContentPanel.Controls.Add(profilePage);
            mainContentPanel.Controls.Add(ourTeam);

            ShowPage(productsPage);
        }

        public void ShowPage(UserControl page)
        {
            if (currentPage != null)
            {
                currentPage.Visible = false;
                Console.WriteLine($"Hiding page: {currentPage.GetType().Name}");
            }
            currentPage = page;
            currentPage.Visible = true;
            currentPage.Dock = DockStyle.Fill;
            currentPage.Size = mainContentPanel.Size;
            Console.WriteLine($"Showing page: {currentPage.GetType().Name}, Visible: {currentPage.Visible}");

            //New Code Here
            if (page == productsPage)
            {
                productsPage.LoadProducts();
            }
            else if (page == categoriesPage)
            {
                // CategoriesPage بتعمل LoadCategoriesAsync لوحدها في الـ Constructor
            }
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
            Console.WriteLine("btnProducts clicked");
            ShowPage(productsPage);
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            Console.WriteLine("btnCategories clicked");
            ShowPage(categoriesPage);
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            Console.WriteLine("btnUsers clicked");
            ShowPage(usersPage);
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            Console.WriteLine("btnProfile clicked");
            ShowPage(profilePage);
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            Console.WriteLine("btnSettings clicked");
            ShowPage(ourTeam);
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
    

        //    if (addUser.ShowDialog() == DialogResult.OK)
        //    {
        //        string userName = addUser.UserName; 
        //        string userEmail = addUser.UserEmail;
        //        string userPassword = addUser.UserPassword;
        //        string userRole = addUser.UserStatus;

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
//    }}