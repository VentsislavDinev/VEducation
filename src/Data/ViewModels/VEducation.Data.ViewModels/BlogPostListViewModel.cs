using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using VAgency.Data.ViewModels.Company;

namespace VAgency.Data.ViewModels.Blog
{
    public class BlogPostListViewModel
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }

        //public int MaxPage { get; set; }
        //public int PreviosPage { get; set; }
        public IEnumerable<BlogPostVieModel> BlogPost { get; set; }

        public IEnumerable<StaticPageViewModel> Page { get; set; }
        public CompanyContactViewModel Contact { get; set; }
        public List<StaticPageViewModel> StaticPage { get; set; }
        public BlogPostCreateViewModel BlogPosts { get; set; }
        public IEnumerable<BlogPostImageViewModel> GetImage { get; set; }
        public IQueryable<BlogPostVieModel> Blog { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
        public SEOToolViewModel Seo { get; set; }

        public IEnumerable<string> GetAllCategory { get; set; }
    }
}