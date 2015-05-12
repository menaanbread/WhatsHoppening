using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsHoppening.Domain;
using WhatsHoppening.Domain.Interfaces;

namespace WhatsHoppening.Providers.UserManager
{
    public class MockedUserManager : IUserManager
    {
        private static List<User> allUsers = null;
                
        public MockedUserManager()
        {
            allUsers = new List<User>();

            allUsers.Add(new User() { AccountType = Permission.Admin, Country = Country.UnitedKingdom, Created = DateTime.Now, Id = 1, Location = "Warrington", UserName = "Tom" });
            allUsers.Add(new User() { AccountType = Permission.Standard, Country = Country.UnitedKingdom, Created = DateTime.Now, Id = 2, Location = "London", UserName = "Test1" });
            allUsers.Add(new User() { AccountType = Permission.Standard, Country = Country.France, Created = DateTime.Now, Id = 3, Location = "Paris", UserName = "LeTest" });
            allUsers.Add(new User() { AccountType = Permission.Standard, Country = Country.Germany, Created = DateTime.Now, Id = 4, Location = "Berlin", UserName = "DerTesdt" });
            allUsers.Add(new User() { AccountType = Permission.Standard, Country = Country.UnitedStatesOfAmerica, Created = DateTime.Now, Id = 5, Location = "New York", UserName = "Test2" });
            allUsers.Add(new User() { AccountType = Permission.Standard, Country = Country.Belgium, Created = DateTime.Now, Id = 6, Location = "Gent", UserName = "DieTyst" });
            allUsers.Add(new User() { AccountType = Permission.Standard, Country = Country.Denmark, Created = DateTime.Now, Id = 7, Location = "Allborg", UserName = "rodegrodmegfloge" });
        }

        public User GetUser()
        {
            return allUsers[0];
        }

        public User GetUser(int id)
        {
            return allUsers.Find(u => u.Id == id);
        }

        public User GetUser(string username)
        {
            return allUsers.Find(u => u.UserName.Equals(username, StringComparison.InvariantCultureIgnoreCase));
        }

        public void SaveUser(User user)
        {
            allUsers.RemoveAll(u => u.Id == user.Id);
            allUsers.Add(user);
        }
    }
}
