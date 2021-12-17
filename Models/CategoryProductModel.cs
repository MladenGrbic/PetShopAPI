using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PetShop.Models
{
    public class CategoryProductModel // Because of n to n this is new table for that relation
    {
        [Key]
        public Guid MainID { get; set; }

        [ForeignKey("ProductID")]
        public Guid ProductID { get; set; }
        public ProductModel Product { get; set; }

        [ForeignKey("CategoryID")]
        public Guid CategoryID { get; set; }
        public CategoriesModel Category { get; set; }

        /*Both Category and Product ID could be primaryKeys but convention says that in MSSQL we have to have one 
         main thing for table that is key*/
    }
}
