namespace Education.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Abp.Domain.Entities;
    
    /// <summary>
    /// The blog post sub category.
    /// </summary>
    public class BlogPostSubCategory : Entity
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
        /// Gets or sets the cagory id.
        /// </summary>
        public string CagoryId { get; set; }

        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        public BlogPostCategory Category { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is deleted.
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Gets or sets the deleted on.
        /// </summary>
        public DateTime? DeletedOn { get; set; }

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
    }
}