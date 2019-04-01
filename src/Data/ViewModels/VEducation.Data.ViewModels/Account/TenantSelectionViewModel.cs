using Abp.AutoMapper;
using System.Collections.Generic;
using VEducation.Infrastructure.Core.MultiTenancy;

namespace VEducation.Data.ViewModels.Account
{
    public class TenantSelectionViewModel
    {
        public string Action { get; set; }

        public List<TenantInfo> Tenants { get; set; }

        [AutoMapFrom(typeof(Tenant))]
        public class TenantInfo
        {
            public int Id { get; set; }

            public string TenancyName { get; set; }

            public string Name { get; set; }
        }
    }
}
