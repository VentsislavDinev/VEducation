namespace VEducation.Service.Company
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Abp.Application.Services;
    using VEducation.Data.Model;

    /// <summary>
    /// The Contact interface.
    /// </summary>
    public interface IContact : IApplicationService
    {
        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="office">
        /// The office.
        /// </param>
        /// <param name="number">
        /// The number.
        /// </param>
        /// <param name="workFrom">
        /// The work from.
        /// </param>
        /// <param name="workTo">
        /// The work to.
        /// </param>
        /// <param name="createdOn">
        /// The created on.
        /// </param>
        /// <param name="address">
        /// The address.
        /// </param>
        /// <param name="city">
        /// The city.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<CompanyContact> Create(string office, string number, DateTime workFrom, DateTime workTo, DateTime createdOn, string address, string city);

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="office">
        /// The office.
        /// </param>
        /// <param name="number">
        /// The number.
        /// </param>
        /// <param name="workFrom">
        /// The work from.
        /// </param>
        /// <param name="workTo">
        /// The work to.
        /// </param>
        /// <param name="createdOn">
        /// The created on.
        /// </param>
        /// <param name="address">
        /// The address.
        /// </param>
        /// <param name="city">
        /// The city.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<CompanyContact> Update(int id, string office, string number, DateTime workFrom, DateTime workTo, DateTime createdOn, string address, string city);

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
        Task<CompanyContact> Delete(int id, DateTime deletedOn);

        /// <summary>
        /// The get all.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        IEnumerable<CompanyContact> GetAll();
    }
}