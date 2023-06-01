using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using api.Repository;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Product : ControllerBase
    {
        private IProduct _IProduct;

        public Product(IProduct productInterface) => _IProduct = productInterface;


        [HttpPost]
        public ActionResult AddProduct([FromBody] ProductModel product)
        {
            _IProduct.addProduct(product);
            return Ok(product);
        }

        [HttpGet("{Name?}")]
        public List<ProductModel> listProducts(string? Name)
        {
            List<ProductModel> product = new List<ProductModel>();

            if(Name.Length > 1){
                Console.Write("passei aqui");
            }
            return product = _IProduct.products();

        }
    }
}