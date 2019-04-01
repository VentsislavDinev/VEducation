using Abp.Application.Services;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using VEducation.Data.EntityFramework;

namespace VEducation.Web.Common.Populator
{
    public class DropDownListPopulator : ApplicationService, IDropDownListPopulator
    {
        private EducationDbContext _blog;
       
        public EducationDbContext Blog { get => _blog; set => _blog = value; }

        public DropDownListPopulator(EducationDbContext data)
        {
            Blog = data ?? throw new System.ArgumentNullException(nameof(data));
        }

        public IEnumerable<SelectListItem> GetBlogCategories()
        {

            return Blog.BlogPostCategories
               .Select(c => new SelectListItem
               {
                   Value = c.Id.ToString(),
                   Text = c.Name
               })
               .ToList();
        }

        public IEnumerable<SelectListItem> GetCoursesCategories()
        {

            return Blog.CoursesCategories
               .Select(c => new SelectListItem
               {
                   Value = c.Id.ToString(),
                   Text = c.Name
               })
               .ToList();

        }
    }
}
