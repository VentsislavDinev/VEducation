﻿using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VEducation.Service.Roles.Dto;

namespace VEducation.Service.Roles
{

    /// <summary>
    /// The RoleAppService interface.
    /// </summary>
    public interface IRoleAppService : IApplicationService
    {
        /// <summary>
        /// The update role permissions.
        /// </summary>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task UpdateRolePermissions(UpdateRolePermissionsInput input);
    }
}
