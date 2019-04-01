
using Abp.Application.Navigation;
using Abp.Threading;
using Education.Service.User;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using VAgency.Data.ViewModels;
using VEducation.Service.Sessions;
using VEducation.Service.Sessions.Dto;
using VEducation.Web.Common.Populator;
using VEducation.Web.Controllers;

namespace VEducation.Web.Areas.Administration.Controllers
{
    public class CourseController : BaseController
    {
        private readonly ICoursesService _courses;
        private IDropDownListPopulator _populator;

        private const string imagePath = "/Files/uploads";
        private string saveMediumImageLocation;

        public GetCurrentLoginInformationsOutput LoginInformations { get; set; }
        private ISessionAppService _sessionAppService;
        public CourseController(ICoursesService courses, IDropDownListPopulator populator, ISessionAppService sessionAppService)
        {
   
            _courses = courses ?? throw new ArgumentNullException(nameof(courses));
            _sessionAppService = sessionAppService ?? throw new ArgumentNullException(nameof(sessionAppService));
            _populator = populator ?? throw new ArgumentNullException(nameof(populator));
            LoginInformations = AsyncHelper.RunSync(() => _sessionAppService.GetCurrentLoginInformations());
        }

        [HttpGet]
        public ActionResult Create()
        {
            
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(CoursesPostVieModel model)
        {
            WebImage file = new WebImage(model.Upload.InputStream);

            string fileExtention = file.ImageFormat;

            //creating filename to avoid file name conflicts.
            string fileName = Guid.NewGuid().ToString();

            string curretnDirectory = Path.GetFullPath(Server.MapPath(imagePath));

            saveMediumImageLocation = curretnDirectory;

            string fileNameWithExtension = fileName + "." + fileExtention;
            var saveFile = saveMediumImageLocation + "/" + fileNameWithExtension;
            file.Save(saveFile, fileExtention);

            await _courses.Create(model.Title, model.ShortContent, model.Description, DateTime.Now, LoginInformations.User.UserName, 1, fileNameWithExtension);
            return Redirect("/");
        }

        public ActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CreateCategory(CoursesCategoryViewModel model)
        {
            await _courses.CreateCategory(model.Name);
            return Redirect("/");
        }

        // GET: Administration/Courses
        public ActionResult Index()
        {
            return View();
        }
    }
}