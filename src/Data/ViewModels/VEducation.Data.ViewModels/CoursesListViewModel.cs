using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using VAgency.Data.ViewModels.Company;

namespace VAgency.Data.ViewModels.Blog
{
    public class CoursestListViewModel
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }

        //public int MaxPage { get; set; }
        //public int PreviosPage { get; set; }
        public IEnumerable<CoursesViewModel> BlogPost { get; set; }

        public IEnumerable<StaticPageViewModel> Page { get; set; }
        public CompanyContactViewModel Contact { get; set; }
        public List<StaticPageViewModel> StaticPage { get; set; }
        public CoursesCreateViewModel BlogPosts { get; set; }
        public IEnumerable<CoursesImageViewModel> GetImage { get; set; }
        public IQueryable<CoursesViewModel> Blog { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
        public SEOToolViewModel Seo { get; set; }

        public IEnumerable<string> GetAllCategory { get; set; }
    }
}