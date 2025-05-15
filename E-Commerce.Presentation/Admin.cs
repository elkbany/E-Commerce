using System;
using System.Configuration;
using System.Windows.Forms;
using E_Commerce.BL.Implementations;
using E_Commerce.Presentation;
using Microsoft.Extensions.DependencyInjection;

namespace AdminTest
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

            // إعداد الصفحات
            productsPage = new ProductsPage();
            categoriesPage = ServiceProviderContainer.ServiceProvider.GetRequiredService<CategoriesPage>();
            usersPage = new UsersPage();
            profilePage = new ProfilePage();
            ourTeam = new OurTeam();

            // إضافة الصفحات إلى mainContentPanel
            mainContentPanel.Controls.Add(productsPage);
            mainContentPanel.Controls.Add(categoriesPage);
            mainContentPanel.Controls.Add(usersPage);
            mainContentPanel.Controls.Add(profilePage);
            mainContentPanel.Controls.Add(ourTeam);

            // إعداد أحداث الأزرار يدويًا
            btnProducts.Click += btnProducts_Click_1;
            btnCategories.Click += btnCategories_Click_1;
            btnUsers.Click += btnUsers_Click_1;
            btnProfile.Click += btnProfile_Click_1;
            btnSettings.Click += btnSettings_Click_1;

            // عرض صفحة Products افتراضيًا
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

        private void btnProducts_Click_1(object sender, EventArgs e)
        {
            Console.WriteLine("btnProducts clicked");
            ShowPage(productsPage);
        }

        private void btnCategories_Click_1(object sender, EventArgs e)
        {
            Console.WriteLine("btnCategories clicked");
            ShowPage(categoriesPage);
        }

        private void btnUsers_Click_1(object sender, EventArgs e)
        {
            Console.WriteLine("btnUsers clicked");
            ShowPage(usersPage);
        }

        private void btnProfile_Click_1(object sender, EventArgs e)
        {
            Console.WriteLine("btnProfile clicked");
            ShowPage(profilePage);
        }

        private void btnSettings_Click_1(object sender, EventArgs e)
        {
            Console.WriteLine("btnSettings clicked");
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