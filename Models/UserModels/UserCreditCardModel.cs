using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PetShop.Models.UserModels
{
    public class CreditCardModel
    {

        [Key]
        [Required]
        [MaxLength(16)]
        public string CreditCardNumber { get; set; }

        [Required]
        public string CreditCardExpiryDate { get; set; }

        [ForeignKey("UserID")]
        public Guid CardOwnerID { get; set; }
        public UserDataModel CardOwner { get; set; }

    }
}
