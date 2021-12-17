using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using PetShop.Models.UserModels;
using System.Threading.Tasks;

namespace PetShop.Models
{
    public class DatabaseConnections : DbContext
    {
        public DatabaseConnections(DbContextOptions<DatabaseConnections> options): base(options)
        {

        }

        public DbSet<ProductModel> Product { get; set; }

        public DbSet<CategoryProductModel> ProductCategory { get; set; }

        public DbSet<UserDataModel> MainUserData { get; set; }

        public DbSet<CredentialsModel> Credentials { get; set; }

        public DbSet<TransactionModel> TransactionHistory { get; set; }

        public DbSet<CategoriesModel> Category { get; set; }

        public DbSet<UserAdressModel> UserAdress { get; set; }

        public DbSet<CreditCardModel> CreditCardInfo { get; set; }

    }
}
