namespace Education.Service.User.Company
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Abp.Application.Services;

    using Education.Data.Models;

    /// <summary>
    /// The CompanyLogoService interface.
    /// </summary>
    public interface ICompanyLogoService : IApplicationService
    {
        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="filePath">
        /// The file path.
        /// </param>
        /// <param name="fileType">
        /// The file type.
        /// </param>
        /// <param name="title">
        /// The title.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<CompanyLogo> Create(string filePath, FileType fileType, string title);

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="deletedOn">
        /// The deleted on.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<CompanyLogo> Delete(int id, DateTime deletedOn);

        /// <summary>
        /// The get all.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        IEnumerable<CompanyLogo> GetAll();

        /// <summary>
        /// The get by id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        IEnumerable<CompanyLogo> GetById(int id);

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="filePath">
        /// The file path.
        /// </param>
        /// <param name="fileType">
        /// The file type.
        /// </param>
        /// <param name="title">
        /// The title.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<CompanyLogo> Update(int id, string filePath, FileType fileType, string title);
    }
}