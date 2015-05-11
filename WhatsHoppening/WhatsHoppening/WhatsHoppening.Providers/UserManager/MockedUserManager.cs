using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsHoppening.Domain.Interfaces;

namespace WhatsHoppening.Providers.UserManager
{
    public class MockedUserManager : IUserManager
    {
        public Domain.User GetUser()
        {
            throw new NotImplementedException();
        }

        public Domain.User GetUser(int id)
        {
            throw new NotImplementedException();
        }

        public Domain.User GetUser(string username)
        {
            throw new NotImplementedException();
        }

        public void SaveUser(Domain.User user)
        {
            throw new NotImplementedException();
        }
    }
}
