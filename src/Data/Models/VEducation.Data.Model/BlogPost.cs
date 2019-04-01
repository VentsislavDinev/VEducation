namespace Education.Data.Models
{
    using Abp.Domain.Entities;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The blog post.
    /// </summary>
    public class BlogPost : Entity
    {
        /// <summary>
        /// The blog post answer.
        /// </summary>
        private ICollection<BlogPostAnswer> blogPostAnswer;

        /// <summary>
        /// The _blog image.
        /// </summary>
        private ICollection<BlogImages> _blogImage;

        /// <summary>
        /// Initializes a new instance of the <see cref="BlogPost"/> class.
        /// </summary>
        public BlogPost()
        {
            _blogImage = new HashSet<BlogImages>();
            blogPostAnswer = new HashSet<BlogPostAnswer>();
        }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the user id.
        /// </summary>
        public string UserId { get; set; }
        

        /// <summary>
        /// Gets or sets the short content.
        /// </summary>
        public string ShortContent { get; set; }

        /// <summary>
        /// Gets or sets the creation time.
        /// </summary>
        public DateTime CreationTime { get; set; }

        /// <summary>
        /// Gets or sets the blog image id.
        /// </summary>
        public int BlogImageId { get; set; }

        /// <summary>
        /// Gets or sets the blog image.
        /// </summary>
        public virtual ICollection<BlogImages> BlogImage
        {
            get => _blogImage;
            set => _blogImage = value;
        }

        /// <summary>
        /// Gets or sets the blog post categories id.
        /// </summary>
        public int BlogPostCategoriesId { get; set; }

        /// <summary>
        /// Gets or sets the blog post categories.
        /// </summary>
        public virtual BlogPostCategory BlogPostCategories { get; set; }

        /// <summary>
        /// Gets or sets the blog post answer id.
        /// </summary>
        public int BlogPostAnswerId { get; set; }

        /// <summary>
        /// Gets or sets the blog post answer.
        /// </summary>
        public virtual ICollection<BlogPostAnswer> BlogPostAnswer
        {
            get => blogPostAnswer;

            set => blogPostAnswer = value;
        }

        /// <summary>
        /// Gets or sets a value indicating whether is deleted.
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Gets or sets the deleted on.
        /// </summary>
        public DateTime? DeletedOn { get; set; }
        
        /// <summary>
        /// Gets or sets the modified on.
        /// </summary>
        public DateTime? ModifiedOn { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether preserve created on.
        /// </summary>
        public bool PreserveCreatedOn { get; set; }
    }
}