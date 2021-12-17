using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PetShop.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using PetShop.Data.Interfaces;
using PetShop.Data;

namespace PetShop.Controllers
{
    public class AuthManager : IJWTAuthenticationManager
    {
        private DatabaseConnections _DataConnection;
        private readonly string key;
        public AuthManager(DatabaseConnections DataConnection)
        {
            _DataConnection = DataConnection;
        }
        public AuthManager(string key)
        {
            this.key = key;
        }

        public string Authenticate(CredentialsModel credentials)
        {
            var checker = _DataConnection.Credentials.FromSqlInterpolated($"SELECT * FROM Product WHERE Product.Username='{credentials.Username}' AND Product.Password='{credentials.Password}')").Single();
            if (checker == null) return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(key);
            var tokenDescriptor = new SecurityTokenDescriptor {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name, credentials.Username)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
