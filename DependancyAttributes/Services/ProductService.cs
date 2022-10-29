using DependancyAttributes.Attributes;

namespace DependancyAttributes.Services
{
    [ScopedService(typeof(ProductService))]
    public class ProductService
    {
        public string GetProductName()
        {
            return "My Product";
        }
    }
}
