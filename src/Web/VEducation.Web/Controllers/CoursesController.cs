using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using VEducation.Data.ViewModels.Pages;
using VEducation.Service.Company;
using VEducation.Service.Courses;

namespace VEducation.Web.Controllers
{
    public class CoursesController : BaseController
    {
        private IOrderThinkService _think;
        private IOrderCourse _courses;
        private IOrderContact _contact;

        public CoursesController(IOrderThinkService think, IOrderCourse courses, IOrderContact contact)
        {
            _think = think ?? throw new ArgumentNullException(nameof(think));
            _courses = courses ?? throw new ArgumentNullException(nameof(courses));
            _contact = contact ?? throw new ArgumentNullException(nameof(contact));
        }

        // GET: Courses
        public async Task<ActionResult> Index()
        {
            var pageModel = new CoursePageViewModel
            {
                GetAllCourses =  await _courses.GetAll()
            };
            return View(pageModel);
        }


        public ActionResult Think()
        {
            var pageModel = new CoursePageViewModel
            {
                Think = _think.GetLast()
            };

            return PartialView(pageModel);
        }

        public ActionResult MiniContact()
        {
            var pageModel = new CoursePageViewModel
            {
                Contact = _contact.GetAll()
            };

            return PartialView(pageModel);
        }

    }
}