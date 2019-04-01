namespace Education.Data.Models
{
    using Abp.Domain.Entities;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The blog post category.
    /// </summary>
    public class CoursesCategory : Entity
    {
        /// <summary>
        /// The _blog post sub category.
        /// </summary>
        private readonly ICollection<CoursesSubCategory> _blogPostSubCategory;

        /// <summary>
        /// The _blog post.
        /// </summary>
        private ICollection<Courses> _blogPost;

        public CoursesCategory()
        {
            _blogPostSubCategory = new HashSet<CoursesSubCategory>();
            _blogPost = new HashSet<Courses>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int BlogPostId { get; set; }

        public virtual ICollection<Courses> BlogPost
        {
            get => _blogPost;
            set => _blogPost = value;
        }
        
        public DateTime? ModifiedOn { get; set; }

        public bool PreserveCreatedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}