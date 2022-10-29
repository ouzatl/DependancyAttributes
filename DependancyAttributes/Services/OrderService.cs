using DependancyAttributes.Attributes;
using DependancyAttributes.Services.Interfaces;

namespace DependancyAttributes.Services
{
    [ScopedService(typeof(OrderService),typeof(IOrderService))]

    public class OrderService : IOrderService
    {
        public string GetOrder()
        {
            return "My Order";
        }
    }
}
