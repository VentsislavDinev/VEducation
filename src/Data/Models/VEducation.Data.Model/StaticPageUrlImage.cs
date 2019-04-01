using System;

namespace Education.Data.Models
{
    using Abp.Domain.Entities;

    using Castle.Components.DictionaryAdapter;

    /// <summary>
    /// The static page url image.
    /// </summary>
    public class StaticPageUrlImage : Entity
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [Key("Id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the content.
        /// </summary>
        public byte[] Content { get; set; }

        /// <summary>
        /// Gets or sets the extension.
        /// </summary>
        public string Extension { get; set; }

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