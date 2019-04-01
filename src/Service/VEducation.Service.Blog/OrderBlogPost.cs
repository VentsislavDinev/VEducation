using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Abp.ObjectMapping;
using Education.Data.Models;
using Education.Service.Blog;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VAgency.Data.ViewModels;

namespace VEducation.Service.Blog
{
    public class OrderBlogPost : BlogServiceBase, IOrderBlogPost
    {
        /// <summary>
        /// The repo
        /// </summary>
        private IRepository<BlogPost> _repo;

        /// <summary>
        /// The _category.
        /// </summary>
        private IRepository<BlogPostCategory> _category;

        /// <summary>
        /// The _answer.
        /// </summary>
        private IRepository<BlogPostAnswer> _answer;
        
        /// <summary>
        /// The _blog image.
        /// </summary>
        private IRepository<BlogImages> _blogImage;

        public OrderBlogPost(IRepository<BlogPost> repo, IRepository<BlogPostCategory> category, IRepository<BlogPostAnswer> answer, IRepository<BlogImages> blogImage)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
            _category = category ?? throw new ArgumentNullException(nameof(category));
            _answer = answer ?? throw new ArgumentNullException(nameof(answer));
            _blogImage = blogImage ?? throw new ArgumentNullException(nameof(blogImage));
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
                    Category = x.BlogPostCategories.Name,
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
        public async Task<List<BlogPostVieModel>> GetAll()
        {
            return await _repo.GetAll()
                .OrderByDescending(x=>x.CreationTime)
                .Take(10)
                .Skip(20)
                .Select(x => new BlogPostVieModel
                {
                    Category = x.BlogPostCategories.Name,
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
        public async Task<BlogPostAnswerVieModel> GetAnswerByBlogPost(int id)
        {
            return await _answer.GetAll().Where(x => x.BlogPostsId == id)
               .Select(x => new BlogPostAnswerVieModel
               {
                    CreationTime = x.CreationTime,
                    Name = x.Name,
                    User = x.UserId,
               })
               .FirstOrDefaultAsync();
        }

        public async Task<List<BlogPostCategoryViewModel>> GetBlogCategory()
        {
            return await _category.GetAll()
                          .Select(x => new BlogPostCategoryViewModel
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
