using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VAgency.Data.ViewModels;
using VAgency.Data.ViewModels.Company;

namespace VEducation.Data.ViewModels.Pages
{
    public class HomePageViewModel
    {
        public List<CompanyFeedBackCompanyViewModel> Feedback { get; set; }
        public List<CompanyContactViewModel> Contact { get; set; }
        public List<AboutViewModel> About { get; set; }
        public List<CompanyInformationViewModel> Service { get; set; }
        public List<TeamViewModel> Team { get; set; }
        public List<ThinkViewModel> Think { get; set; }
        public List<GalleryViewModel> Gallery { get; set; }
        public List<FeatureViewModel> Feature { get; set; }
        public CompanyMessageCreateViewModel CompanyMessage { get; set; }
        public ApplySingleViewModel Apply { get; set; }
    }
}
