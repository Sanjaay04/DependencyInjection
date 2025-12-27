using DependencyInjection.Interface;
using Microsoft.AspNetCore.Mvc;


namespace DependencyInjection.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly Iproductservice _productService;
        private readonly Ilogger _logger;
        private readonly Idiscount _discount;

        //Constructor Injection
        public ProductController(Iproductservice productService, Ilogger logger, Idiscount discount)
        {
            _productService = productService;
            _logger = logger;
            _discount = discount;
        }
        [FromServices]//if not use from service is will call as null in property injection 
        public Iproductservice PropertyInjection { get; set; }

        [HttpGet("ConstructorInjection")]

        public IActionResult GetConstructorInjection()
        {
            _logger.Log("Constructor Injection method called.");
            var products = _productService.Getallproducts();
            
            return Ok(products);
            
        }

        [HttpGet("MethodInjection")]

        public IActionResult Getmethodinjection(Iproductservice methodinjection)
        {
            _logger.Log("Method Injection method called.");
            var products = methodinjection.Getallproducts();
            return Ok(products);
        }

        [HttpGet("PropertyInjection")]

        public IActionResult GetpropertyInjection()
        {
            _logger.Log("Property Injection method called.");
            if (PropertyInjection == null)
                return BadRequest("Bad");

            var products = PropertyInjection.Getallproducts();
            return Ok(products);
        }

        [HttpGet("DiscountedProducts")]

        public IActionResult GetDiscountedProducts()
        {
            _logger.Log("Getting discounted products.");
            var products = _productService.Getallproducts();
            var discountedProducts = products.Select(p => new
            {
                p.Id,
                p.Name,
                OriginalPrice = p.Price,
                DiscountedPrice = _discount.ApplyDiscount(p.Price)
            });
            return Ok(discountedProducts);
        }
    }
}



