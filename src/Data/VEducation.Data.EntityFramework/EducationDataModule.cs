using Abp.Domain.Repositories;
using Abp.Modules;
using Abp.Zero.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace VEducation.Data.EntityFramework
{
    [DependsOn(typeof(AbpZeroEntityFrameworkModule))]
    public class EducationDataModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<EducationDbContext>());
            
            Configuration.DefaultNameOrConnectionString = "DefaultConnection";
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
