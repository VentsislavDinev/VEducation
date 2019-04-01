using Abp.Threading;
using Education.Service.User;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Web.Helpers;
using System.Web.Mvc;
using VAgency.Data.ViewModels;
using VEducation.Service.Sessions;
using VEducation.Service.Sessions.Dto;
using VEducation.Web.Common.Populator;
using VEducation.Web.Controllers;

namespace VEducation.Web.Areas.Administration.Controllers
{
    public class BlogController : BaseController
    {
        private IBlogPost _blogPost;
        public GetCurrentLoginInformationsOutput LoginInformations { get; set; }
        private ISessionAppService _sessionAppService;

        private readonly IDropDownListPopulator _populator;
        private readonly string imagePath = "/Files/Blog";
        private string saveMediumImageLocation;
        public BlogController(IBlogPost blogPost, ISessionAppService sessionAppService, IDropDownListPopulator populator)
        {
            _blogPost = blogPost ?? throw new ArgumentNullException(nameof(blogPost));
            _sessionAppService = sessionAppService ?? throw new ArgumentNullException(nameof(sessionAppService));
            _populator = populator ?? throw new ArgumentNullException(nameof(populator));
            LoginInformations = AsyncHelper.RunSync(() => _sessionAppService.GetCurrentLoginInformations());
        }

        [HttpPost]
        public async Task<ActionResult> Create(BlogPostVieModel model)
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
            await _blogPost.Create(model.Title, model.ShortContent, model.Description, DateTime.Now, LoginInformations.User.UserName, model.CategoryId, fileNameWithExtension);
            return Redirect("/");
        }

        [HttpGet]
        public ActionResult Create()
        {
            BlogPostVieModel category = new BlogPostVieModel
            {
                Categories = _populator.GetBlogCategories()
            };
            return View(category);
        }

        public ActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CreateCategory(BlogPostCategoryViewModel model)
        {

            await _blogPost.CreateCategory(model.Name);
            return Redirect("/");
        }

        // GET: Administration/Blog
        public ActionResult Index()
        {
            return View();
        }
    }
}