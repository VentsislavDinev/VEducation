namespace VEducation.Service.Company
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Abp.Application.Services;
    using VEducation.Data.Model;

    /// <summary>
    /// The About interface.
    /// </summary>
    public interface IAbout : IApplicationService
    {
        /// <summary>
        /// The get all.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        IEnumerable<About> GetAll();

        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="desc">
        /// The desc.
        /// </param>
        /// <param name="createdOn">
        /// The created on.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<About> Create(string name, string desc, DateTime createdOn);
                                                                                                                                                                                                 
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
        /// <param name="createdOn">
        /// The created on.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<About> Update(int id, string name, string desc, DateTime createdOn);

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
        Task<About> Delete(int id, DateTime createdOn);

        /// <summary>
        /// The get with id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        IEnumerable<About> GetWithId(int id);

        /// <summary>
        /// The get with name.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        void GetWithName(string name);
    }
}