using E_Commerce.BL.Contracts.Services;
using E_Commerce.BL.Features.CartItem.DTO;
using E_Commerce.BL.Features.Category.DTOs;
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

        public void SetProductData(int id, string name, decimal price, string category)
        {
            productId = id;
            lblProductName.Text = name;
            lblPrice.Text = $"${price}";
            lblCategory.Text = category ?? "Unknown"; // عرض الـ Category كـ string مباشرةً
                                                      // إعداد الصورة إذا كانت موجودة

        }
        private async void btnAddToCart_Click(object sender, EventArgs e)
        {
            try
            {
                // تحقق إذا كان المنتج موجود بالفعل في الـ Cart
                var userCartItems = await cartServices.GetCartItemsByUserIdAsync(userId);
                if (userCartItems.Any(item => item.ProductID == productId))
                {
                    MessageBox.Show("This product is already in your cart!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // تعطيل الزر مؤقتًا
                btnAddToCart.Enabled = false;
                btnAddToCart.Text = "Adding...";

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
            finally
            {
                // إعادة تفعيل الزر
                btnAddToCart.Enabled = true;
                btnAddToCart.Text = "Add to Cart";
            }
        }
    }
}