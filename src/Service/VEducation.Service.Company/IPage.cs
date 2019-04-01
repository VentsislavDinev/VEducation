namespace VEducation.Service.Company
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Abp.Application.Services;

    using Education.Data.Models.Company;

    /// <summary>
    /// The Page interface.
    /// </summary>
    public interface IPage : IApplicationService
    {
        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="createdOn">
        /// The created on.
        /// </param>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="desc">
        /// The desc.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<StaticPage> Create(DateTime createdOn, string name, string desc);

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
        Task<StaticPage> Delete(DateTime createdOn, int id);

        /// <summary>
        /// The get all.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        IEnumerable<StaticPage> GetAll();

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<StaticPage> Update(int id);
    }
}