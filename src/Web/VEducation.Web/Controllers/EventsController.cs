using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using VEducation.Data.ViewModels.Pages;
using VEducation.Service.Blog;
using VEducation.Service.Company;

namespace VEducation.Web.Controllers
{
    public class EventsController : BaseController
    {
        private IOrderThinkService _think;
        private IOrderBlogPost _courses;
        private IOrderContact _contact;

        public EventsController(IOrderThinkService think, IOrderBlogPost courses, IOrderContact contact)
        {
            _think = think ?? throw new ArgumentNullException(nameof(think));
            _courses = courses ?? throw new ArgumentNullException(nameof(courses));
            _contact = contact ?? throw new ArgumentNullException(nameof(contact));
        }
        
        // GET: Events
        public async Task<ActionResult> Index()
        {
            var pageModel = new EventPageViewModel
            {
                GetAllCourses = await _courses.GetAll()
            };
            return View(pageModel);
        }


        public ActionResult Think()
        {
            var pageModel = new EventPageViewModel
            {
                Think = _think.GetLast()
            };

            return PartialView(pageModel);
        }

        public ActionResult MiniContact()
        {
            var pageModel = new EventPageViewModel
            {
                Contact = _contact.GetAll()
            };

            return PartialView(pageModel);
        }
    }
}