using PetShop.Models.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PetShop.Models;

namespace PetShop.Data.Interfaces
{
    public interface IUserDetails
    {
        UserDataModel ModifyExistingUser(UserDataModel modifyUserData);

        UserAdressModel ModifyExistingUsersAdress(UserAdressModel modifyUserData);


        TransactionModel AddNewTransaction(TransactionModel newTransaction);

        UserDataModel GetUserByID(Guid ID);

        UserAdressModel GetAdressByID(Guid ID);

        CreditCardModel GetCreditCardByNumber(string creditCardNumber);

        CreditCardModel ModifyExistingUsersCreditCard(CreditCardModel modifyCCard);

        CreditCardModel AddNewCardForUser(CreditCardModel newCCard);
    }
}
