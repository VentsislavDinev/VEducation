using Abp.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace VEducation.Data.Model
{
    public class About : Entity
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
        /// Gets or sets the description.
        /// </summary>
        [AllowHtml]
        [DataType("tinymce_full")]
        [UIHint("tinymce_full")]
       
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the creation time.
        /// </summary>
        public DateTime CreationTime { get; set; }
        
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
