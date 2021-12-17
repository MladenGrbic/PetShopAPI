using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PetShop.Models
{
    public class ProductModel
    {
        [Key]
        public Guid ProductId { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        public string ProductColour { get; set; }

        public ICollection<CategoryProductModel> Category { get; set; }

        [Required]
        public double ProductPrice { get; set; }

        [Required]
        public string ProductDescription { get; set; }

        public string ProductImage { get; set; }

    }
}
