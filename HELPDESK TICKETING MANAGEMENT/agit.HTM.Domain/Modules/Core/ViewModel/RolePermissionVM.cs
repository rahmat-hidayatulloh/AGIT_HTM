using agit.HTM.Domain.Modules.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agit.HTM.Domain.Modules.Core.ViewModel
{
    internal class RolePermissionVM
    {
        public IEnumerable<Permission> Permissions { get; set; }
        public IEnumerable<RolePermission> RolePermissions { get; set; }
    }
}
