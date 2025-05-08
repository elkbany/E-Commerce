using E_Commerce.BL.Contracts.Repositories;
using E_Commerce.Domain.Enums;
using E_Commerce.Domain.Models;
using FluentValidation;
using System.Threading.Tasks;

namespace E_Commerce.BL.Validators
{
    public class OrderDTOValidator : AbstractValidator<int>
    {
        private readonly IOrderRepository _orderRepository;
        private Order _order;

        public OrderDTOValidator(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;

            RuleFor(orderId => orderId)
                .MustAsync(async (orderId, cancellation) =>
                {
                    try
                    {
                        _order = await _orderRepository.GetByIdAsync(orderId);
                        return _order != null;
                    }
                    catch
                    {
                        return false;
                    }
                })
                .WithMessage("Failed to retrieve order or order does not exist.")
                .DependentRules(() =>
                {
                    RuleFor(orderId => _order.Status)
                        .Equal(OrderStatus.Pending)
                        .WithMessage("Order can only be processed if it is in Pending status.");
                });
        }
    }
}