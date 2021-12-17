using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PetShop.Models;
using PetShop.Models.UserModels;
using PetShop.Data;
using PetShop.Data.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace PetShop.Controllers.UserControllers
{
    [Authorize]
    [ApiController]
    public class LoggedInUserController : ControllerBase
    {
        private IUserDetails _data;
        public LoggedInUserController(IUserDetails data)
        {
            _data = data;
        }
        [HttpPost]
        [Route("api/newTransaction")]
        public IActionResult AddNewTransactionFunction(TransactionModel newTransaction)
        {
            return Ok(_data.AddNewTransaction(newTransaction));
        }

        [HttpPatch]
        [Route("api/editUserInfo/{id}")]
        public IActionResult EditUserInfoFunction(UserDataModel modifyUserData)
        {
            var singleUser = _data.GetUserByID(modifyUserData.UserID);
            if (singleUser != null)
            {
                _data.ModifyExistingUser(singleUser);
                return Ok();
            }
            else return NotFound("User isn't found");
        }
        [HttpPatch]
        [Route("api/editUserAdress/{id}")]
        public IActionResult EditUserAdressFunction(UserAdressModel newAdress, Guid userId)
        {
            var singleUser = _data.GetUserByID(userId);
            
            if (singleUser != null)
            {
                Guid UserAdressID = singleUser.UserAdressidKey;
                newAdress.UserAdressID = UserAdressID;
                _data.ModifyExistingUsersAdress(newAdress);
                return Ok();
            }
            else return NotFound("Adress isn't found");
        }

        [HttpPatch]
        [Route("api/editUserCreditCardInfo/{id}")]
        public IActionResult EditUserInfoFunction(CreditCardModel newCreditCard)
        {
            var card = _data.GetCreditCardByNumber(newCreditCard.CreditCardNumber);
            if (card != null)
            {
                _data.ModifyExistingUsersCreditCard(newCreditCard);
                return Ok();
            }
            else return NotFound("Card isn't found");
        }

        [HttpPost]
        [Route("api/newCard")]
        public IActionResult AddNewCreditCardForUser(Guid userId, string creditCardNumber, string expiryDate)
        {
            CreditCardModel newCard = new CreditCardModel();
            if (creditCardNumber.Length==16) {
                if (expiryDate.Length == 4)
                {
                    string date = DateTime.Today.ToString("yyMM");
                    if (date.CompareTo(expiryDate)==1) {
                        newCard.CreditCardNumber = creditCardNumber;
                        newCard.CreditCardExpiryDate = expiryDate;
                        newCard.CardOwnerID = userId;
                        newCard.CardOwner = _data.GetUserByID(userId);
                        return Ok(_data.AddNewCardForUser(newCard));
                    }
                    else NotFound("Card expired");
                }
                else NotFound("Wrong entry, expiry date is wrong");
            }
            else NotFound("Wrong entry, credit card number is too short");
            return Ok();
        }
    }
}
