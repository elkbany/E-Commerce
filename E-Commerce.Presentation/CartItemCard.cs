using E_Commerce.BL.Contracts.Services;
using E_Commerce.BL.Features.CartItem.DTO;
using System;
using System.Windows.Forms;

namespace E_Commerce.Presentation
{
    public partial class CartItemCard : UserControl
    {
        private readonly ICartItemServices cartServices;
        private int cartItemId;
        private decimal unitPrice;
        private bool isUpdating = false; // Flag لمنع التكرار
        public int CartItemId => cartItemId;

        public event EventHandler CartUpdated;

        public CartItemCard(ICartItemServices cartServices)
        {
            InitializeComponent();
            this.cartServices = cartServices;
        }

        public void SetCartItemData(CartItemDTO cartItem)
        {
            cartItemId = cartItem.Id;
            unitPrice = cartItem.ProductPrice;
            lblProductName.Text = cartItem.ProductName;
            lblPrice.Text = $"${unitPrice:F2}";
            numericQuantity.Value = cartItem.Quantity;
            lblSubtotal.Text = $"${cartItem.TotalPrice:F2}";
            // Placeholder image
            //pictureBoxProduct.Image = Properties.Resources.placeholder_product;
        }

        private async void numericQuantity_ValueChanged(object sender, EventArgs e)
        {
            if (isUpdating) return; // منع التكرار

            try
            {
                isUpdating = true;
                int newQuantity = (int)numericQuantity.Value;
                if (newQuantity <= 0)
                {
                    await RemoveItem();
                    return;
                }

                var quantityDto = new UpdateCartItemQuantityDTO { Quantity = newQuantity };
                var result = await cartServices.UpdateProductQuantityAsync(cartItemId, quantityDto);
                if (result != null)
                {
                    lblSubtotal.Text = $"${result.TotalPrice:F2}";
                    CartUpdated?.Invoke(this, EventArgs.Empty);
                }
                else
                {
                    MessageBox.Show("Failed to update quantity.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                isUpdating = false;
            }
        }

        private async void btnRemove_Click(object sender, EventArgs e)
        {
            await RemoveItem();
        }

        private async Task RemoveItem()
        {
            try
            {
                await cartServices.DeleteFromCartAsync(cartItemId);
                this.Parent.Controls.Remove(this);
                CartUpdated?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}