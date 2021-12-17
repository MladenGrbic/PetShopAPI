using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PetShop.Data.Interfaces;
using PetShop.Models.UserModels;
using PetShop.Models;

namespace PetShop.Data
{
    public class UserInfoData : IUserDetails
    {
        private DatabaseConnections _DataConnection;
        public UserInfoData(DatabaseConnections DataConnection)
        {
            _DataConnection = DataConnection;
        }

        public TransactionModel AddNewTransaction(TransactionModel newTransaction)
        {
            _DataConnection.TransactionHistory.Add(newTransaction);
            _DataConnection.SaveChanges();
            return newTransaction;
        }

        public UserDataModel ModifyExistingUser(UserDataModel modifyUserData)
        {
            _DataConnection.MainUserData.Update(modifyUserData);
            _DataConnection.SaveChanges();
            return modifyUserData;
        }

        public UserAdressModel ModifyExistingUsersAdress(UserAdressModel modifyAdress)
        {
            _DataConnection.UserAdress.Update(modifyAdress);
            _DataConnection.SaveChanges();
            return modifyAdress;
        }

        public CreditCardModel ModifyExistingUsersCreditCard(CreditCardModel modifyCC)
        {
            _DataConnection.CreditCardInfo.Update(modifyCC);
            _DataConnection.SaveChanges();
            return modifyCC;
        }

        public UserDataModel GetUserByID(Guid ID)
        {
            return _DataConnection.MainUserData.Find(ID);
        }

        public UserAdressModel GetAdressByID(Guid ID)
        {
            return _DataConnection.UserAdress.Find(ID);
        }

        public CreditCardModel GetCreditCardByNumber(string creditCardNumber)
        {
            return _DataConnection.CreditCardInfo.Find(creditCardNumber);
        }

        public CreditCardModel AddNewCardForUser(CreditCardModel newCCard)
        {
            _DataConnection.CreditCardInfo.Add(newCCard);
            _DataConnection.SaveChanges();
            return newCCard;
        }
    }
}
