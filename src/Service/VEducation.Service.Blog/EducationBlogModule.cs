using Abp.AutoMapper;
using Abp.Modules;
using System.Reflection;
using VEducation.Infrastructure.Core;

namespace VEducation.Service.Blog
{
    [DependsOn(typeof(EducationCoreModule), typeof(AbpAutoMapperModule))]
    public class EducationBlogModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
