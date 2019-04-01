namespace VEducation.Data.EntityFramework.Migrations
{
    using Abp.MultiTenancy;
    using global::EntityFramework.DynamicFilters;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using VEducation.Data.EntityFramework.Migrations.SeedData;

    internal sealed class Configuration : DbMigrationsConfiguration<VEducation.Data.EntityFramework.EducationDbContext>
    {
        public AbpTenantBase Tenant { get; set; }

        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(VEducation.Data.EntityFramework.EducationDbContext context)
        {
            context.DisableAllFilters();

            if (Tenant == null)
            {
                //Host seed
                new InitialHostDbBuilder(context).Create();

                //Default tenant seed (in host database).
                new DefaultTenantCreator(context).Create();
                new TenantRoleAndUserBuilder(context, 1).Create();
            }
            else
            {
                //You can add seed for tenant databases and use Tenant property...
            }

            context.SaveChanges();
        }
    }
}
