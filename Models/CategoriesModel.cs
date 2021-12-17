using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PetShop.Models
{
    public class CategoriesModel
    {
        [Key]
        public Guid CategoryID { get; set; }

        [Required]
        public string CategoryName { get; set; }

        public ICollection<CategoryProductModel> Product { get; set; }
    }
}
