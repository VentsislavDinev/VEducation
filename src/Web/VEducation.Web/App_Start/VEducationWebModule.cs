using Abp.Hangfire;
using Abp.Localization;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Modules;
using Abp.Web.Mvc;
using Abp.Web.Mvc.Configuration;
using Abp.Web.SignalR;
using Education.Service.Company;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using VEducation.Data.EntityFramework;
using VEducation.Service;
using VEducation.Service.Blog;
using VEducation.Service.Courses;
using VEducation.Web.Common;
using VEducationWebApi;

namespace VEducation.Web.App_Start
{
    [DependsOn(
        typeof(EducationDataModule),
        typeof(EducationServiceCoreModule),
        typeof(EducationCompanyModule),
        typeof(EducationCoursesModule),
        typeof(EducationBlogModule),

        typeof(WebCommonModule),
        typeof(EducationWebApiModule),
        typeof(AbpWebMvcModule),
        typeof(AbpWebSignalRModule), //Add AbpWebSignalRModule dependency
        typeof(AbpHangfireModule)
        )]
    public class EducationWebModule : AbpModule
    {
        public override void PreInitialize()
        {
            //Enable database based localization
            //Configuration.Modules.Zero().LanguageManagement.EnableDbLocalization();
            Configuration.Localization.Languages.Add(new LanguageInfo("en", "English", "famfamfam-flag-england", true));
            Configuration.Localization.Languages.Add(new LanguageInfo("tr", "Türkçe", "famfamfam-flag-tr"));
            Configuration.Localization.Languages.Add(new LanguageInfo("zh-CN", "简体中文", "famfamfam-flag-cn"));
            Configuration.Modules.AbpMvc().IsValidationEnabledForControllers = false;

            Configuration.Localization.Sources.Add(
          new DictionaryBasedLocalizationSource(
              "EducationLocalization",
              new XmlFileLocalizationDictionaryProvider(
                  HttpContext.Current.Server.MapPath("~/Localization/Source")
                  )
              )
          );

            //Configure navigation/menu
            Configuration.Navigation.Providers.Add<VEducationNavigationProvider>();
            Configuration.Navigation.Providers.Add<VEducationSocialNavigationProvider>();

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false; //Can disable job manager to not process jobs.

            //Configuration.BackgroundJobs.UseHangfire(
            //    configuration => //Configure to use hangfire for background jobs.
            //        {
            //            configuration.GlobalConfiguration.UseSqlServerStorage("Default"); //Set database connection
            //        });

            // var lang = IocManager.Resolve<ILanguageManager>().CurrentLanguage;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}