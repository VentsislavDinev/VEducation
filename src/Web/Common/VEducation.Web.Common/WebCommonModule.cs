using Abp.AutoMapper;
using Abp.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using VEducation.Infrastructure.Core;

namespace VEducation.Web.Common
{
    [DependsOn(typeof(EducationCoreModule), typeof(AbpAutoMapperModule))]
    public class WebCommonModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
