using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VAgency.Data.ViewModels;

namespace VEducation.Data.ViewModels.Pages
{
    public class EventPageViewModel
    {
        public List<ThinkViewModel> Think { get; set; }
        public List<CompanyContactViewModel> Contact { get; set; }
        public List<BlogPostVieModel> GetAllCourses { get; set; }
    }
}
