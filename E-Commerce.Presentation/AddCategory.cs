using System;
using System.Windows.Forms;
using E_Commerce.BL.Contracts.Services;
using E_Commerce.BL.Features.Category.DTOs;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace E_Commerce.Presentation
{
    public partial class AddCategory : Form
    {
        private readonly FlowLayoutPanel _targetPanel;
        private readonly ICategoryServices _categoryServices;
        private readonly IValidator<CategoryDTO> _validator;

        public AddCategory(FlowLayoutPanel panel)
        {
            InitializeComponent();
            _targetPanel = panel;
            if (!DesignMode)
            {
                _categoryServices = ServiceProviderContainer.ServiceProvider.GetRequiredService<ICategoryServices>();
                _validator = ServiceProviderContainer.ServiceProvider.GetRequiredService<IValidator<CategoryDTO>>();
            }
            label1.Text = "Add New Category";
        }

        private async void btnSave_Click_1(object sender, EventArgs e)
        {
            try
            {
                var categoryDTO = new CategoryDTO
                {
                    Name = txtCategoryName.Text
                };

                // Validate the CategoryDTO
                var validationResult = await _validator.ValidateAsync(categoryDTO);
                if (!validationResult.IsValid)
                {
                    MessageBox.Show(validationResult.Errors.First().ErrorMessage, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Add the category using the service
                await _categoryServices.AddCategoryAsync(categoryDTO);

                // Notify CategoriesPage to refresh
                if (_targetPanel.Tag is Action refreshAction)
                {
                    refreshAction.Invoke();
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding category: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}