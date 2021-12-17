using PetShop.Models;
using PetShop.Models.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShop.Data.Interfaces
{
    public interface IProductShow
    {
        List<ProductModel> GetAllProducts();

        List<ProductModel> SearchBar(string search);

        ProductModel GetProductByID(Guid ID);

        UserDataModel AddNewUser(string username, string password, string nameAndSurname, string telephoneNumber, UserAdressModel adress);

        UserAdressModel AddNewAdress(UserAdressModel newAdress);

    }
}
