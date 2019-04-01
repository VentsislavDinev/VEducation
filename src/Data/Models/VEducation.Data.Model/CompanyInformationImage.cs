namespace Education.Data.Models
{
    using Abp.Domain.Entities;

    /// <summary>
    /// The company information image.
    /// </summary>
    public class CompanyInformationImage : Entity
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the file path.
        /// </summary>
        public string FilePath { get; set; }
    }
}