namespace Education.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Abp.Domain.Entities;
    
    /// <summary>
    /// The blog post category.
    /// </summary>
    public class BlogPostCategory : Entity
    {
        /// <summary>
        /// The _blog post sub category.
        /// </summary>
        private ICollection<BlogPostSubCategory> _blogPostSubCategory;

        /// <summary>
        /// The _blog post.
        /// </summary>
        private ICollection<BlogPost> _blogPost;

        public BlogPostCategory()
        {
            this._blogPostSubCategory = new HashSet<BlogPostSubCategory>();
            this._blogPost = new HashSet<BlogPost>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int BlogPostId { get; set; }

        public virtual ICollection<BlogPost> BlogPost
        {
            get
            {
                return this._blogPost;
            }
            set
            {
                this._blogPost = value;
            }
        }

        public DateTime? ModifiedOn { get; set; }

        public bool PreserveCreatedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}