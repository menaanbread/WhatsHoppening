using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsHoppening.Domain.Interfaces
{
    public interface IPermissionsManager
    {
        bool UserHasPermission(User user, Permission permission);
    }
}
