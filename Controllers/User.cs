using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Models;
using api.Repository;
using api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class User : ControllerBase
    {

        private IUser _IUser;

        public User(IUser iuser) => _IUser = iuser;



        [HttpGet]
        public IActionResult selectUser([FromBody] UserModel user)
        {
            var tokenGenerator = new Token();
            if (_IUser.userExists(user) == true)
            {
                return Ok(tokenGenerator.GenerateToken(user.Email));
            }
            return BadRequest("Login invalido");

        }
        [HttpPost]
        public IActionResult AddUser([FromBody] UserModel user)
        {
            try
            {
                _IUser.addUser(user);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles = "admin")]
        [HttpPut("{Id?}")]
        public IActionResult updateUser(int id, UserModel user)
        {
            try
            {
                _IUser.updateUser(id, user);
                return Ok($"Usuário com id: {id} foi atualizado");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [Authorize]
        [HttpDelete("{id?}")]
        public IActionResult deleteUser(int id)
        {
            try
            {
                _IUser.deleteUser(id);
                return Ok("Usuário foi deletado");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest("Ocorreu um erro ao deletar o usuário");

            }

        }
    }
}