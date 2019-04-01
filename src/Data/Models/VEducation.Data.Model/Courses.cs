namespace Education.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Abp.Domain.Entities;
    
    /// <summary>
    /// The blog post.
    /// </summary>
    public class Courses : Entity
    {
        /// <summary>
        /// The blog post answer.
        /// </summary>
        private ICollection<CoursesAnswer> blogPostAnswer;

        /// <summary>
        /// The _blog image.
        /// </summary>
        private ICollection<CoursesImage> _blogImage;

        /// <summary>
        /// Initializes a new instance of the <see cref="BlogPost"/> class.
        /// </summary>
        public Courses()
        {
            this._blogImage = new HashSet<CoursesImage>();
            this.blogPostAnswer = new HashSet<CoursesAnswer>();
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
        public int CourseImageId { get; set; }

        /// <summary>
        /// Gets or sets the blog image.
        /// </summary>
        public virtual ICollection<CoursesImage> CourseImage
        {
            get
            {
                return this._blogImage;
            }
            set
            {
                this._blogImage = value;
            }
        }

        /// <summary>
        /// Gets or sets the blog post categories id.
        /// </summary>
        public int CourseCategoriesId { get; set; }

        /// <summary>
        /// Gets or sets the blog post categories.
        /// </summary>
        public virtual CoursesCategory CourseCategories { get; set; }

        /// <summary>
        /// Gets or sets the blog post answer id.
        /// </summary>
        public int CourseAnswerId { get; set; }

        /// <summary>
        /// Gets or sets the blog post answer.
        /// </summary>
        public virtual ICollection<CoursesAnswer> CourseAnswer
        {
            get
            {
                return this.blogPostAnswer;
            }

            set
            {
                this.blogPostAnswer = value;
            }
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