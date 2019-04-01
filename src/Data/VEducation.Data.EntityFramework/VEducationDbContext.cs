using Abp.Zero.EntityFramework;
using Education.Data.Models;
using Education.Data.Models.Company;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VEducation.Data.Model;
using VEducation.Infrastructure.Core.Authorization.Roles;
using VEducation.Infrastructure.Core.MultiTenancy;
using VEducation.Infrastructure.Core.Users;

namespace VEducation.Data.EntityFramework
{
    /// <summary>
    /// The education db context.
    /// </summary>

    public class EducationDbContext : AbpZeroDbContext<Tenant, Role, User>
    {

        public virtual IDbSet<Think> Thinks { get; set; }
        public virtual IDbSet<TeamSocialLink> TeamSocialLinks { get; set; }
        public virtual IDbSet<Team> Teams { get; set; }
        public virtual IDbSet<Apply> Applies { get; set; }
        public virtual IDbSet<Gallery> Galleries { get; set; }
        public virtual IDbSet<Feature> Features { get; set; }

        /// <summary>
        /// Gets or sets the blog images.
        /// </summary>
        public DbSet<BlogImages> BlogImages { get; set; }

        /// <summary>
        /// Gets or sets the blog posts.
        /// </summary>
        public DbSet<BlogPost> BlogPosts { get; set; }

        /// <summary>
        /// Gets or sets the blog post answers.
        /// </summary>
        public DbSet<BlogPostAnswer> BlogPostAnswers { get; set; }

        /// <summary>
        /// Gets or sets the blog post categories.
        /// </summary>
        public DbSet<BlogPostCategory> BlogPostCategories { get; set; }

        /// <summary>
        /// Gets or sets the blog post sub categories.
        /// </summary>
        public DbSet<BlogPostSubCategory> BlogPostSubCategories { get; set; }

        /// <summary>
        /// Gets or sets the blog post votes.
        /// </summary>
        public DbSet<BlogPostVote> BlogPostVotes { get; set; }


        /// <summary>
        /// Gets or sets the blog images.
        /// </summary>
        public virtual IDbSet<CoursesImage> CoursesImages { get; set; }

        /// <summary>
        /// Gets or sets the blog posts.
        /// </summary>
        public virtual IDbSet<Courses> CoursesPosts { get; set; }

        /// <summary>
        /// Gets or sets the blog post answers.
        /// </summary>
        public virtual IDbSet<CoursesAnswer> CoursesAnswers { get; set; }

        /// <summary>
        /// Gets or sets the blog post categories.
        /// </summary>
        public virtual IDbSet<CoursesCategory> CoursesCategories { get; set; }

        /// <summary>
        /// Gets or sets the blog post sub categories.
        /// </summary>
        public virtual IDbSet<CoursesSubCategory> CoursesSubCategories { get; set; }

        /// <summary>
        /// Gets or sets the blog post votes.
        /// </summary>
        public virtual IDbSet<CoursesVote> CoursesVotes { get; set; }


        /// <summary>
        /// Gets or sets the company image.
        /// </summary>
        public DbSet<CompanyImage> CompanyImage { get; set; }

        /// <summary>
        /// Gets or sets the company contacts.
        /// </summary>
        public DbSet<CompanyContact> CompanyContacts { get; set; }

        /// <summary>
        /// Gets or sets the company feed back clients.
        /// </summary>
        public DbSet<CompanyFeedBackClient> CompanyFeedBackClients { get; set; }

        /// <summary>
        /// Gets or sets the company feed back companies.
        /// </summary>
        public DbSet<CompanyFeedBackCompany> CompanyFeedBackCompanies { get; set; }

        /// <summary>
        /// Gets or sets the company informations.
        /// </summary>
        public DbSet<CompanyInformation> CompanyInformations { get; set; }

        /// <summary>
        /// Gets or sets the company logos.
        /// </summary>
        public DbSet<CompanyLogo> CompanyLogos { get; set; }

        /// <summary>
        /// Gets or sets the company messages.
        /// </summary>
        public DbSet<CompanyMessage> CompanyMessages { get; set; }

        /// <summary>
        /// Gets or sets the static page urls.
        /// </summary>
        public DbSet<StaticPageURL> StaticPageUrls { get; set; }

        /// <summary>
        /// Gets or sets the static page url images.
        /// </summary>
        public DbSet<StaticPageUrlImage> StaticPageUrlImages { get; set; }

        /// <summary>
        /// Gets or sets the static pages.
        /// </summary>
        public DbSet<StaticPage> StaticPages { get; set; }

        /// <summary>
        /// Gets or sets the abouts.
        /// </summary>
        public DbSet<About> Abouts { get; set; }

        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public EducationDbContext()
            : base("DefaultConnection")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EducationDbContext"/> class.
        ///  This constructor is used by ABP to pass connection string defined in InterceptionDemoDataModule.PreInitialize.
        /// Notice that, actually you will not directly create an instance of InterceptionDemoDbContext since ABP automatically handles it.
        /// </summary>
        /// <param name="nameOrConnectionString">
        /// The name or connection string.
        /// </param>
        public EducationDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }

        //This constructor is used in tests
        public EducationDbContext(DbConnection connection)
            : base(connection, true)
        {
        }
    }
}
