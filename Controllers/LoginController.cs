using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetShop.Data;
using PetShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Controllers
{
    [Authorize]
    [Route("api/login/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IJWTAuthenticationManager _adminUserData;
        public LoginController(IJWTAuthenticationManager adminUserData)
        {
            _adminUserData = adminUserData;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Login(string credentialsUsername, string credentialsPassword)
        {
            string VignerUsernameAPIKey = "keypetapimaxtwentycr";
            string VignerPasswordAPIKey = "passpetkeyvignerchar";

            CredentialsModel trueCredentials = new CredentialsModel();
            StringBuilder sbUsername = new StringBuilder(trueCredentials.Username);
            StringBuilder sbPassword = new StringBuilder(trueCredentials.Password);
            for (int b = 0; b < credentialsUsername.Length; b++)
            {
                sbUsername[b] = (char)(96 + ((credentialsUsername[b] + VignerUsernameAPIKey[b]) % 26));
            }
            for (int b = 0; b < credentialsPassword.Length; b++)
            {
                sbPassword[b] = (char)(96 + ((credentialsPassword[b] + VignerPasswordAPIKey[b]) % 26));
            }
            trueCredentials.Username = sbUsername.ToString();
            trueCredentials.Password = sbPassword.ToString();
            var token = _adminUserData.Authenticate(trueCredentials);
            if (token != null)
            {
                return Ok(token);
            }
            else return Unauthorized();
        }
    }
}
