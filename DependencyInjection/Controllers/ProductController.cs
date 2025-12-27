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
        //Constructor Injection
        public ProductController(Iproductservice productService, Ilogger logger)
        {
            _productService = productService;
            _logger = logger;
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
    }
}



