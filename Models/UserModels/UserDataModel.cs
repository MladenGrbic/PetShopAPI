using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PetShop.Models.UserModels
{
    public class UserDataModel
    {
        [Key]
        public Guid UserID { get; set; }

        [Required]
        public int UserStatus { get; set; }
        /*Using numbers here to define multiple status of one user, so 1 is user, 2 is admin, we can have user that is using both statuses
         and his User status would be 0x03 or simply 3, if you want to check if he is user than you check with & operator and number
        for that position*/

        [Required]
        public string UserNameAndSurname{ get; set; }

        [Required]
        public string UserTelephoneNumber { get; set; }

        [ForeignKey("UserAdressID")]
        [Required]
        public Guid UserAdressidKey { get; set; }
        public UserAdressModel UserAdress { get; set; }

        public ICollection<CreditCardModel> User { get; set; }
    }
}
