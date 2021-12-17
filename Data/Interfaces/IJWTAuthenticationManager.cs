using PetShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShop.Data
{
    public interface IJWTAuthenticationManager
    {
        string Authenticate(CredentialsModel credentials);

    }
}
