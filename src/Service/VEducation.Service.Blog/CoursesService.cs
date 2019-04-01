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
    public class CoursesService : BlogServiceBase, ICoursesService
    {
        /// <summary>
        /// The repo
        /// </summary>
        private IRepository<Courses> _repo;

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



        public CoursesService(IRepository<Courses> repo, IRepository<CoursesCategory> category, IRepository<CoursesAnswer> answer, IRepository<CoursesImage> blogImage)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
            _category = category ?? throw new ArgumentNullException(nameof(category));
            _answer = answer ?? throw new ArgumentNullException(nameof(answer));
            _blogImage = blogImage ?? throw new ArgumentNullException(nameof(blogImage));
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
        public async Task<Courses> Create(string title, string shortContent, string desc, DateTime createdOn, string userId, int categoryId, string filePath)
        {
            Courses createBlogPost = new Courses
            {
                Title = title,
                CreationTime = createdOn,
                UserId = userId,
                ShortContent = shortContent,
                Description = desc,
                CourseCategoriesId = categoryId,
            };

            if (filePath != null)
            {
                CoursesImage avatar = new CoursesImage
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
        public async Task<Courses> Update(int id, string title, DateTime createdOn, string shortContent, string userId, string desc, int categoryId, string filePath)
        {
            Courses createBlogPost = new Courses
            {
                Title = title,
                CreationTime = createdOn,
                UserId = userId,
                ShortContent = shortContent,
                Description = desc,

                CourseCategoriesId = categoryId,
                PreserveCreatedOn = true
            };

            CoursesImage avatar = new CoursesImage
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
        public async Task<Courses> Delete(int id, DateTime deletedOn)
        {
            Courses createBlogPost = new Courses
            {
                IsDeleted = true,
                DeletedOn = deletedOn
            };


            foreach (int item in createBlogPost.CourseAnswer.Select(x => x.Id).ToList())
            {
                await _answer.DeleteAsync(item).ConfigureAwait(true);
            }
            

            foreach (int blogImage in createBlogPost.CourseImage.Select(x => x.Id).ToList())
            {
               await this._blogImage.DeleteAsync(blogImage).ConfigureAwait(true);
            }
            
            return createBlogPost;
        }

        public IEnumerable<CoursesImage> GetImageByBlogId(int id)
        {
            var getBlog = _blogImage.GetAll().Where(x => x.PersonId == id);
            return getBlog;
        }

        public IEnumerable<CoursesImage> GetAllImage()
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
        public async Task<CoursesAnswer> CreateAnswer(DateTime creationTime, string userId, string comment, int postId)
        {
            CoursesAnswer newAnswer = new CoursesAnswer
            {
                CreatedOn = creationTime,
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
        public async Task<CoursesAnswer> UpdateAnswer(int id, DateTime creationTime, string userId, string comment, int postId)
        {
            CoursesAnswer updateAnswer = new CoursesAnswer
            {
                CreatedOn = creationTime,
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
        public async Task<CoursesAnswer> DeleteAnswer(DateTime creationTime, int postId)
        {
            CoursesAnswer deleteComment = new CoursesAnswer
            {
                DeletedOn = creationTime,
                IsDeleted = true
            };
            
            await this._answer.DeleteAsync(deleteComment).ConfigureAwait(true);
           
            return deleteComment;
        }

        public IEnumerable<CoursesAnswer> GetAllAnswer(string title)
        {
            var getAnswer = _answer.GetAll().Where(x => x.BlogPosts.Title == title);
            return getAnswer;
        }

        public async Task<CoursesCategory> CreateCategory(string name)
        {
            CoursesCategory newCategory = new CoursesCategory
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
        public async Task<CoursesCategory> UpdateCategory(int id, string name)
        {
            CoursesCategory newCategory = new CoursesCategory
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
        public async Task<CoursesCategory> DeleteCategory(int id, DateTime deletedOn)
        {
            CoursesCategory newCategory = new CoursesCategory
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
        public IEnumerable<CoursesCategory> GetAllCategory()
        {
            var getAllCategory = _category.GetAll();
            return getAllCategory;
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        public IQueryable<Courses> GetAll()
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
        public IEnumerable<Courses> GetById(int id)
        {
            IQueryable<Courses> getById = GetAll().Where(x => x.Id == id);

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
        public IEnumerable<Courses> GetByTitle(string title)
        {
            IQueryable<Courses> getByTitle = GetAll().Where(x => x.Title == title);
            return getByTitle;
        }
    }
}