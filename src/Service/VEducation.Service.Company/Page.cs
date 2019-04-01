namespace VEducation.Service.Company
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Abp.Domain.Repositories;

    using Education.Data;
    using Education.Data.Models.Company;
    using Education.Service.Company;
    using Education.Web.Common.Crypto;

    /// <summary>
    /// The page.
    /// </summary>
    public class Page : CompanyServiceBase, IPage
    {
        /// <summary>
        /// The repository
        /// </summary>
        private IRepository<StaticPage> _repository;

        /// <summary>
        /// The _sanitize.
        /// </summary>
        private ISanitizer _sanitize = new HtmlSanitizerAdapter();
 
        /// <summary>
        /// Initializes a new instance of the <see cref="Page"/> class.
        /// </summary>
        /// <param name="userSystemData">The user system data.</param>
        /// <param name="repo">The repo.</param>
        public Page(IRepository<StaticPage> repo)
        {
             if (repo == null)
            {
                throw new ArgumentNullException("repo is null or empty");
            }
            this._repository = repo;
        }

        /// <summary>
        /// The get all.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public IEnumerable<StaticPage> GetAll()
        {
            var getAll = this._repository.GetAll();

            return getAll;
        }

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
        public async Task<StaticPage> Create(DateTime createdOn, string name, string desc)
        {
            var newPage = new StaticPage
            {
                CreatedOn = createdOn,
                Name = name,
                Description = this._sanitize.Sanitize(desc)
            };

            await this._repository.InsertAsync(newPage).ConfigureAwait(true);
           
            return newPage;
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<StaticPage> Update(int id)
        {
            var newPage = new StaticPage { PreserveCreatedOn = true };
            await this._repository.UpdateAsync(newPage).ConfigureAwait(true);

            return newPage;
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
        public async Task<StaticPage> Delete(DateTime createdOn, int id)
        {
            var newPage = new StaticPage { IsDeleted = true, DeletedOn = createdOn};

            await this._repository.DeleteAsync(newPage).ConfigureAwait(true);
           
            return newPage;
        }
    }
}