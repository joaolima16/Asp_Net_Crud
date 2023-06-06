using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using api.Repository;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Product : ControllerBase
    {
        private IProduct _IProduct;

        public Product(IProduct productInterface) => _IProduct = productInterface;
        [Authorize]
        [HttpGet]
        public IActionResult listProducts()
        {
            try
            {
                return Ok(_IProduct.products());
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu algum erro: " + ex.Message);
            }

        }

        [HttpGet("{Name?}")]
        public IActionResult listProduct(string Name)
        {

            if (_IProduct.product(Name).Any())
            {
                
                return Ok(_IProduct.product(Name));
            }
            else
            {
                return NotFound("Não foi possivel encontrar o produto");
            }

        }
        [HttpPost]
        public ActionResult AddProduct([FromBody] ProductModel product)
        {
            try
            {
                _IProduct.addProduct(product);
                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu algum erro: " + ex.Message);
            }

        }
        [HttpPut("{Name}")]
        public IActionResult UpdateProduct(string Name, [FromBody] ProductModel product)
        {
            try
            {
                _IProduct.updateProduct(Name, product);
                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro: " + ex.Message);
            }
        }
        [HttpDelete("{Name}")]
        public IActionResult deleteProduct(string Name)
        {
            try
            {
                _IProduct.deleteProduct(Name);
                return Ok("Produto deletado");

            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro:" + ex.Message);
            }
        }
    }
}