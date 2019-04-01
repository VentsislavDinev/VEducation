namespace VEducation.Service.Company
{
    using Data;

    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Abp.Domain.Repositories;

    using Education.Service.Company;
    using Education.Data.Models;

    /// <summary>
    /// The service.
    /// </summary>
    public class Service : CompanyServiceBase, IService
    {
        /// <summary>
        /// The repo
        /// </summary>
        private IRepository<CompanyInformation> _repo;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Service"/> class. 
        /// </summary>
        /// <param name="repo">
        /// The company system data.
        /// </param>
        public Service(IRepository<CompanyInformation> repo)
        {
            if (repo == null)
            {
                throw new ArgumentNullException("repo is null or empty");
            }

            this._repo = repo;
        }

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
        /// <param name="filePath">
        /// The file path.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<CompanyInformation> Create(string desc, string name, DateTime createdOn, string filePath)
        {
            var newinfo = new CompanyInformation
                              {
                                  Description = desc,
                                  Name = name,
                                  CreatedOn = createdOn,
                                  FilePath = filePath
                              };

           await this._repo.InsertAsync(newinfo).ConfigureAwait(true);
           
            return newinfo;
        }

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
        public async Task<CompanyInformation> Update(int id, string desc, string name)
        {
            var newinfo = new CompanyInformation { Description = desc, Name = name, PreserveCreatedOn = true, };
            
            await this._repo.UpdateAsync(newinfo).ConfigureAwait(true);
           

            return newinfo;
        }

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
        public async Task<CompanyInformation> Delete(int id, DateTime createdOn)
        {
            var newinfo = new CompanyInformation { IsDeleted = true, DeletedOn = createdOn, };
            
            await this._repo.DeleteAsync(newinfo).ConfigureAwait(true);
           
            return newinfo;
        }

        /// <summary>
        /// The get all.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public IEnumerable<CompanyInformation> GetAll()
        {
            var getAllContact = this._repo.GetAll();

            return getAllContact;
        }
    }
}