using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsHoppening.Domain.Interfaces;
using WhatsHoppening.Domain;

namespace WhatsHoppening.Providers.PermissionsManager
{
    public class MockedPermissionsManager : IPermissionsManager
    {
        public bool UserHasPermission(User user, Permission permission)
        {
            if (user.AccountType >= permission)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
