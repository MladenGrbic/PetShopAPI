using PetShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShop.Data.Interfaces
{
    public interface IAdmin
    {
        ProductModel GetProductByID(Guid ID);

        ProductModel AddNewProduct(ProductModel newProduct, Guid categoryID);

        CategoriesModel AddNewCategory(CategoriesModel newCategory);

        void DeleteProduct(ProductModel ProductForRemoval);

        ProductModel ModifyExistingProduct(ProductModel modifyProduct);

        List<TransactionModel> GetAllTransactions();

        List<ProductModel> SearchBar(string search);

    }
}
