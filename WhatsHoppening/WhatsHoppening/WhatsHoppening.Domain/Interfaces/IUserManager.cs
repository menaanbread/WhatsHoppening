using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsHoppening.Domain.Interfaces
{
    public interface IUserManager
    {
        User GetUser();
        User GetUser(int id);
        User GetUser(string username);
        void SaveUser(User user);
    }
}
