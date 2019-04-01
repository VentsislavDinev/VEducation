using System.Collections.Generic;

namespace VAgency.Data.ViewModels.Blog
{
    public class CoursesDetailsViewModel
    {
        public IEnumerable<CoursesViewModel> Blog { get; set; }
        public IEnumerable<CoursesImageViewModel> BlogImage { get; set; }
    }
}