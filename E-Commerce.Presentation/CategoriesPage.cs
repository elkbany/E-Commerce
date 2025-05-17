using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using E_Commerce.BL.Contracts.Services;
using E_Commerce.BL.Features.Category.DTOs;
using Microsoft.Extensions.DependencyInjection;

namespace E_Commerce.Presentation
{
    public partial class CategoriesPage : UserControl
    {
        private readonly ICategoryServices _categoryServices;

        public CategoriesPage()
        {
            InitializeComponent();
            if (!DesignMode)
            {
                _categoryServices = ServiceProviderContainer.ServiceProvider.GetRequiredService<ICategoryServices>();
                Console.WriteLine("[CategoriesPage] Constructor called, loading categories...");
                LoadCategoriesAsync();
                btnAddCategory.Click += btnAddCategory_click;
            }
        }

        private async Task LoadCategoriesAsync()
        {
            try
            {
                Console.WriteLine("[CategoriesPage] Loading categories...");
                var categories = await _categoryServices.GetAllCategoryAsync();
                Console.WriteLine($"[CategoriesPage] Retrieved {categories.Count} categories.");

                if (flowLayoutPanelCategories.InvokeRequired)
                {
                    Console.WriteLine("[CategoriesPage] Invoke required for UI update.");
                    flowLayoutPanelCategories.Invoke(new Action(() =>
                    {
                        flowLayoutPanelCategories.Controls.Clear();
                        Console.WriteLine("[CategoriesPage] Cleared flowLayoutPanelCategories controls.");
                        int index = 1;
                        foreach (var category in categories)
                        {
                            AddCategoryToPanel(category, index++);
                        }
                    }));
                }
                else
                {
                    Console.WriteLine("[CategoriesPage] No invoke required for UI update.");
                    flowLayoutPanelCategories.Controls.Clear();
                    Console.WriteLine("[CategoriesPage] Cleared flowLayoutPanelCategories controls.");
                    int index = 1;
                    foreach (var category in categories)
                    {
                        AddCategoryToPanel(category, index++);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[CategoriesPage] Error loading categories: {ex.Message}\nStackTrace: {ex.StackTrace}");
                MessageBox.Show($"Error loading categories: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddCategoryToPanel(CategoryDTO category, int index)
        {
            if (flowLayoutPanelCategories.InvokeRequired)
            {
                flowLayoutPanelCategories.Invoke(new Action(() =>
                {
                    AddCategoryToPanelInternal(category, index);
                }));
                return;
            }
            AddCategoryToPanelInternal(category, index);
        }

        private void AddCategoryToPanelInternal(CategoryDTO category, int index)
        {
            Console.WriteLine($"[CategoriesPage] Adding category to panel: Id={category.Id}, Name={category.Name}, Description={category.Description}");
            foreach (Control control in flowLayoutPanelCategories.Controls)
            {
                if (control is Panel panel && panel.Tag is CategoryDTO tag && tag.Id == category.Id)
                {
                    Console.WriteLine($"[CategoriesPage] Category with Id={category.Id} already exists in panel, updating instead.");
                    foreach (Control child in panel.Controls)
                    {
                        if (child is Label lbl && lbl.Location.X == 90) lbl.Text = category.Name ?? "";
                        if (child is Label desc && desc.Location.X == 190) desc.Text = category.Description ?? "";
                    }
                    panel.Tag = category;
                    return;
                }
            }

            Panel categoryPanel = new Panel
            {
                Size = new Size(1569, 50),
                BackColor = Color.White,
                BorderStyle = BorderStyle.None,
                Margin = new Padding(4),
                Tag = category
            };

            Label lblNumber = new Label { Text = index.ToString(), Location = new Point(27, 15), Size = new Size(30, 20), Font = new Font("Segoe UI", 10) };
            categoryPanel.Controls.Add(lblNumber);

            Label lblCategoryName = new Label { Text = category.Name ?? "", Location = new Point(90, 15), Size = new Size(200, 20), Font = new Font("Segoe UI", 10) };
            categoryPanel.Controls.Add(lblCategoryName);

            Label lblCategoryDescription = new Label
            {
                Text = category.Description ?? string.Empty, // استخدام Description بدل Name
                Location = new Point(190, 15),
                Size = new Size(200, 20),
                Font = new Font("Segoe UI", 10)
            };
            categoryPanel.Controls.Add(lblCategoryDescription);

            Guna.UI2.WinForms.Guna2Button btnDelete = new Guna.UI2.WinForms.Guna2Button
            {
                Text = "Delete",
                Location = new Point(600, 10),
                Size = new Size(80, 30),
                FillColor = Color.FromArgb(229, 105, 151),
                ForeColor = Color.White,
                BorderRadius = 5
            };
            btnDelete.Click += (s, e) => DeleteItem(category);
            categoryPanel.Controls.Add(btnDelete);

            Guna.UI2.WinForms.Guna2Button btnEdit = new Guna.UI2.WinForms.Guna2Button
            {
                Text = "Edit",
                Location = new Point(700, 10),
                Size = new Size(80, 30),
                FillColor = Color.FromArgb(102, 210, 214),
                ForeColor = Color.White,
                BorderRadius = 5
            };
            btnEdit.Click += async (s, e) =>
            {
                Console.WriteLine($"[CategoriesPage] Edit clicked for category: Id={category.Id}, Name={category.Name}");
                await HandleEditClick(category);
            };
            categoryPanel.Controls.Add(btnEdit);

            flowLayoutPanelCategories.Controls.Add(categoryPanel);
        }

        private async void DeleteItem(CategoryDTO category)
        {
            DialogResult result = MessageBox.Show($"Are you sure you want to delete '{category.Name}'?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                try
                {
                    await _categoryServices.DeleteCategoryAsync(category.Id);
                    await LoadCategoriesAsync();
                    MessageBox.Show("Category deleted successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting category: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async Task HandleEditClick(CategoryDTO category)
        {
            using (var addCategoryForm = new AddCategory(flowLayoutPanelCategories))
            {
                addCategoryForm.txtCategoryName.Text = category.Name;
                flowLayoutPanelCategories.Tag = new Action(async () => await LoadCategoriesAsync());

                if (addCategoryForm.ShowDialog() == DialogResult.OK)
                {
                    category.Name = addCategoryForm.txtCategoryName.Text;
                    try
                    {
                        var cat = await _categoryServices.GetCategoryByNameAsync(category.Name);
                        await _categoryServices.UpdateCategoryAsync(cat.Id, category);
                        await LoadCategoriesAsync();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"[CategoriesPage] Error in HandleEditClick: {ex.Message}\nStackTrace: {ex.StackTrace}");
                        MessageBox.Show($"Error editing category: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    Console.WriteLine("[CategoriesPage] Edit category dialog cancelled.");
                }
            }
        }


        private async Task HandleDeleteClick(CategoryDTO category)
        {
            try
            {
                Console.WriteLine($"[CategoriesPage] Handling delete for category: Id={category.Id}, Name={category.Name}");
                if (MessageBox.Show($"Are you sure you want to delete '{category.Name}'?", "Confirm Delete",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Console.WriteLine($"[CategoriesPage] Delete confirmed for category: Id={category.Id}, Name={category.Name}");
                    await _categoryServices.DeleteCategoryAsync(category.Id);
                    Console.WriteLine("[CategoriesPage] Delete successful, reloading categories...");
                    await LoadCategoriesAsync();
                }
                else
                {
                    Console.WriteLine("[CategoriesPage] Delete cancelled by user.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[CategoriesPage] Error in HandleDeleteClick: {ex.Message}\nStackTrace: {ex.StackTrace}");
                MessageBox.Show($"Error deleting category: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
    }

}