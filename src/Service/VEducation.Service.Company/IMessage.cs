namespace VEducation.Service.Company
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Abp.Application.Services;
    using Education.Data.Models;

    /// <summary>
    /// The MessageCompany interface.
    /// </summary>
    public interface IMessageCompany : IApplicationService
    {
        /// <summary>
        /// The get all.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        IEnumerable<CompanyMessage> GetAll();

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="createdOn">
        /// The created on.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<CompanyMessage> Delete(int id, DateTime createdOn);

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="firstName">
        /// The first name.
        /// </param>
        /// <param name="desc">
        /// The desc.
        /// </param>
        /// <param name="lastName">
        /// The last name.
        /// </param>
        /// <param name="phone">
        /// The phone.
        /// </param>
        /// <param name="title">
        /// The title.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<CompanyMessage> Update(int id, string firstName, string desc, string lastName, string phone, string title);

        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="firstName">
        /// The first name.
        /// </param>
        /// <param name="desc">
        /// The desc.
        /// </param>
        /// <param name="lastName">
        /// The last name.
        /// </param>
        /// <param name="phone">
        /// The phone.
        /// </param>
        /// <param name="title">
        /// The title.
        /// </param>
        /// <param name="email">
        /// The email.
        /// </param>
        /// <param name="createdOn">
        /// The created on.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<CompanyMessage> Create(string firstName, string desc, string lastName, string phone, string title, string email, DateTime createdOn);
    }
}