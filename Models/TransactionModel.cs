using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using PetShop.Models.UserModels;

namespace PetShop.Models
{
    public class TransactionModel
    {
        [Key]
        public Guid TransactionID { get; set; }

        [Required]
        public List<ProductModel> BoughtProduct { get; set; }

        [ForeignKey("UserID")]
        public UserDataModel UserDetailsAndCreditCardNumber { get; set; }

        [Required]
        public string Adress { get; set; }
    }
}
