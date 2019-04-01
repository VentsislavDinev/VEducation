using System.Collections.Generic;
using System.Web.Mvc;
using Abp.Application.Services;
using VEducation.Data.EntityFramework;

namespace VEducation.Web.Common.Populator
{
    public interface IDropDownListPopulator : IApplicationService
    {
        IEnumerable<SelectListItem> GetBlogCategories();
        IEnumerable<SelectListItem> GetCoursesCategories();
    }
}