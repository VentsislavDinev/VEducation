namespace VEducation.Service.Company
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Abp.Application.Services;
    using Abp.Domain.Repositories;
    
    using Education.Service.Company;
    using VEducation.Data.Model;

    /// <summary>
    /// The about sevice.
    /// </summary>
    public class AboutSevice : CompanyServiceBase, IAbout
    {
        /// <summary>
        /// The repo
        /// </summary>
        private IRepository<About> _repo;
        

        public AboutSevice(IRepository<About> repo)
        {
            if (repo == null)
            {
                throw new ArgumentNullException("repo is null or empty");
            }
            
            this._repo = repo;
        }

        /// <summary>
        /// The get all.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public IEnumerable<About> GetAll()
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
        public IEnumerable<About> GetWithId(int id)
        {
            var getWithId = this._repo.GetAll().Where(x => x.Id == id);
            return getWithId;
        }

        /// <summary>
        /// The get with name.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        public void GetWithName(string name)
        {
            this._repo.GetAll().Where(x => x.Name == name);
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
        /// <param name="createdOn">
        /// The created on.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<About> Create(string name, string desc, DateTime createdOn)
        {
            var newabout = new About
            {
                Name = name,
                Description = desc,
                CreationTime = createdOn,
            };

            await this._repo.InsertAsync(newabout).ConfigureAwait(true);
            
            return newabout;
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
        /// <param name="createdOn">
        /// The created on.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<About> Update(int id, string name, string desc, DateTime createdOn)
        {
            var newabout = new About
            {
                Name = name,
                CreationTime = createdOn,
                Description = desc,

                PreserveCreatedOn = true
            };

            await this._repo.UpdateAsync(newabout).ConfigureAwait(true);
          
            return newabout;
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
        public async Task<About> Delete(int id, DateTime createdOn)
        {
            var newabout = new About
            {
                CreationTime = createdOn,
                DeletedOn = createdOn,
                IsDeleted = true,
            };
            
            await this._repo.DeleteAsync(newabout).ConfigureAwait(true);
          

            return newabout;
        }
    }
}