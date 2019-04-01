namespace VEducation.Service.Company
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Abp.Domain.Repositories;

    using Education.Service.Company;
    using Education.Data.Models;

    /// <summary>
    /// The feed back company.
    /// </summary>
    public class FeedBackCompany : CompanyServiceBase, IFeedBackCompany
    {
        /// <summary>
        /// The repo
        /// </summary>
        private IRepository<CompanyFeedBackCompany> _repo;

        /// <summary>
        /// Initializes a new instance of the <see cref="FeedBackCompany"/> class.
        /// </summary>
        /// <param name="repo">
        /// The repo.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// </exception>
        public FeedBackCompany(IRepository<CompanyFeedBackCompany> repo)
        {
            if (repo == null)
            {
                throw new ArgumentNullException("repo is null");
            }
            this._repo = repo;
        }

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
        public async Task<CompanyFeedBackCompany> Create(string name, string desc, string logo, DateTime createdOn)
        {
            var newFeedbackComp = new CompanyFeedBackCompany
            {
                CompanyName = name,
                Description = desc,
                CompanyLogos = logo,
                CreatedOn = createdOn,
            };

            await this._repo.InsertAsync(newFeedbackComp).ConfigureAwait(true);
           
            return newFeedbackComp;
        }

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
        /// <exception cref="Exception">
        /// </exception>
        public async Task<CompanyFeedBackCompany> Update(int id, string name, string desc, string logo, DateTime createdOn)
        {
            var newFeedbackComp = new CompanyFeedBackCompany
            {
                CompanyName = name,
                Description = desc,
                CompanyLogos = logo,
                PreserveCreatedOn = true
            };

            await this._repo.UpdateAsync(newFeedbackComp).ConfigureAwait(true);
        
            return newFeedbackComp;
        }

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
        public async Task<CompanyFeedBackCompany> Delete(DateTime createdOn, int id)
        {
            var newFeedbackComp = new CompanyFeedBackCompany()
            {
                IsDeleted = true,
                DeletedOn = createdOn,
            };

            await this._repo.DeleteAsync(newFeedbackComp).ConfigureAwait(true);
           
            return newFeedbackComp;
        }

        /// <summary>
        /// The get all.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public IEnumerable<CompanyFeedBackCompany> GetAll()
        {
            var getAllContact = this._repo.GetAll();
            return getAllContact;
        }

        /// <summary>
        /// The get with id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public IEnumerable<CompanyFeedBackCompany> GetWithId(int id)
        {
            var getWithId = this.GetAll().Where(x => x.Id == id);
            return getWithId;
        }
    }
}