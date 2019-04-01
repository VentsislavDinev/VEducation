namespace VEducation.Service.Company
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Education.Data.Models;

    /// <summary>
    /// The Service interface.
    /// </summary>
    public interface IService
    {
        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="desc">
        /// The desc.
        /// </param>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="createdOn">
        /// The created on.
        /// </param>
        /// <param name="userName">
        /// The user name.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<CompanyInformation> Create(string desc, string name, DateTime createdOn, string userName);

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
        Task<CompanyInformation> Delete(int id, DateTime createdOn);

        /// <summary>
        /// The get all.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        IEnumerable<CompanyInformation> GetAll();

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="desc">
        /// The desc.
        /// </param>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<CompanyInformation> Update(int id, string desc, string name);
    }
}