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
                //lblLoading.Visible = true;
                cartItems = (await cartServices.GetCartItemsByUserIdAsync(userId)).ToList();
                //flowLayoutPanelCart.SuspendLayout();
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
            finally
            {
                //lblLoading.Visible = false;
                //flowLayoutPanelCart.ResumeLayout();
            }
        }

        private async void CartItemCard_CartUpdated(object sender, EventArgs e)
        {
            try
            {
                //lblLoading.Visible = true;
                // جلب البيانات الجديدة من الداتابيز وتحديث الـ Cache
                var updatedCart = (await cartServices.GetCartItemsByUserIdAsync(userId)).ToList();

                //flowLayoutPanelCart.SuspendLayout();

                // تحديث ديناميكي للـ UI
                UpdateCartItemsUI(updatedCart);

                // تحديث الـ Cache
                cartItems = updatedCart;

                if (cartItems.Any())
                {
                    lblNoItems.Visible = false;
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
            finally
            {
                //lblLoading.Visible = false;
                //flowLayoutPanelCart.ResumeLayout();
            }
        }

        private void UpdateCartItemsUI(List<CartItemDTO> updatedCart)
        {
            // إزالة الـ Event Handlers القديمة
            foreach (CartItemCard card in flowLayoutPanelCart.Controls.OfType<CartItemCard>())
            {
                card.CartUpdated -= CartItemCard_CartUpdated;
            }

            // تحديث العناصر الموجودة، إضافة عناصر جديدة، وإزالة العناصر المحذوفة
            var existingCards = flowLayoutPanelCart.Controls.OfType<CartItemCard>().ToList();
            foreach (var card in existingCards)
            {
                var updatedItem = updatedCart.FirstOrDefault(x => x.Id == card.CartItemId);
                if (updatedItem != null)
                {
                    // تحديث العنصر الموجود
                    card.SetCartItemData(updatedItem);
                    card.CartUpdated += CartItemCard_CartUpdated;
                }
                else
                {
                    // إزالة العنصر لو مش موجود في الـ Cache الجديد
                    flowLayoutPanelCart.Controls.Remove(card);
                }
            }

            // إضافة العناصر الجديدة
            foreach (var item in updatedCart)
            {
                if (!existingCards.Any(c => c.CartItemId == item.Id))
                {
                    var cartItemCard = new CartItemCard(cartServices);
                    cartItemCard.SetCartItemData(item);
                    cartItemCard.CartUpdated += CartItemCard_CartUpdated;
                    flowLayoutPanelCart.Controls.Add(cartItemCard);
                }
            }
        }

        private void UpdateCartTotal()
        {
            decimal total = cartItems.Sum(item => item.TotalPrice);
            lblTotal.Text = $"${total:F2}";
        }

        private async void btnCheckout_Click(object sender, EventArgs e)
        {
            try
            {
                btnCheckout.Enabled = false;
                btnCheckout.Text = "Processing...";

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

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            LoadCartItems();
        }

        private void flowLayoutPanelCart_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}