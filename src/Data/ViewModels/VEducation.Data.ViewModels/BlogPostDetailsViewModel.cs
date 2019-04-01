using System.Collections.Generic;

namespace VAgency.Data.ViewModels.Blog
{
    public class BlogPostDetailsViewModel
    {
        public IEnumerable<BlogPostVieModel> Blog { get; set; }
        public IEnumerable<BlogPostImageViewModel> BlogImage { get; set; }
    }
}