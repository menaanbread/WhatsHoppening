using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsHoppening.Domain.Interfaces;

namespace WhatsHoppening.Providers.PermissionsManager
{
    public class MockedPermissionsManager : IPermissionsManager
    {
        public List<Domain.Permission> ListPermissions()
        {
            throw new NotImplementedException();
        }

        public bool UserHasPermission(Domain.User user)
        {
            throw new NotImplementedException();
        }
    }
}
