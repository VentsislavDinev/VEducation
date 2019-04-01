namespace Education.Service.User
{

    using Abp.Domain.Repositories;
    using Education.Data.Models;
    using Education.Web.Common.Crypto;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Education.Service.Blog;

    /// <summary>
    /// The blog post service.
    /// </summary>
    public class BlogPostService : BlogServiceBase, IBlogPost
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

        /// <summary>
        /// The _sanitize.
        /// </summary>
        private ISanitizer _sanitize = new HtmlSanitizerAdapter();

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
        public BlogPostService(IRepository<BlogPost> repo, IRepository<BlogPostCategory> blogPostCategory, IRepository<BlogPostAnswer> answer, IRepository<BlogImages> blogImage)
        {
            _repo = repo;
            _answer = answer;
            _category = blogPostCategory;
            _blogImage = blogImage;
        }

        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="title">
        /// The title.
        /// </param>
        /// <param name="shortContent">
        /// The short content.
        /// </param>
        /// <param name="desc">
        /// The desc.
        /// </param>
        /// <param name="createdOn">
        /// The created on.
        /// </param>
        /// <param name="userId">
        /// The user id.
        /// </param>
        /// <param name="categoryId">
        /// The category id.
        /// </param>
        /// <param name="filePath">
        /// The file path.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public async Task<BlogPost> Create(string title, string shortContent, string desc, DateTime createdOn, string userId, int categoryId, string filePath)
        {
            BlogPost createBlogPost = new BlogPost
            {
                Title = title,
                CreationTime = createdOn,
                UserId = userId,
                ShortContent = shortContent,
                Description = _sanitize.Sanitize(desc),
                BlogPostCategoriesId = categoryId,
            };

            if (filePath != null)
            {
                BlogImages avatar = new BlogImages
                {
                    FileName = filePath,
                };

                await _blogImage.InsertAsync(avatar).ConfigureAwait(false);
            }

            await _repo.InsertAsync(createBlogPost).ConfigureAwait(false);
            return createBlogPost;
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="title">
        /// The title.
        /// </param>
        /// <param name="createdOn">
        /// The created on.
        /// </param>
        /// <param name="shortContent">
        /// The short content.
        /// </param>
        /// <param name="userId">
        /// The user id.
        /// </param>
        /// <param name="desc">
        /// The desc.
        /// </param>
        /// <param name="categoryId">
        /// The category id.
        /// </param>
        /// <param name="filePath">
        /// The file path.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public async Task<BlogPost> Update(int id, string title, DateTime createdOn, string shortContent, string userId, string desc, int categoryId, string filePath)
        {
            BlogPost createBlogPost = new BlogPost
            {
                Title = title,
                CreationTime = createdOn,
                UserId = userId,
                ShortContent = shortContent,
                Description = _sanitize.Sanitize(desc),

                BlogPostCategoriesId = categoryId,
                PreserveCreatedOn = true
            };

            BlogImages avatar = new BlogImages
            {
                FileName = filePath,
            };

            await _repo.InsertAsync(createBlogPost).ConfigureAwait(false);

            return createBlogPost;
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="deletedOn">
        /// The deleted on.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public async Task<BlogPost> Delete(int id, DateTime deletedOn)
        {
            BlogPost createBlogPost = new BlogPost
            {
                IsDeleted = true,
                DeletedOn = deletedOn
            };


            foreach (int item in createBlogPost.BlogPostAnswer.Select(x => x.Id).ToList())
            {
                await _answer.DeleteAsync(item).ConfigureAwait(true);
            }
            

            foreach (int blogImage in createBlogPost.BlogImage.Select(x => x.Id).ToList())
            {
               await this._blogImage.DeleteAsync(blogImage).ConfigureAwait(true);
            }
            
            return createBlogPost;
        }

        public IEnumerable<BlogImages> GetImageByBlogId(int id)
        {
            var getBlog = _blogImage.GetAll().Where(x => x.PersonId == id);
            return getBlog;
        }

        public IEnumerable<BlogImages> GetAllImage()
        {
            var image = _blogImage.GetAll();
            return image;
        }

        /// <summary>
        /// The create answer.
        /// </summary>
        /// <param name="creationTime">
        /// The creation time.
        /// </param>
        /// <param name="userId">
        /// The user id.
        /// </param>
        /// <param name="comment">
        /// The comment.
        /// </param>
        /// <param name="postId">
        /// The post id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public async Task<BlogPostAnswer> CreateAnswer(DateTime creationTime, string userId, string comment, int postId)
        {
            BlogPostAnswer newAnswer = new BlogPostAnswer
            {
                CreationTime = creationTime,
                UserId = userId,
                Name = comment,
                BlogPostsId = postId,
            };

            await this._answer.InsertAsync(newAnswer).ConfigureAwait(true);

            return newAnswer;
        }

        /// <summary>
        /// The update answer.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="creationTime">
        /// The creation time.
        /// </param>
        /// <param name="userId">
        /// The user id.
        /// </param>
        /// <param name="comment">
        /// The comment.
        /// </param>
        /// <param name="postId">
        /// The post id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public async Task<BlogPostAnswer> UpdateAnswer(int id, DateTime creationTime, string userId, string comment, int postId)
        {
            BlogPostAnswer updateAnswer = new BlogPostAnswer
            {
                CreationTime = creationTime,
                UserId = userId,
                Name = comment,
                BlogPostsId = postId,
            };

            updateAnswer.PreserveCreatedOn = true;
           
            await this._answer.UpdateAsync(updateAnswer).ConfigureAwait(true);
           
            return updateAnswer;
        }

        /// <summary>
        /// The delete answer.
        /// </summary>
        /// <param name="creationTime">
        /// The creation time.
        /// </param>
        /// <param name="postId">
        /// The post id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public async Task<BlogPostAnswer> DeleteAnswer(DateTime creationTime, int postId)
        {
            BlogPostAnswer deleteComment = new BlogPostAnswer
            {
                DeletedOn = creationTime,
                IsDeleted = true
            };
            
            await this._answer.DeleteAsync(deleteComment).ConfigureAwait(true);
           
            return deleteComment;
        }

        public IEnumerable<BlogPostAnswer> GetAllAnswer(string title)
        {
            var getAnswer = _answer.GetAll().Where(x => x.BlogPosts.Title == title);
            return getAnswer;
        }

        public async Task<BlogPostCategory> CreateCategory(string name)
        {
            BlogPostCategory newCategory = new BlogPostCategory
            {
                Name = name,
            };

            await this._category.InsertAsync(newCategory).ConfigureAwait(true);
           
            return newCategory;
        }

        /// <summary>
        /// The update category.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public async Task<BlogPostCategory> UpdateCategory(int id, string name)
        {
            BlogPostCategory newCategory = new BlogPostCategory
            {
                Name = name,
            };

            newCategory.PreserveCreatedOn = true;
           
            await this._category.UpdateAsync(newCategory).ConfigureAwait(true);
          
            return newCategory;
        }

        /// <summary>
        /// The delete category.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="deletedOn">
        /// The deleted on.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public async Task<BlogPostCategory> DeleteCategory(int id, DateTime deletedOn)
        {
            BlogPostCategory newCategory = new BlogPostCategory
            {
                IsDeleted = true,
                DeletedOn = deletedOn
            };
            
            foreach (int item in newCategory.BlogPost.Select(x => x.Id).ToList())
            {
                var getPostImage = _blogImage.GetAll()
                    .Where(x => x.Person.Id == item)
                    .Select(x => x.Id)
                    .ToList();

                foreach (var deleteImage in getPostImage)
                {
                    await this._blogImage.DeleteAsync(deleteImage).ConfigureAwait(false);
                }

                var getPostComment = this._answer.GetAll()
                   .Where(x => x.BlogPosts.Id == item)
                   .Select(x => x.Id)
                   .ToList();
                
                foreach (var deleteComment in getPostComment)
                {
                    await this._answer.DeleteAsync(deleteComment).ConfigureAwait(true);
                }

                await this._answer.DeleteAsync(item).ConfigureAwait(true);
            }

            await this._category.DeleteAsync(newCategory).ConfigureAwait(true);
         
            return newCategory;
        }

        /// <summary>
        /// The get all category.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public IEnumerable<BlogPostCategory> GetAllCategory()
        {
            var getAllCategory = _category.GetAll();
            return getAllCategory;
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        public IQueryable<BlogPost> GetAll()
        {
            var getAllContact = _repo.GetAll();

            return getAllContact;
        }

        /// <summary>
        /// The get by id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public IEnumerable<BlogPost> GetById(int id)
        {
            IQueryable<BlogPost> getById = GetAll().Where(x => x.Id == id);

            return getById;
        }

        /// <summary>
        /// The get by title.
        /// </summary>
        /// <param name="title">
        /// The title.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public IEnumerable<BlogPost> GetByTitle(string title)
        {
            IQueryable<BlogPost> getByTitle = GetAll().Where(x => x.Title == title);
            return getByTitle;
        }
    }
}