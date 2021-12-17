using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetShop.Models.UserModels
{
    public class UserAdressModel
    {
        [Key]
        [Required]
        public Guid UserAdressID { get; set; }
        
        [Required]
        public string FirstAdress { get; set; }
        
        public string SecondAdress { get; set; }
 
        public string ThirdAdress { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public int PostalCode { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string Country { get; set; }

        public ICollection<UserDataModel> User { get; set; }

    }
}
