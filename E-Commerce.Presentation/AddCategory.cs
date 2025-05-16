using System;
using System.ComponentModel;
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
        private bool _isEditMode;
        private CategoryDTO _categoryToEdit;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public CategoryDTO SavedCategory { get; private set; }

        public AddCategory(FlowLayoutPanel panel)
        {
            InitializeComponent();
            _targetPanel = panel;
            if (!DesignMode)
            {
                _categoryServices = ServiceProviderContainer.ServiceProvider.GetRequiredService<ICategoryServices>();
                _validator = ServiceProviderContainer.ServiceProvider.GetRequiredService<IValidator<CategoryDTO>>();
            }
            _isEditMode = false;
            label1.Text = "Add New Category";
            Console.WriteLine("[AddCategory] Add mode constructor called.");
        }

        public AddCategory(FlowLayoutPanel panel, CategoryDTO categoryToEdit) : this(panel)
        {
            Console.WriteLine($"[AddCategory] Edit Mode Constructor called for category: Id={categoryToEdit.Id}, Name={categoryToEdit.Name}, Description={categoryToEdit.Description}");
            _isEditMode = true;
            _categoryToEdit = categoryToEdit;
            label1.Text = "Edit Category";
            txtCategoryName.Text = categoryToEdit.Name;
            txtCategoryDesc.Text = categoryToEdit.Description ?? ""; // التأكد إن الـ Description بيتحمل
        }

        private async void btnSave_Click_1(object sender, EventArgs e)
        {
            try
            {
                Console.WriteLine("[AddCategory] Save button clicked.");
                var categoryDTO = new CategoryDTO
                {
                    Name = txtCategoryName.Text,
                    Description = txtCategoryDesc.Text
                };

                var validationResult = await _validator.ValidateAsync(categoryDTO);
                if (!validationResult.IsValid)
                {
                    Console.WriteLine($"[AddCategory] Validation failed: {validationResult.Errors.First().ErrorMessage}");
                    MessageBox.Show(validationResult.Errors.First().ErrorMessage, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (_isEditMode)
                {
                    Console.WriteLine($"[AddCategory] Edit mode: Updating category Id={_categoryToEdit.Id}, Name={_categoryToEdit.Name} to {categoryDTO.Name}, Description={categoryDTO.Description}");
                    categoryDTO.Id = _categoryToEdit.Id;
                    await _categoryServices.UpdateCategoryAsync(_categoryToEdit.Id, categoryDTO);
                    Console.WriteLine($"[AddCategory] Category updated: Id={categoryDTO.Id}, Name={categoryDTO.Name}, Description={categoryDTO.Description}");
                }
                else
                {
                    Console.WriteLine($"[AddCategory] Add mode: Adding category Name={categoryDTO.Name}, Description={categoryDTO.Description}");
                    await _categoryServices.AddCategoryAsync(categoryDTO);
                    var addedCategory = await _categoryServices.GetCategoryByNameAsync(categoryDTO.Name);
                    if (addedCategory != null)
                    {
                        categoryDTO.Id = addedCategory.Id;
                        Console.WriteLine($"[AddCategory] Category added: Id={categoryDTO.Id}, Name={categoryDTO.Name}, Description={categoryDTO.Description}");
                    }
                    else
                    {
                        throw new Exception("Failed to retrieve the added category.");
                    }
                }

                SavedCategory = categoryDTO;

                if (_targetPanel.Tag is Action refreshAction)
                {
                    Console.WriteLine("[AddCategory] Invoking refresh action.");
                    refreshAction.Invoke();
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[AddCategory] Error in btnSave_Click_1: {ex.Message}\nStackTrace: {ex.StackTrace}");
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            Console.WriteLine("[AddCategory] Cancel button clicked.");
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}