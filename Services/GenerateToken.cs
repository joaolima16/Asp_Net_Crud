using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using api.Models;
using Microsoft.IdentityModel.Tokens;

namespace api.Services
{
   public class Token{
    public string GenerateToken(string pass){
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(Key.Secret);

        var claim =  new Claim(ClaimTypes.Name,"admin");
        var tokenDescriptor = new SecurityTokenDescriptor{
            Subject = new System.Security.Claims.ClaimsIdentity(new [] {new Claim(ClaimTypes.Name, pass)}),
            Expires = DateTime.UtcNow.AddMinutes(3),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        
        
        return tokenHandler.WriteToken(token);
    }
   }
}