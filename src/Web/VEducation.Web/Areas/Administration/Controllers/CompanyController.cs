using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using VAgency.Data.ViewModels;
using VEducation.Data.ViewModels;
using VEducation.Service.Company;
using VEducation.Web.Controllers;

namespace VEducation.Web.Areas.Administration.Controllers
{
    public class CompanyController : BaseController
    {
        private IAbout _about;
        private IMessageCompany _message;
        private IService _service;
        private IFeedBackCompany _feedbackCompany;
        private IContact _contact;

        public CompanyController(IAbout about, IMessageCompany message, IService service, IFeedBackCompany feedbackCompany, IContact contact)
        {
            _about = about ?? throw new ArgumentNullException(nameof(about));
            _message = message ?? throw new ArgumentNullException(nameof(message));
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _feedbackCompany = feedbackCompany ?? throw new ArgumentNullException(nameof(feedbackCompany));
            _contact = contact ?? throw new ArgumentNullException(nameof(contact));
        }


        [HttpPost]
        public async Task<ActionResult> CreateFeedback(CompanyFeedBackClientViewModel model)
        {
            await  _feedbackCompany.Create(model.Name, model.Description, "image", DateTime.Now);
            return Redirect("/");
        }
        [HttpPost]
        public async Task<ActionResult> CreateAbout(AboutViewModel model)
        {
            await _about.Create(model.Name, model.Description, DateTime.Now);
            return Redirect("/");
        }
        [HttpPost]
        public async Task<ActionResult> CreateService(ServiceViewModel model)
        {
            await _service.Create(model.Description, model.Name, DateTime.Now, "Administrator");
            return Redirect("/");
        }
        [HttpPost]
        public async Task<ActionResult> CreateContact(CompanyContactViewModel model)
        {
            await _contact.Create(model.OfficeAddress, model.Phonenumber, model.WorkFrom, model.WorkTo, DateTime.Now, model.Address, model.City);
            return Redirect("/");
        }


  
        [HttpGet]

        public ActionResult CreateFeedback()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CreateAbout()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CreateService()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CreateContact()
        {
            return View();
        }

        // GET: Administration/Company
        public ActionResult Index()
        {
            return View();
        }
    }
}