namespace Education.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Abp.Domain.Entities;
    
    /// <summary>
    /// The blog post answer.
    /// </summary>
    public class BlogPostAnswer : Entity
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the creation time.
        /// </summary>
        public DateTime CreationTime { get; set; }

        /// <summary>
        /// Gets or sets the user id.
        /// </summary>
        public string UserId { get; set; }


        /// <summary>
        /// Gets or sets the blog posts id.
        /// </summary>
        public int BlogPostsId { get; set; }

        /// <summary>
        /// Gets or sets the blog posts.
        /// </summary>
        public BlogPost BlogPosts { get; set; }

        /// <summary>
        /// Gets or sets the created on.
        /// </summary>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets the modified on.
        /// </summary>
        public DateTime? ModifiedOn { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether preserve created on.
        /// </summary>
        public bool PreserveCreatedOn { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is deleted.
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Gets or sets the deleted on.
        /// </summary>
        public DateTime? DeletedOn { get; set; }
    }
}