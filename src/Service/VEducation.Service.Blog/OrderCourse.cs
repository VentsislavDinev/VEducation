using Abp.Domain.Repositories;
using Education.Data.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using VAgency.Data.ViewModels;
using VAgency.Data.ViewModels.Blog;

namespace VEducation.Service.Courses
{
    public class OrderCourse : IOrderCourse
    {
        /// <summary>
        /// The repo
        /// </summary>
        private IRepository<Education.Data.Models.Courses> _repo;

        /// <summary>
        /// The _category.
        /// </summary>
        private IRepository<CoursesCategory> _category;

        /// <summary>
        /// The _answer.
        /// </summary>
        private IRepository<CoursesAnswer> _answer;

        /// <summary>
        /// The _blog image.
        /// </summary>
        private IRepository<CoursesImage> _blogImage;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="BlogPostService"/> class.
        /// </summary>
        /// <param name="repo">
        /// The repo.
        /// </param>
        /// <param name="blogPostCategory">
        /// The blog post category.
        /// </param>
        /// <param name="answer">
        /// The answer.
        /// </param>
        /// <param name="sanitize">
        /// The sanitize.
        /// </param>
        /// <param name="blogImage">
        /// The blog image.
        /// </param>
        public OrderCourse(IRepository<Education.Data.Models.Courses> repo, IRepository<CoursesCategory> blogPostCategory, IRepository<CoursesAnswer> answer, IRepository<CoursesImage> blogImage)
        {
            _repo = repo;
            _answer = answer;
            _category = blogPostCategory;
            _blogImage = blogImage;
        }


        /// <summary>
        /// Get blog post by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<BlogPostVieModel> GetById(int id)
        {
            return await _repo.GetAll().Where(x => x.Id == id)
                .Select(x => new BlogPostVieModel
                {
                    Category = x.CourseCategories.Name,
                    CreationTime = x.CreationTime,
                    Description = x.Description,
                    Title = x.Title,
                    UserId = x.UserId,
                    ShortContent = x.ShortContent,
                })
                .FirstOrDefaultAsync();
        }

        /// <summary>
        /// Get all blog post with descending order by creation time. 
        /// </summary>
        /// <returns></returns>
        public async Task<List<CoursesPostVieModel>> GetAll()
        {
            return await _repo.GetAll()
                .OrderByDescending(x => x.CreationTime)
                .Take(10)
                .Skip(20)
                .Select(x => new CoursesPostVieModel
                {
                    Category = x.CourseCategories.Name,
                    CreationTime = x.CreationTime,
                    Description = x.Description,
                    Title = x.Title,
                    UserId = x.UserId,
                    ShortContent = x.ShortContent,
                })
                .ToListAsync();
        }

        /// <summary>
        /// Get blog answer by blog post id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<CoursesAnswerVieModel> GetAnswerByBlogPost(int id)
        {
            return await _answer.GetAll().Where(x => x.BlogPostsId == id)
               .Select(x => new CoursesAnswerVieModel
               {
                   CreationTime = x.CreatedOn,
                   Name = x.Name,
                   User = x.UserId,
               })
               .FirstOrDefaultAsync();
        }

        public async Task<List<CoursesCategoryViewModel>> GetBlogCategory()
        {
            return await _category.GetAll()
                          .Select(x => new CoursesCategoryViewModel
                          {
                              Name = x.Name
                          })
                          .ToListAsync();
        }

        public async Task<int> GetBlogCategoryCount()
        {
            return await _category.GetAll().CountAsync();
        }

    }
}
