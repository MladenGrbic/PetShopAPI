using Microsoft.EntityFrameworkCore;
using PetShop.Data.Interfaces;
using PetShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShop.Data
{
    public class LoginData : ILogin
    {
        private DatabaseConnections _DataConnection;
        public LoginData(DatabaseConnections DataConnection)
        {
            _DataConnection = DataConnection;
        }
        public CredentialsModel Login(CredentialsModel credentials)
        {

            return _DataConnection.Credentials.FromSqlInterpolated($"SELECT * FROM Product WHERE Product.Username='{credentials.Username}' AND Product.Password='{credentials.Password}')").Single();
        }
    }
}
