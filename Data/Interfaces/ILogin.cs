using PetShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShop.Data.Interfaces
{
    public interface ILogin
    {

        CredentialsModel Login(CredentialsModel credentials);
    }
}
