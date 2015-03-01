using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Infrastructure_v0;
using System.Data;

namespace Web_v0._1.Models
{
    public class AccountModel
    {

        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DOB { get; set; }
        public string Location { get; set; }
        public string Image { get; set; }

    }

    public interface IAccountRepository
    {

        AccountModel Get(string username);
        bool Add(AccountModel account);

    }

    public class AccountRepository : IAccountRepository
    {

        public AccountModel Get(string username)
        {
            AccountModel account;

            GetData getAccount = new GetAccountData(username);
            account = ParseDataSetToAccountModel(getAccount.Execute());

            return account;
        }

        public bool Authenticate(string username, string password)
        {
            GetData authAccount = new GetLoginUserData(username, password);

            bool result = (bool) authAccount.Execute().Tables[0].Rows[0][0];

            return result;
        }

        public bool Add(AccountModel account)
        {
            bool wasSuccess = false;

            CreateData newUser = new CreateNewAccountData(account.Username, account.Name, account.Email, account.DOB, account.Location, account.Password);
            wasSuccess = newUser.DoInsert();
            
            return wasSuccess; 
        }

        private AccountModel ParseDataSetToAccountModel(DataSet dsAccount)
        {
            try
            {
                DataRow resultRow = dsAccount.Tables[0].Rows[0];
                return new AccountModel()
                {
                    Username = resultRow["Username"].ToString(),
                    Password = "",
                    Name = resultRow["Username"].ToString(),
                    Email = resultRow["Email"].ToString(),
                    DOB = Convert.ToDateTime(resultRow["DOB"].ToString()),
                    Location = resultRow["Location"].ToString(),
                    Image = ""
                };
            }
            catch
            {
                return new AccountModel();
            }
        }

    }

}