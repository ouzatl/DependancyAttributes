using DependancyAttributes.Services;
using DependancyAttributes.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DependancyAttributes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {

        private readonly IOrderService orderService;

        private readonly ProductService productService;

        public TestController(IOrderService orderService, ProductService productService)
        {
            this.orderService = orderService;
            this.productService = productService;
        }

        [HttpGet("getorder")]
        public  string GetOrder()
        {
            return orderService.GetOrder();
        }


        [HttpGet("getproductname")]
        public string GetProductName()
        {
            return productService.GetProductName();
        }
    }
}