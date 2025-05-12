using E_Commerce.BL.Contracts.Services;
using E_Commerce.BL.Features.CartItem.DTO;
using System;
using System.Windows.Forms;

namespace E_Commerce.Presentation
{
    public partial class ProductCard : UserControl
    {
        private readonly ICartItemServices cartServices;
        private readonly int userId;
        private int productId;

        public ProductCard(ICartItemServices cartServices, int userId)
        {
            InitializeComponent();
            this.cartServices = cartServices;
            this.userId = userId;
        }

        public void SetProductData(int productId, string name, decimal price, string category)
        {
            this.productId = productId;
            lblProductName.Text = name;
            lblPrice.Text = $"${price:F2}";
            lblCategory.Text = category ?? "Unknown";
            // Placeholder image (replace with real image later)
            //pictureBoxProduct.Image = Properties.Resources.placeholder_product;
        }

        private async void btnAddToCart_Click(object sender, EventArgs e)
        {
            try
            {
                var cartItemDto = new AddCartItemDTO
                {
                    UserId = userId,
                    ProductId = productId,
                    Quantity = 1
                };
                var result = await cartServices.AddToCartAsync(cartItemDto);
                if (result != null)
                {
                    MessageBox.Show("Product added to cart!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to add product to cart.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}