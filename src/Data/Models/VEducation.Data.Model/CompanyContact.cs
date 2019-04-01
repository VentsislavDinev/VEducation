namespace VEducation.Data.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Abp.Domain.Entities;

    /// <summary>
    /// The company contact.
    /// </summary>
    public class CompanyContact : Entity
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the phonenumber.
        /// </summary>
        public string Phonenumber { get; set; }

        /// <summary>
        /// Gets or sets the office country.
        /// </summary>
       public string OfficeCountry { get; set; }

        /// <summary>
        /// Gets or sets the work from.
        /// </summary>
        public DateTime WorkFrom { get; set; }

        /// <summary>
        /// Gets or sets the work to.
        /// </summary>
        public DateTime WorkTo { get; set; }

        /// <summary>
        /// Gets or sets the creation time.
        /// </summary>
        public DateTime CreationTime { get; set; }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
       public string City { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
         public string Address { get; set; }
        

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
        public string Email { get; set; }
    }
}