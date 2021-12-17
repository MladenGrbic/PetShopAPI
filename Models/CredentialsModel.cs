using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using PetShop.Models.UserModels;

namespace PetShop.Models
{
    public class CredentialsModel
    {
        [Key]
        public string Username { get; set; }

        [Required]
        [MaxLength(20,ErrorMessage = "Password cant be longer than 20 characters")]
        public string Password { get; set; }

        [ForeignKey("UserID")]
        public Guid UserID { get; set; }
        public UserDataModel User { get; set; }

    }
}
