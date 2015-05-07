using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsHoppening.Domain.Interfaces
{
    public interface IPermissionsManager
    {
        List<Permission> ListPermissions();
        bool UserHasPermission(User user);
    }
}
