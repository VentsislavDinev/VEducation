using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using VEducation.Data.ViewModels;
using VEducation.Data.ViewModels.Pages;
using VEducation.Service.Company;

namespace VEducation.Web.Controllers
{
    public class HomeController : BaseController
    {
        private IOrderAbout _about;
        private IMessageCompany _message;
        private IOrderService _service;
        private IOrderPage _page;
        private IOrderFeedback _feedbackCompany;
        private IOrderContact _contact;
        private IOrderThinkService _think;
        private IOrderTeamService _team;
        private IApplyService _apply;
        private IOrderGalleryService _gallery;
        private IOrderFeatureService _feature;

        public HomeController(IOrderAbout about, IMessageCompany message, IOrderService service, IOrderPage page, IOrderFeedback feedbackCompany, IOrderContact contact, IOrderThinkService think, IOrderTeamService team, IApplyService apply, IOrderGalleryService gallery, IOrderFeatureService feature)
        {
            _about = about ?? throw new ArgumentNullException(nameof(about));
            _message = message ?? throw new ArgumentNullException(nameof(message));
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _page = page ?? throw new ArgumentNullException(nameof(page));
            _feedbackCompany = feedbackCompany ?? throw new ArgumentNullException(nameof(feedbackCompany));
            _contact = contact ?? throw new ArgumentNullException(nameof(contact));
            _think = think ?? throw new ArgumentNullException(nameof(think));
            _team = team ?? throw new ArgumentNullException(nameof(team));
            _apply = apply ?? throw new ArgumentNullException(nameof(apply));
            _gallery = gallery ?? throw new ArgumentNullException(nameof(gallery));
            _feature = feature ?? throw new ArgumentNullException(nameof(feature));
        }

        public ActionResult Index()
        {
            return View();
        }

        public  ActionResult About()
        {
            var pageModel = new HomePageViewModel
            {
                About = _about.GetLast()
            };

            return View(pageModel);
        }
        
        public ActionResult Message()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<ActionResult> Message(HomePageViewModel model)
        {
            await  _message.Create(model.CompanyMessage.FirstName, model.CompanyMessage.Description, model.CompanyMessage.LastName, model.CompanyMessage.Phone, model.CompanyMessage.Title, model.CompanyMessage.Email, DateTime.Now);
            return Redirect("/");
        }

        public async Task<ActionResult> Contact()
        {
            var pageModel = new HomePageViewModel
            {
                Contact = await _contact.GetAllAsync()
            };

            return View(pageModel);
        }

        [ChildActionOnly]
        public ActionResult Service()
        {
            var pageModel = new HomePageViewModel
            {
                Service = _service.GetAll()
            };

            return PartialView(pageModel);
        }

        [ChildActionOnly]
        public ActionResult Featured()
        {
            var pageModel = new HomePageViewModel
            {
                Feature = _feature.GetAll()
            };

            return PartialView(pageModel);
        }

        [ChildActionOnly]
        public ActionResult HandCraft()
        {
            var pageModel = new HomePageViewModel
            {
                About = _about.GetLast()
            };

            return PartialView(pageModel);
        }

        public ActionResult Think()
        {
            var pageModel = new HomePageViewModel
            {
                Think = _think.GetLast()
            };

            return PartialView(pageModel);
        }

        [ChildActionOnly]
        public ActionResult Stats()
        {
            return PartialView();
        }

        [ChildActionOnly]
        public ActionResult Apply()
        {
            
            return PartialView();
        }

        [HttpPost]
        public async Task<ActionResult> Apply(HomePageViewModel model)
        {
            await _apply.Create(model.Apply.Email, model.Apply.Description, model.Apply.FirstName, model.Apply.LastName, model.Apply.PhoneNumber, DateTime.Now);
            return Redirect("/");
        }

        [ChildActionOnly]
        public ActionResult BannerBottom()
        {
            return PartialView();
        }
        

        [ChildActionOnly]
        public ActionResult Team()
        {

            var pageModel = new HomePageViewModel
            {
                Team = _team.GetAll()
            };
            return PartialView(pageModel);
        }

        [ChildActionOnly]
        public ActionResult Gallery()
        {
            var pageModel = new HomePageViewModel
            {
                Gallery = _gallery.GetAll()
            };
            return PartialView(pageModel);
        }

        [ChildActionOnly]
        public ActionResult Feedback()
        {
            var pageModel = new HomePageViewModel
            {
                Feedback = _feedbackCompany.GetAll()
            };

            return PartialView(pageModel);
        }

        public ActionResult MiniContact()
        {
            var pageModel = new HomePageViewModel
            {
                Contact = _contact.GetAll()
            };

            return PartialView(pageModel);
        }

        [ChildActionOnly]
        public ActionResult LastBlog()
        {
            return PartialView();
        }
    }
}