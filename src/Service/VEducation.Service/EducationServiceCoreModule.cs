using Abp.AutoMapper;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Modules;
using Abp.Threading.BackgroundWorkers;
using Abp.Zero.Configuration;
using System.Reflection;
using VEducation.Infrastructure.Core;
using VEducation.Infrastructure.Core.Authorization.Roles;
using VEducation.Service.Users;

namespace VEducation.Service
{
    [DependsOn(typeof(EducationCoreModule), typeof(AbpAutoMapperModule))]
    public class EducationServiceCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            //Remove the following line to disable multi-tenancy.
            Configuration.MultiTenancy.IsEnabled = false;

            //Add/remove localization sources here
            //Configuration.Localization.Sources.Add(
            //    new DictionaryBasedLocalizationSource(
            //        EducationConsts.LocalizationSourceName,
            //        new XmlEmbeddedFileLocalizationDictionaryProvider(
            //            Assembly.GetExecutingAssembly(),
            //            "Education.Localization.Source"
            //        )
            //    )
            //);
            AppRoleConfig.Configure(Configuration.Modules.Zero().RoleManagement);

            //Configuration.Authorization.Providers.Add<EducationAuthorizationProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }

        public override void PostInitialize()
        {
            var workManager = IocManager.Resolve<IBackgroundWorkerManager>();
            workManager.Add(IocManager.Resolve<MakeInactiveUsersPassiveWorker>());
        }
    }
}
