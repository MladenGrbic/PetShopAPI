using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PetShop.Data.Interfaces;
using PetShop.Models;

namespace PetShop.Data
{
    public class AdminData : IAdmin
    {
        private DatabaseConnections _DataConnection;
        public AdminData(DatabaseConnections DataConnection)
        {
            _DataConnection = DataConnection;
        }
        public CategoriesModel AddNewCategory(CategoriesModel newCategory)
        {
            _DataConnection.Category.Add(newCategory);
            _DataConnection.SaveChanges();
            return newCategory;
        }

        public ProductModel AddNewProduct(ProductModel newProduct, Guid categoryID)
        {
            newProduct.ProductId = Guid.NewGuid();
            _DataConnection.Product.Add(newProduct);
            CategoryProductModel newRecord = new CategoryProductModel();
            newRecord.CategoryID = categoryID;
            newRecord.ProductID = newProduct.ProductId;
            newRecord.MainID = Guid.NewGuid();
            _DataConnection.ProductCategory.Add(newRecord);
            _DataConnection.SaveChanges();
            return newProduct;
        }

        public void DeleteProduct(ProductModel ProductForRemoval)
        {
            _DataConnection.Product.Remove(ProductForRemoval);
            _DataConnection.SaveChanges();
        }

        public List<TransactionModel> GetAllTransactions()
        {
            return _DataConnection.TransactionHistory.FromSqlInterpolated($"SELECT * FROM Product").ToList();
        }

        public ProductModel GetProductByID(Guid ID)
        {
            return _DataConnection.Product.Find(ID);
        }

        public ProductModel ModifyExistingProduct(ProductModel modifyProduct)
        {
            _DataConnection.Product.Update(modifyProduct);
            _DataConnection.SaveChanges();
            return modifyProduct;

        }

        public List<ProductModel> SearchBar(string search)
        {
            var a = _DataConnection.Product.FromSqlRaw($"SELECT * FROM TKnjigeICasopisi WHERE naziv LIKE '%" + search + "%'").ToList();
            return a;
        }
    }
}
