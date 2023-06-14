using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using api.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Auth : ControllerBase
    {
        [HttpPost]
        public IActionResult Authentication([FromBody] UserModel user)
        {
            Console.Write(user.Email);
            if (user.Email == "teste" && user.Password == "123")
            {
                Token tokenTeste = new Token();
                var token = tokenTeste.GenerateToken(user.Email);
                return Ok(token);
            }
            else{
                return BadRequest("Login invalido");
            }
        }
    }
}
