using Abp.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VEducation.Infrastructure.Core.Authorization.Roles;
using VEducation.Infrastructure.Core.Users;

namespace VEducation.Infrastructure.Core.Authorization
{
    /// <summary>
    /// The permission checker.
    /// </summary>
    public class PermissionCheckers : PermissionChecker<Role, User>
    {
        public PermissionCheckers(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
