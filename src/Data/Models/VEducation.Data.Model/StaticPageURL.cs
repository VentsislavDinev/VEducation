using System;

namespace Education.Data.Models
{
    using Abp.Domain.Entities;

    /// <summary>
    /// The static page url.
    /// </summary>
    public class StaticPageURL : Entity
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
        /// Gets or sets the url.
        /// </summary>
        public string URL { get; set; }

        /// <summary>
        /// Gets or sets the image id.
        /// </summary>
        public int ImageId { get; set; }

        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        public virtual StaticPageUrlImage Image { get; set; }

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