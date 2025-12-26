using DependencyInjection.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjection.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly Iproductservice _productService;

        //Constructor Injection
        public ProductController(Iproductservice productService)
        {
            _productService = productService;
        }
        [FromServices]//if not use from service is will call as null in property injection 
        public Iproductservice PropertyInjection { get; set; }

        [HttpGet("ConstructorInjection")]
        public IActionResult GetConstructorInjection()
        {
            var products = _productService.Getallproducts();
            return Ok(products);
        }

        [HttpGet("MethodInjection")]

        public IActionResult Getmethodinjection(Iproductservice methodinjection)
        {
            var products = methodinjection.Getallproducts();
            return Ok(products);
        }

        [HttpGet("PropertyInjection")]

        public IActionResult GetpropertyInjection()
        {
            if (PropertyInjection == null)
                return BadRequest("Bad");

            var products = PropertyInjection.Getallproducts();
            return Ok(products);
        }
    }
}



