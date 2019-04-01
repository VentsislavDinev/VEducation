using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Timing;
using Abp.Zero;
using Abp.Zero.Configuration;
using System.Reflection;
using VEducation.Infrastructure.Core.Authorization;
using VEducation.Infrastructure.Core.Authorization.Roles;
using VEducation.Infrastructure.Core.MultiTenancy;
using VEducation.Infrastructure.Core.Timing;
using VEducation.Infrastructure.Core.Users;

namespace VEducation.Infrastructure.Core
{

    [DependsOn(typeof(AbpZeroCoreModule))]
    public class EducationCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            // Declare entity types
            //Configuration.Modules.Zero().EntityTypes.Tenant = typeof(Tenant);
            Configuration.Modules.Zero().EntityTypes.Role = typeof(Role);
            Configuration.Modules.Zero().EntityTypes.User = typeof(User);

            Configuration.Localization.Sources.Add(
                           new DictionaryBasedLocalizationSource(
                               EducationConsts.LocalizationSourceName,
                               new XmlEmbeddedFileLocalizationDictionaryProvider(
                                   Assembly.GetExecutingAssembly(),
                                   "VEducation.Infrastructure.Core.Localization.Source"
                                   )
                               )
                           );            // Configure roles
            AppRoleConfig.Configure(Configuration.Modules.Zero().RoleManagement);



            Configuration.Authorization.Providers.Add<EducationAuthorizationProvider>();

        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(EducationCoreModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            IocManager.Resolve<AppTimes>().StartupTime = Clock.Now;
        }
    }
}
