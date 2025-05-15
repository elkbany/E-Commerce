using System;
using System.Collections.Generic;
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
                LoadCategoriesAsync();
                btnAddCategory.Click += btnAddCategory_Click;
            }
        }

        private async Task LoadCategoriesAsync()
        {
            try
            {
                var categories = await _categoryServices.GetAllCategoryAsync();
                flowLayoutPanelCategories.Controls.Clear();
                int index = 1;
                foreach (var category in categories)
                {
                    AddCategoryToPanel(category, index++);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading categories: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddCategoryToPanel(CategoryDTO category, int index)
        {
            Panel categoryPanel = new Panel
            {
                Size = new Size(1569, 50),
                BackColor = Color.White,
                BorderStyle = BorderStyle.None,
                Margin = new Padding(4),
                Tag = category
            };

            Label lblNumber = new Label
            {
                Text = index.ToString(),
                Location = new Point(27, 15),
                Size = new Size(30, 20),
                Font = new Font("Segoe UI", 10)
            };
            categoryPanel.Controls.Add(lblNumber);

            Label lblCategoryName = new Label
            {
                Text = category.Name,
                Location = new Point(90, 15),
                Size = new Size(200, 20),
                Font = new Font("Segoe UI", 10)
            };
            categoryPanel.Controls.Add(lblCategoryName);

            // زر Delete
            Guna.UI2.WinForms.Guna2Button btnDelete = new Guna.UI2.WinForms.Guna2Button
            {
                Text = "Delete",
                Location = new Point(600, 10),
                Size = new Size(80, 30),
                FillColor = Color.FromArgb(229, 105, 151),
                ForeColor = Color.White,
                BorderRadius = 5
            };
            btnDelete.Click += (s, e) => btnDelete_Click(category);
            categoryPanel.Controls.Add(btnDelete);

            // زر Edit
            Guna.UI2.WinForms.Guna2Button btnEdit = new Guna.UI2.WinForms.Guna2Button
            {
                Text = "Edit",
                Location = new Point(700, 10),
                Size = new Size(80, 30),
                FillColor = Color.FromArgb(102, 210, 214),
                ForeColor = Color.White,
                BorderRadius = 5
            };
            btnEdit.Click += (s, e) => btnEdit_Click(category);
            categoryPanel.Controls.Add(btnEdit);

            flowLayoutPanelCategories.Controls.Add(categoryPanel);
        }

        private async void btnDelete_Click(CategoryDTO category)
        {
            if (MessageBox.Show($"Are you sure you want to delete '{category.Name}'?", "Confirm Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    var cat = await _categoryServices.GetCategoryByNameAsync(category.Name);
                    await _categoryServices.DeleteCategoryAsync(cat.Id);
                    await LoadCategoriesAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting category: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnEdit_Click(CategoryDTO category)
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
                        var cat=await _categoryServices.GetCategoryByNameAsync(category.Name);
                        await _categoryServices.UpdateCategoryAsync(cat.Id, category);
                        await LoadCategoriesAsync();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error updating category: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            using (var addCategoryForm = new AddCategory(flowLayoutPanelCategories))
            {
                flowLayoutPanelCategories.Tag = new Action(async () => await LoadCategoriesAsync());
                if (addCategoryForm.ShowDialog() == DialogResult.OK)
                {
                }
            }
        }
    }
}