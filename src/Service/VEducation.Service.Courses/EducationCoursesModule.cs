using Abp.AutoMapper;
using Abp.Modules;
using System.Reflection;
using VEducation.Infrastructure.Core;

namespace VEducation.Service.Courses
{
    [DependsOn(typeof(EducationCoreModule), typeof(AbpAutoMapperModule))]
    public class EducationCoursesModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
