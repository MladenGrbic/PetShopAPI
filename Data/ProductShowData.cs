using Microsoft.EntityFrameworkCore;
using PetShop.Models;
using System;
using PetShop.Data.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetShop.Models.UserModels;

namespace PetShop.Data
{
    // Class about data that all users can use, logged or not
    public class ProductShowData : IProductShow
    {
        private DatabaseConnections _DataConnection;
        public ProductShowData(DatabaseConnections DataConnection)
        {
            _DataConnection = DataConnection;
        }

        public UserDataModel AddNewUser(string username, string password, string nameAndSurname, string telephoneNumber, UserAdressModel adress)
        {
            UserDataModel newUser = new UserDataModel();
            var newId = Guid.NewGuid();
            newUser.UserID = newId;
            newUser.UserStatus = 1;
            newUser.UserNameAndSurname = nameAndSurname;
            newUser.UserTelephoneNumber = telephoneNumber;
            newUser.UserAdressidKey = adress.UserAdressID;
            newUser.UserAdress = adress;
            var a = AddNewAdress(adress);

            var temp = _DataConnection.Credentials.FromSqlRaw($"SELECT Username, User FROM Credentials WHERE Username = '" + username +"'").ToList();
            if (temp != null)
            {
                _DataConnection.MainUserData.Add(newUser);
                string VignerUsernameAPIKey = "keypetapimaxtwentycr";
                string VignerPasswordAPIKey = "passpetkeyvignerchar";

                CredentialsModel trueCredentials = new CredentialsModel();
                StringBuilder sbUsername = new StringBuilder(trueCredentials.Username);
                StringBuilder sbPassword = new StringBuilder(trueCredentials.Password);
                for (int b = 0; b < username.Length; b++)
                {
                    sbUsername[b] = (char)(96 + ((username[b] + VignerUsernameAPIKey[b]) % 26));
                }
                for (int b = 0; b < password.Length; b++)
                {
                    sbPassword[b] = (char)(96 + ((password[b] + VignerPasswordAPIKey[b]) % 26));
                }
                trueCredentials.Username = sbUsername.ToString();
                trueCredentials.Password = sbPassword.ToString();
                trueCredentials.User = newUser;
                _DataConnection.Credentials.Add(trueCredentials);
                _DataConnection.SaveChanges();
                return newUser;
            }
            else return null;
            
        }

        public UserAdressModel AddNewAdress(UserAdressModel newAdress)
        {
            _DataConnection.UserAdress.Add(newAdress);
            _DataConnection.SaveChanges();
            return newAdress;
        }

        public List<ProductModel> GetAllProducts()
        {
            return _DataConnection.Product.FromSqlInterpolated($"SELECT * FROM Product").ToList();
        }

        public ProductModel GetProductByID(Guid ID)
        {
            return _DataConnection.Product.Find(ID);
        }

        public List<ProductModel> SearchBar(string search)
        {
            var a = _DataConnection.Product.FromSqlRaw($"SELECT * FROM TKnjigeICasopisi WHERE naziv LIKE '%" + search + "%'").ToList();
            return a;
        }
    }
}
