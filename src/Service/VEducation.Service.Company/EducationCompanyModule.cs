using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Service.Company
{
    using System.Reflection;

    using Abp.AutoMapper;
    using Abp.Modules;
    using VEducation.Infrastructure.Core;

    [DependsOn(typeof(EducationCoreModule), typeof(AbpAutoMapperModule))]
    public class EducationCompanyModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
