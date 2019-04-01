using System;

namespace Education.Data.Models
{
    using Abp.Domain.Entities;

    /// <summary>
    /// The company logo.
    /// </summary>
    public class CompanyLogo : Entity
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the file name.
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the file type.
        /// </summary>
        public FileType FileType { get; set; }

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

        /// <summary>
        /// Gets or sets the small image.
        /// </summary>
        public string SmallImage { get; set; }

        /// <summary>
        /// Gets or sets the medium image.
        /// </summary>
        public string MediumImage { get; set; }
    }
}