using E_Commerce.BL.Contracts.Services;
using E_Commerce.BL.Features.CartItem.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace E_Commerce.Presentation
{
    public partial class frmCart : Form
    {
        private readonly ICartItemServices cartServices;
        private readonly int userId;
        private List<CartItemDTO> cartItems = new List<CartItemDTO>(); // Cache محلي

        public frmCart(ICartItemServices cartServices, int userId)
        {
            InitializeComponent();
            this.cartServices = cartServices;
            this.userId = userId;
            LoadCartItems();
        }

        private async void LoadCartItems()
        {
            try
            {
                cartItems = (await cartServices.GetCartItemsByUserIdAsync(userId)).ToList();
                flowLayoutPanelCart.Controls.Clear();

                if (cartItems.Any())
                {
                    lblNoItems.Visible = false;
                    foreach (var item in cartItems)
                    {
                        var cartItemCard = new CartItemCard(cartServices);
                        cartItemCard.SetCartItemData(item);
                        cartItemCard.CartUpdated += CartItemCard_CartUpdated;
                        flowLayoutPanelCart.Controls.Add(cartItemCard);
                    }
                    UpdateCartTotal();
                }
                else
                {
                    lblNoItems.Visible = true;
                    lblTotal.Text = "$0.00";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading cart: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateCartTotal()
        {
            decimal total = cartItems.Sum(item => item.TotalPrice); // استخدام الـ Cache
            lblTotal.Text = $"${total:F2}";
        }

        private async void CartItemCard_CartUpdated(object sender, EventArgs e)
        {
            try
            {
                // تحديث الـ Cache من الداتابيز فقط للتأكد من الوضع الحالي
                var updatedCart = await cartServices.GetCartItemsByUserIdAsync(userId);
                cartItems = updatedCart.ToList();

                // إعادة تحميل الـ Controls بناءً على الـ Cache
                flowLayoutPanelCart.Controls.Clear();
                if (cartItems.Any())
                {
                    lblNoItems.Visible = false;
                    foreach (var item in cartItems)
                    {
                        var cartItemCard = new CartItemCard(cartServices);
                        cartItemCard.SetCartItemData(item);
                        cartItemCard.CartUpdated += CartItemCard_CartUpdated;
                        flowLayoutPanelCart.Controls.Add(cartItemCard);
                    }
                    UpdateCartTotal();
                }
                else
                {
                    lblNoItems.Visible = true;
                    lblTotal.Text = "$0.00";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating cart: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnCheckout_Click(object sender, EventArgs e)
        {
            try
            {
                btnCheckout.Enabled = false;
                btnCheckout.Text = "Processing...";

                var cartItems = await cartServices.GetCartItemsByUserIdAsync(userId);
                if (!cartItems.Any())
                {
                    MessageBox.Show("Your cart is empty.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                await cartServices.SubmitCartAsync(userId);
                MessageBox.Show("Order submitted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCartItems(); // إعادة تحميل الـ Cart
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error submitting order: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnCheckout.Enabled = true;
                btnCheckout.Text = "Proceed to Checkout";
            }
        }
    }
}