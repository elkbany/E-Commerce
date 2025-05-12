using E_Commerce.BL.Contracts.Services;
using E_Commerce.BL.Features.CartItem.DTO;
using System;
using System.Linq;
using System.Windows.Forms;

namespace E_Commerce.Presentation
{
    public partial class frmCart : Form
    {
        private readonly ICartItemServices cartServices;
        private readonly int userId;

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
                var cartItems = await cartServices.GetCartItemsByUserIdAsync(userId);
                flowLayoutPanelCart.Controls.Clear();

                if (cartItems != null && cartItems.Any())
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

        private async void UpdateCartTotal()
        {
            try
            {
                var cartItems = await cartServices.GetCartItemsByUserIdAsync(userId);
                decimal total = cartItems.Sum(item => item.TotalPrice);
                lblTotal.Text = $"${total:F2}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error calculating total: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CartItemCard_CartUpdated(object sender, EventArgs e)
        {
            UpdateCartTotal();
        }

        private async void btnCheckout_Click(object sender, EventArgs e)
        {
            try
            {
                var cartItems = await cartServices.GetCartItemsByUserIdAsync(userId);
                if (!cartItems.Any())
                {
                    MessageBox.Show("Your cart is empty.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                await cartServices.SubmitCartAsync(userId);
                MessageBox.Show("Order submitted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCartItems();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error submitting order: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}