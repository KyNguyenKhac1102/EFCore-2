using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using EFCore4.Services;
using EFCore4.Models;
namespace EFCore4.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {

        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public List<Product> GetAllProducts()
        {
            return _productService.getAll();
        }

        [HttpPost]
        public List<Product> CreateProducts(ProductDTO productDTO)
        {
             _productService.Create(productDTO);
            return _productService.getAll();
        }
        [HttpPut("{id}")]
        public ActionResult UpdateProducts(int id, ProductDTO productDTO){
            if(_productService.Update(id, productDTO)){
                return StatusCode(200);
            }
            
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public List<Product> DeleteProducts(int id){
            _productService.Delete(id);
            return _productService.getAll();
        }
    }
}
