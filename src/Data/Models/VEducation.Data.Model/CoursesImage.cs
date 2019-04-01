using System;


namespace Education.Data.Models
{
    using Abp.Domain.Entities;

    /// <summary>
    /// The blog images.
    /// </summary>
    public class CoursesImage : Entity
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
        /// Gets or sets the person id.
        /// </summary>
        public int PersonId { get; set; }

        /// <summary>
        /// Gets or sets the person.
        /// </summary>
        public virtual Courses Person { get; set; }

        /// <summary>
        /// Gets or sets the created on.
        /// </summary>
        public DateTime? CreatedOn { get; set; }

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
        /// Gets or sets the big image path.
        /// </summary>
        public string BigImagePath { get; set; }

        /// <summary>
        /// Gets or sets the small image path.
        /// </summary>
        public string SmallImagePath { get; set; }
    }
}