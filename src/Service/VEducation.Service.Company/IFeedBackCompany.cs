namespace VEducation.Service.Company
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Abp.Application.Services;
    using Education.Data.Models;

    /// <summary>
    /// The FeedBackCompany interface.
    /// </summary>
    public interface IFeedBackCompany : IApplicationService
    {
        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="desc">
        /// The desc.
        /// </param>
        /// <param name="logo">
        /// The logo.
        /// </param>
        /// <param name="createdOn">
        /// The created on.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<CompanyFeedBackCompany> Create(string name, string desc, string logo, DateTime createdOn);

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="createdOn">
        /// The created on.
        /// </param>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<CompanyFeedBackCompany> Delete(DateTime createdOn, int id);

        /// <summary>
        /// The get all.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        IEnumerable<CompanyFeedBackCompany> GetAll();

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="desc">
        /// The desc.
        /// </param>
        /// <param name="logo">
        /// The logo.
        /// </param>
        /// <param name="createdOn">
        /// The created on.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<CompanyFeedBackCompany> Update(int id, string name, string desc, string logo, DateTime createdOn);
    }
}