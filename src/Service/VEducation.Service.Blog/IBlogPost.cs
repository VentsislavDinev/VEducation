namespace Education.Service.User
{
    using Education.Data.Models;

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Abp.Application.Services;

    /// <summary>
    /// The BlogPost interface.
    /// </summary>
    public interface IBlogPost : IApplicationService
    {
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
        Task<BlogPost> Create(string title, string shortContent, string desc, DateTime createdOn, string userId, int categoryId, string filePath);

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
        Task<BlogPostAnswer> CreateAnswer(DateTime creationTime, string userId, string comment, int postId);

        /// <summary>
        /// The create category.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<BlogPostCategory> CreateCategory(string name);

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
        Task<BlogPost> Delete(int id, DateTime deletedOn);

        /// <summary>
        /// The delete answer.
        /// </summary>
        /// <param name="creationTime">
        /// The creation time.
        /// </param>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<BlogPostAnswer> DeleteAnswer(DateTime creationTime, int id);

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
        Task<BlogPostCategory> DeleteCategory(int id, DateTime deletedOn);

        /// <summary>
        /// The get all.
        /// </summary>
        /// <returns>
        /// The <see cref="IQueryable"/>.
        /// </returns>
        IQueryable<BlogPost> GetAll();

        /// <summary>
        /// The get all answer.
        /// </summary>
        /// <param name="title">
        /// The title.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        IEnumerable<BlogPostAnswer> GetAllAnswer(string title);

        /// <summary>
        /// The get all category.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        IEnumerable<BlogPostCategory> GetAllCategory();

        /// <summary>
        /// The get all image.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        IEnumerable<BlogImages> GetAllImage();

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
        Task<BlogPost> Update(int id, string title, DateTime createdOn, string shortContent, string userId, string desc, int categoryId, string filePath);

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
        Task<BlogPostAnswer> UpdateAnswer(int id, DateTime creationTime, string userId, string comment, int postId);

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
        Task<BlogPostCategory> UpdateCategory(int id, string name);
    }
}