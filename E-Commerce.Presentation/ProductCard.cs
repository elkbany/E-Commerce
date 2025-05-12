using System;
using System.Windows.Forms;
using E_Commerce.BL.Contracts.Services;
using E_Commerce.BL.Features.CartItem.DTO;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;

namespace E_Commerce.Presentation
{
    public partial class ProductCard : UserControl
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int ProductId { get; private set; }
        private int userId;

        public ProductCard()
        {
            InitializeComponent();
        }

        public void SetProductData(int productId, string productName, decimal price, string category, int userId)
        {
            ProductId = productId;
            this.userId = userId;
            lblProductName.Text = productName;
            lblPrice.Text = $"Price: ${price:F2}";
            lblCategory.Text = $"Category: {category}";
        }

        private async void btnAddToCart_Click(object sender, EventArgs e)
        {
            var cartService = ServiceProviderContainer.ServiceProvider.GetRequiredService<ICartItemServices>();
            var cartItemDto = new AddCartItemDTO
            {
                UserId = userId,
                ProductId = ProductId,
                Quantity = 1 // الكمية الافتراضية
            };
            try
            {
                await cartService.AddToCartAsync(cartItemDto);
                MessageBox.Show($"Product ID {ProductId} added to cart!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding to cart: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}